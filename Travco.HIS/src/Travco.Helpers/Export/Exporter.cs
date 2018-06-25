using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travco.HIS.Api;
using Travco.HIS.Model.Request.Export.HotelAvail;
using Travco.HIS.Model.Request.Export.HotelRateAmount;

namespace Travco.Helpers.HIS
{
    public class Exporter : IDisposable
    {
        private Task ExportTask { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }

        private readonly ILogger _logger;
        private readonly IHISExportClient _exportClient;
        private readonly IDbConnection _connection;

        public ExportProgress Progress { get; private set; }

        public Exporter(
            IOptions<HISExportOptions> options,
            ILogger<Exporter> logger,
            IHISExportClient exportClient
        )
        {
            _logger = logger;
            _exportClient = exportClient;
            _connection = new SqlConnection(options.Value.ConnectionString);
        }

        public void Go()
        {
            if (ExportTask != null) // We're already mid-run ...
            {
                if (ExportTask.IsCanceled || ExportTask.IsCompleted || ExportTask.IsFaulted)
                {
                    ExportTask = null;
                }
                else
                {
                    throw new ApplicationException("Cannot re-run export while one is already in progress ...");
                }
            }

            if (CancellationTokenSource != null)
                CancellationTokenSource.Dispose();
            CancellationTokenSource = new CancellationTokenSource();

            Progress = new ExportProgress();
            ExportTask = Task.Factory.StartNew(() => Worker(CancellationTokenSource.Token));
        }

        public void Cancel()
        {
            if (CancellationTokenSource != null)
                CancellationTokenSource.Cancel();
        }

        private async Task Worker(CancellationToken cancellationToken)
        {
            try
            {
                var hotelData = GetHotelData();

                Progress.Total = hotelData.Rows.Count;
                Progress.StartTime = DateTime.UtcNow;
                Progress.Status = ExportStatus.Running;

                for (int i = 0; i < Progress.Total; i++)
                {
                    // Do the needful!
                    var hotelCode = hotelData.Rows[i][0].ToString();

                    var hotelRequest = GetHotelRequest(GetInventoryData(hotelCode), GetBookingsData(hotelCode));
                    var hotelResponse = await _exportClient.SendHotel(hotelRequest);
                    if (hotelResponse?.Body?.OTA_HotelAvailNotifRS?.Success == null)
                    {
                        // Log it
                        var errors = hotelResponse?.Body?.OTA_HotelAvailNotifRS?.Errors;
                        var errorMesssage = errors != null ? String.Join("|", errors.Select(x => x.ShortText)) : "UNKNOWN";
                        _logger.LogError(String.Format("Error response from OTA_HotelAvailNotifRQ (Hotel): {0}", errorMesssage));
                        Progress.ErrorCount++;
                        continue;
                    }

                    var lengthOfStayData = GetLengthOfStayData(hotelCode);
                    var lengthOfStayRequest = GetLengthOfStayRequest(lengthOfStayData);
                    if (lengthOfStayRequest != null)
                    {
                        var lengthOfStayResponse = await _exportClient.SendHotel(lengthOfStayRequest);
                        if (lengthOfStayResponse?.Body?.OTA_HotelAvailNotifRS?.Success == null)
                        {
                            // Log it
                            var errors = lengthOfStayResponse?.Body?.OTA_HotelAvailNotifRS?.Errors;
                            var errorMesssage = errors != null ? String.Join("|", errors.Select(x => x.ShortText)) : "UNKNOWN";
                            _logger.LogError(String.Format("Error response from OTA_HotelAvailNotifRS (LengthOfStay): {0}", errorMesssage));
                            Progress.ErrorCount++;
                            continue;
                        }
                    }

                    var ratesData = GetRatesData(hotelCode);
                    var ratesRequest = GetRatesRequest(ratesData);
                    if (ratesRequest != null)
                    {
                        var ratesResponse = await _exportClient.SendRates(ratesRequest);
                        if (ratesResponse?.Body?.OTA_HotelRateAmountNotifRS?.Success == null)
                        {
                            // Log it
                            var errors = ratesResponse?.Body?.OTA_HotelRateAmountNotifRS?.Errors;
                            var errorMesssage = errors != null ? String.Join("|", errors.Select(x => x.ShortText)) : "UNKNOWN";
                            _logger.LogError(String.Format("Error response from OTA_HotelRateAmountNotifRS: {0}", errorMesssage));
                            Progress.ErrorCount++;
                            continue;
                        }
                    }

                    Progress.Completed++;

                    if (cancellationToken.IsCancellationRequested)
                    {
                        Progress.Status = ExportStatus.Cancelled;
                        Progress.EndTime = DateTime.UtcNow;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "** Export failure");
                throw;
            }

            Progress.Status = ExportStatus.Stopped;
            Progress.EndTime = DateTime.UtcNow;
        }

        public void Dispose()
        {
            if (CancellationTokenSource != null)
                CancellationTokenSource.Dispose();
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                _connection.Dispose();
            }
        }

        #region Data Fetching

        private DataTable GetHotelData()
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    if (_connection.State == ConnectionState.Closed)
                        _connection.Open();

                    command.CommandText = HOTEL_QUERY;
                    using (var reader = command.ExecuteReader())
                    {
                        data.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error performing Hotel DB query");
                throw;
            }
            return data;
        }

        private DataTable GetBookingsData(string hotelCode)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    if (_connection.State == ConnectionState.Closed)
                        _connection.Open();

                    command.CommandText = String.Format(BOOKING_QUERY, hotelCode);
                    using (var reader = command.ExecuteReader())
                    {
                        data.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error performing Inventory DB query");
                throw;
            }
            return data;
        }

        private DataTable GetInventoryData(string hotelCode)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    if (_connection.State == ConnectionState.Closed)
                        _connection.Open();

                    command.CommandText = String.Format(INVENTORY_QUERY, hotelCode);
                    using (var reader = command.ExecuteReader())
                    {
                        data.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error performing Inventory DB query");
                throw;
            }
            return data;
        }

        private DataTable GetLengthOfStayData(string hotelCode)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    if (_connection.State == ConnectionState.Closed)
                        _connection.Open();

                    command.CommandText = String.Format(MIN_LENGTH_OF_STAY_QUERY, hotelCode);
                    using (var reader = command.ExecuteReader())
                    {
                        data.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error performing MinLengthOfStay DB query");
                throw;
            }
            return data;
        }

        private DataTable GetRatesData(string hotelCode)
        {
            DataTable data = new DataTable();
            try
            {
                using (var command = _connection.CreateCommand())
                {
                    if (_connection.State == ConnectionState.Closed)
                        _connection.Open();

                    command.CommandText = String.Format(PRICE_QUERY, hotelCode);
                    using (var reader = command.ExecuteReader())
                    {
                        data.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error performing Rates DB query");
                throw;
            }
            return data;
        }

        #endregion

        #region Request Creation

        private OTA_HotelAvailNotifRQ GetHotelRequest(DataTable availability, DataTable bookings)
        {
            // Perform date split
            List<OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage> elements = new List<OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage>();
            for (int i = 0; i < availability.Rows.Count; i ++)
            {
                var availabilityRow = availability.Rows[i];
                var from = Convert.ToDateTime(availabilityRow[1]);
                var to = Convert.ToDateTime(availabilityRow[2]);
                var inventory = Convert.ToInt32(availabilityRow[3]);

                elements.Add(new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage
                {
                    BookingLimit = 3,
                    BookingLimitMessageType = "SetLimit",
                    RestrictionStatus = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus
                    {
                        Restriction = "Master",
                        Status = inventory > 0 ? "Open" : "Close"
                    },
                    StatusApplicationControl = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl
                    {
                        End = to,
                        InvCode = "STANDARD",
                        InvCodeApplication = "InvCode",
                        IsRoom = 1,
                        RatePlanCode = "RACK",
                        RatePlanCodeType = "RatePlanCode",
                        Start = from
                    }
                });

                // Perform any necessary date splits
                if (bookings.Rows.Count > 0)
                {
                    int bookingIndex = 0;
                    while (bookingIndex < bookings.Rows.Count)
                    {
                        DateTime current = Convert.ToDateTime(bookings.Rows[bookingIndex][0]);

                        if (current >= from && current <= to)
                        {
                            // Chop previous date range down
                            elements.Last().StatusApplicationControl.End = current.AddDays(-1);
                            // Calculate number of spaces available by removing bookings against inventory
                            int spaces = inventory - Convert.ToInt32(bookings.Rows[bookingIndex][1]);
                            // Add a new one for a single day
                            elements.Add(new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage
                            {
                                BookingLimit = 3,
                                BookingLimitMessageType = "SetLimit",
                                RestrictionStatus = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus
                                {
                                    Restriction = "Master",
                                    Status = spaces > 0 ? "Open" : "Close"
                                },
                                StatusApplicationControl = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl
                                {
                                    End = current,
                                    InvCode = "STANDARD",
                                    InvCodeApplication = "InvCode",
                                    IsRoom = 1,
                                    RatePlanCode = "RACK",
                                    RatePlanCodeType = "RatePlanCode",
                                    Start = current
                                }
                            });
                            // Add second part of the split back in
                            elements.Add(new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage
                            {
                                BookingLimit = 3,
                                BookingLimitMessageType = "SetLimit",
                                RestrictionStatus = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus
                                {
                                    Restriction = "Master",
                                    Status = inventory > 0 ? "Open" : "Close"
                                },
                                StatusApplicationControl = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl
                                {
                                    End = Convert.ToDateTime(availabilityRow[2]),
                                    InvCode = "STANDARD",
                                    InvCodeApplication = "InvCode",
                                    IsRoom = 1,
                                    RatePlanCode = "RACK",
                                    RatePlanCodeType = "RatePlanCode",
                                    Start = current.AddDays(1)
                                }
                            });
                        }

                        bookingIndex++;
                    }
                }
            }

            // Collapse date ranges where possible
            List<OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage> final = new List<OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage> { elements.First() };
            for (int i = 1; i < elements.Count; i ++)
            {
                if (final.Last().RestrictionStatus.Status == elements[i].RestrictionStatus.Status)
                    final.Last().StatusApplicationControl.End = elements[i].StatusApplicationControl.End;
                else
                    final.Add(elements[i]);
            }

            var request = new OTA_HotelAvailNotifRQ
            {
                AvailStatusMessages = new OTA_HotelAvailNotifRQAvailStatusMessages
                {
                    HotelCode = availability.Rows[0][0].ToString(),
                    AvailStatusMessage = final.ToArray()
                },
                PrimaryLangID = "en",
                Target = "Test",
                TimeStamp = DateTime.UtcNow,
                Version = 1.000m
            };

            return request;
        }

        private OTA_HotelAvailNotifRQ GetLengthOfStayRequest(DataTable data)
        {
            IList<OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage> elements = new List<OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage>();

            OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage current = null;
            for (int i = 0; i < data.Rows.Count; i ++)
            {
                var row = data.Rows[i];

                for (var date = Convert.ToDateTime(row[1]); date <= Convert.ToDateTime(row[2]); date = date.AddDays(1))
                {
                    if (current == null || current.LengthsOfStay.LengthOfStay[0].Time != Convert.ToInt32(row[3 + Convert.ToInt32(date.DayOfWeek)]))
                    {
                        if (current != null)
                            elements.Add(current);

                        current = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage
                        {
                            BookingLimit = 3,
                            BookingLimitMessageType = "SetLimit",
                            LengthsOfStay = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStay
                            {
                                ArrivalDateBased = 1,
                                LengthOfStay = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay[]
                                {
                                    new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay
                                    {
                                        MinMaxMessageType = "SetMinLOS",
                                        TimeUnit = "Day",
                                        Time = Convert.ToInt32(row[3 + Convert.ToInt32(date.DayOfWeek)]),
                                        OpenStatusIndicator = true
                                    }
                                }
                            },
                            StatusApplicationControl = new OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl
                            {
                                End = DateTime.MinValue,
                                InvCode = "STANDARD",
                                InvCodeApplication = "InvCode",
                                IsRoom = 1,
                                RatePlanCode = "RACK",
                                RatePlanCodeType = "RatePlanCode",
                                Start = date
                            }
                        };
                    }
                    current.StatusApplicationControl.End = date;
                }
            }

            if (current != null)
                elements.Add(current);

            if (elements.Count > 0)
            {
                var request = new OTA_HotelAvailNotifRQ
                {
                    AvailStatusMessages = new OTA_HotelAvailNotifRQAvailStatusMessages
                    {
                        HotelCode = data.Rows[0][0].ToString(),
                        AvailStatusMessage = elements.ToArray()
                    },
                    PrimaryLangID = "en",
                    Target = "Test",
                    TimeStamp = DateTime.UtcNow,
                    Version = 1.000m
                };

                return request;
            }
            else
            {
                return null;
            }
        }

        private OTA_HotelRateAmountNotifRQ GetRatesRequest(DataTable data)
        {
            IList<OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage> elements = new List<OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage>();

            OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage current = null;
            IList<OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt> prices = null;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var row = data.Rows[i];
                DataRow nextRow = null;
                if (i + 1 < data.Rows.Count && data.Rows[i + 1][2].ToString() == data.Rows[i][2].ToString()) // Make sure we're looking at the same room type
                {
                    nextRow = data.Rows[i + 1];
                }

                if (current == null || current.StatusApplicationControl.End != Convert.ToDateTime(row[1]))
                {
                    if (current != null)
                    {
                        current.Rates[0].BaseByGuestAmts = prices.ToArray();
                        elements.Add(current);
                    }

                    current = new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage
                    {
                        Rates = new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRate[]
                        {
                            new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRate
                            {
                                NumberOfUnits = 1,
                                RateTimeUnit = "Day",
                                UnitMultiplier = 0,
                                BaseByGuestAmts = null
                            }
                        },
                        StatusApplicationControl = new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageStatusApplicationControl
                        {
                            End = nextRow == null ? DateTime.MaxValue : Convert.ToDateTime(nextRow[1]).AddDays(-1),
                            InvCode = row[2].ToString(),
                            InvCodeApplication = "InvCode",
                            IsRoom = 1,
                            RatePlanCode = "RACK",
                            RatePlanCodeType = "RatePlanCode",
                            Start = Convert.ToDateTime(row[1])
                        }
                    };

                    prices = new List<OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt>();
                }

                // Adult price
                if (NUMBER_OF_GUESTS.ContainsKey(row[2].ToString()))
                {
                    var numberOfGuests = NUMBER_OF_GUESTS[row[2].ToString()];

                    prices.Add(new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt
                    {
                        AgeQualifyingCode = 1, // Adult
                        AmountAfterTax = Math.Round(Convert.ToDecimal(row[3]) * numberOfGuests),
                        AmountBeforeTax = Math.Round(Convert.ToDecimal(row[3]) * numberOfGuests),
                        CurrencyCode = TRAVCO_CURRENCY_CODES_TO_ISO[row[5].ToString()],
                        DecimalPlaces = 2,
                        NumberOfGuests = numberOfGuests
                    });

                    if (Convert.ToDecimal(row[4]) > 0)
                    {
                        // Child price
                        prices.Add(new OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt
                        {
                            AgeQualifyingCode = 4, // Child
                            AmountAfterTax = Math.Round(Convert.ToDecimal(row[4]) * numberOfGuests),
                            AmountBeforeTax = Math.Round(Convert.ToDecimal(row[4]) * numberOfGuests),
                            CurrencyCode = TRAVCO_CURRENCY_CODES_TO_ISO[row[5].ToString()],
                            DecimalPlaces = 2,
                            NumberOfGuests = numberOfGuests
                        });
                    }
                }
            }

            if (current != null)
            {
                current.Rates[0].BaseByGuestAmts = prices.ToArray();
                elements.Add(current);
            }

            if (elements.Count > 0)
            {
                var request = new OTA_HotelRateAmountNotifRQ
                {
                    RateAmountMessages = new OTA_HotelRateAmountNotifRQRateAmountMessages
                    {
                        HotelCode = data.Rows[0][0].ToString(),
                        RateAmountMessage = elements.ToArray()
                    },
                    PrimaryLangID = "en",
                    Target = "Test",
                    TimeStamp = DateTime.UtcNow,
                    Version = 1.000m
                };

                return request;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Queries

        private const string HOTEL_QUERY = "SELECT HotelCode FROM Allocation EXCEPT (SELECT h.HotelCode FROM AgentHotel h INNER JOIN Agents a ON h.AgentId = a.Id WHERE a.AgentCode = 'his' UNION SELECT h.HotelCode FROM AgentHotel h WHERE h.AgentId1 IS NOT NULL) UNION SELECT hotelCode FROM AgentHotel h INNER JOIN Agents a ON h.AgentId1 = a.Id WHERE a.AgentCode = 'his'";
        private const string INVENTORY_QUERY = "SELECT a.HotelCode, i.FromDate, i.ToDate, SUM(i.NumberRooms) FROM Allocation a INNER JOIN AllocationInfo i ON a.Id = i.AllocationId WHERE a.HotelCode = '{0}' AND a.RoomType NOT IN ('SWB', 'SWO') GROUP BY a.HotelCode, i.FromDate, i.ToDate ORDER BY a.HotelCode, i.FromDate";
        private const string BOOKING_QUERY = "SELECT h.BookingDate, SUM(NumberBookedBeds) FROM RoomBooking r INNER JOIN HotelBookings h ON r.HotelBookingId = h.Id WHERE h.HotelCode = '{0}' AND NOT r.RoomType = 'BBK' GROUP BY h.BookingDate";
        private const string MIN_LENGTH_OF_STAY_QUERY = "SELECT RIGHT(r.ContractId, 3), m.FromDate, m.ToDate, m.Sunday, m.Monday, m.Tuesday, m.Wednesday, m.Thursday, m.Friday, m.Saturday FROM MinimumDuration m INNER JOIN HotelContract c ON m.HotelContractId = c.Id INNER JOIN HotelContractRoot r ON c.HotelContractRef = r.CurrentContractRef WHERE RIGHT(r.ContractId, 3) = '{0}' ORDER BY m.FromDate";
        private const string PRICE_QUERY = "SELECT s.HotelCode, p.SellingDate, s.RoomType, p.AdultSellingPrice * (SELECT TOP 1 cu.ExchangeRate FROM CurrencyConversion cu WHERE cu.CountryCode = c.Country AND cu.BuyingCurrency = c.Currency), p.ChildSellingPrice * (SELECT TOP 1 cu.ExchangeRate FROM CurrencyConversion cu WHERE cu.CountryCode = c.Country AND cu.BuyingCurrency = c.Currency), (SELECT TOP 1 cu.SellingCurrency FROM CurrencyConversion cu WHERE cu.CountryCode = c.Country AND cu.BuyingCurrency = c.Currency) FROM SellingPrice s INNER JOIN SellingPriceInfo p ON p.SellingPriceId = s.Id INNER JOIN HotelContractRoot c ON s.ContractReference = c.CurrentContractRef INNER JOIN HotelBuyingPrices b ON b.CurrentSellingPriceCode = s.Code WHERE s.HotelCode = '{0}' ORDER BY s.RoomType, p.SellingDate";

        #endregion

        #region Lookups

        private IDictionary<string, int> NUMBER_OF_GUESTS = new Dictionary<string, int>
        {
            { "ADS", 1 }, // Double For Single Use - All Inclusive
            { "ADW", 2 }, // Double Room - All Inclusive
            { "AQW", 4 }, // Quad Room - All Inclusive
            { "ASW", 1 }, // Single Room - All Inclusive
            { "ATR", 3 }, // Triple Room - All Inclusive
            { "ATS", 1 }, // Twin For Single Use - All Inclusive
            { "ATW", 2 }, // Twin Room - All Inclusive
            { "DSB", 1 }, // Double For Single Use - With Breakfast
            { "DSH", 1 }, // Double For Single Use - Half Board
            { "DSO", 1 }, // Double For Single Use - Room Only
            { "DWB", 2 }, // Double Room - With Breakfast
            { "DWH", 2 }, // Double Room - Half Board
            { "DWO", 2 }, // Double Room - Room Only
            { "FDS", 1 }, // Double For Single Use - Full Board
            { "FDW", 2 }, // Double Room - Full Board
            { "FQW", 4 }, // Quad Room - Full Board
            { "FSW", 1 }, // Single Room - Full Board
            { "FTR", 3 }, // Triple Room - Full Board
            { "FTW", 2 }, // Twin Room - Full Board
            { "QUA", 4 }, // QUAD ROOM
            { "QWB", 4 }, // Quad Room - With Breakfast
            { "QWH", 4 }, // Quad Room - Half Board
            { "QWO", 4 }, // Quad Room - Room Only
            { "SWB", 1 }, // Single Room - With Breakfast
            { "SWH", 1 }, // Single Room - Half Board
            { "SWO", 1 }, // Single Room - Room Only
            { "TRH", 3 }, // Triple Room - Half Board
            { "TRO", 3 }, // Triple Room - Room Only
            { "TRP", 3 }, // Triple Room - With Breakfast
            { "TSB", 1 }, // Twin For Single Use - With Breakfast
            { "TSH", 1 }, // Twin For Single Use - Half Board
            { "TSO", 1 }, // Twin For Single Use - Room Only
            { "TWB", 2 }, // Twin Room - With Breakfast
            { "TWH", 2 }, // Twin Room - Half Board
            { "TWO", 2 }, // Twin Room - Room Only
        };

        private IDictionary<string, string> TRAVCO_CURRENCY_CODES_TO_ISO = new Dictionary<string, string>
        {
            { "PDS", "GBP" },
            { "USD", "USD" },
            { "EUR", "EUR" }
        };

        #endregion
    }

    public enum ExportStatus
    {
        Stopped,
        Running,
        Cancelled
    }

    public class ExportProgress
    {
        public ExportStatus Status;
        public int Completed;
        public int Total;
        public int ErrorCount;
        public DateTime StartTime;
        public DateTime? EndTime;

        public DateTime? PredictedEndTime
        {
            get
            {
                if (Status != ExportStatus.Running || Completed == 0 || Total == 0)
                    return null;

                var proportionQueued = Convert.ToDouble(Completed) / Total;
                var timeSpent = (DateTime.UtcNow - StartTime).TotalSeconds;
                var timeLeft = (1.0 / proportionQueued) * timeSpent;
                return StartTime.AddSeconds(timeLeft);
            }
        }

        public ExportProgress()
        {
            Status = ExportStatus.Stopped;
            Completed = 0;
            Total = 0;
            ErrorCount = 0;
            StartTime = DateTime.UtcNow;
            EndTime = null;
        }
    }
}
