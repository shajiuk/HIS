using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Travco.HIS.Model;
using Travco.HIS.Model.Request.DMG.Reservation.Cancellation;
using Travco.HIS.Model.Request.HotelAvail;
using Travco.HIS.Model.Request.HotelDescriptiveInfo;
using Travco.HIS.Model.Request.Reservation.Cancellation;
using Travco.HIS.Model.Response.DMG.Reservation.Cancellation;
using Travco.HIS.Model.Response.DMG.SearchAvailability;
using Travco.HIS.Model.Response.Error.SearchAvailability;
using Travco.HIS.Model.Response.HotelDescriptiveInfo;
using Travco.HIS.Model.Response.Reservation;
using Travco.HIS.Model.Response.Reservation.Cancellation;
using BOOKING = Travco.HIS.Model.Request.DMG.HotelAvail.BOOKING;
using EnvelopeHeader = Travco.HIS.Model.Request.HotelAvail.EnvelopeHeader;
using Interface = Travco.HIS.Model.Request.HotelAvail.Interface;
using InterfaceComponentInfo = Travco.HIS.Model.Request.HotelAvail.InterfaceComponentInfo;

namespace Travco.Helpers.HIS
{
    public static class HISHelpers
    {
        public static async Task<string> SendToTalismanAndGetResponseAsync<T>(T booking, string uri, ILogger logger)
        {
            var resultContent = "";

            HttpClient client = new HttpClient();

            var xml = booking.SerializeToXML();

            logger.LogInformation("\nDMG INPUT - \n" + xml);

            var httpContent = new StringContent(xml, Encoding.UTF8, "application/xml");

            var response = await client.PostAsync(uri, httpContent);

            resultContent = await response.Content.ReadAsStringAsync();

            logger.LogInformation("\nDMG OUTPUT - \n" + resultContent);

            return resultContent;
        }

        public enum RoomType
        {
            Single,
            Double,
            Triple,
            Quad
        }

        public static RoomType? ToRoomType(string roomCode)
        {
            switch (roomCode.ToUpper())
            {
                case "SWO":
                case "SWB":
                case "SWH":
                    return RoomType.Single;

                case "DWO":
                case "DWB":
                case "DWH":
                case "TWO":
                case "TWB":
                case "TWH":
                case "ADW":
                case "ATW":
                    return RoomType.Double;

                case "TRO":
                case "TRP":
                case "TRH":
                case "FTR":
                case "ATR":
                    return RoomType.Triple;

                case "QWO":
                case "QWB":
                case "QWH":
                case "FQW":
                case "AQW":
                    return RoomType.Quad;

                default: return null;

            }

        }

        public static string ToMealCodes(string rateplanDetails)
        {
            switch (rateplanDetails.ToLower())
            {
                case "room only":
                    return "NOM";

                case "bed & breakfast":
                    return "BRE";

                case "full board":
                case "all inclusive":
                    return "BLD";

                case "half board":
                    return "BLU";

                default:
                    return null;
            }

        }

        #region ERROR PROCESS

        public static string ProcessError<T>(string message, ILogger logger)
        {
            var errorRes = message.DeserializeFromXML<T>();

            var HIS = errorRes.SerializeToXMLSOAP("", "", "soap-env");
            var httpContent = new StringContent(HIS, Encoding.UTF8, "application/xml");

            var errorMessage = httpContent.ReadAsStringAsync().Result;
            logger.LogError(errorMessage);

            return errorMessage;
            //throw new Helpers.HIS.HISStandardErrorException(httpContent.ReadAsStringAsync().Result);
        }


        public static string ErrorHeaderInfo<T, U>(string message, U travcoBookingRequestModel, OTA_HotelAvailRSErrorsError error)
        {
            var errorRes = message.DeserializeFromXML<T>();

            var agentcode = Utils.GetPropertyValue(travcoBookingRequestModel, "AGENTCODE", "").ToString();
            var agentpassword = Utils.GetPropertyValue(travcoBookingRequestModel, "AGENTPASSWORD", "").ToString();
            var hisHeaderInfo = Utils.GetPropertyValue(travcoBookingRequestModel, "HishHeaderInfo", "");
            var requestId = Utils.GetPropertyValue(hisHeaderInfo, "RequestId", "").ToString();
            var echoToken = Utils.GetPropertyValue(hisHeaderInfo, "EchoToken", "").ToString();
            var primaryLangID = Utils.GetPropertyValue(hisHeaderInfo, "PrimaryLangID", "").ToString();
            var target = Utils.GetPropertyValue(hisHeaderInfo, "Target", "").ToString();

            Utils.GetPropertyValue(errorRes, "User", agentcode);
            Utils.GetPropertyValue(errorRes, "Pwd", agentpassword);

            var hisBody = Utils.GetPropertyValue(errorRes, "Body", "");

            if (hisBody != null)
            {
                // uses the transaction name to create the actual object name
                var objectType = "OTA_" + Utils.GetPropertyValue(hisBody, "Transaction", "");

                Utils.GetPropertyValue(hisBody, "RequestId", requestId);

                var hisObject = Utils.GetPropertyValue(hisBody, objectType, "");

                if (hisObject != null)
                {
                    Utils.GetPropertyValue(hisObject, "EchoToken", echoToken);
                    Utils.GetPropertyValue(hisObject, "PrimaryLangID", primaryLangID);
                    Utils.GetPropertyValue(hisObject, "Target", target);
                }
            }

            return errorRes.SerializeToXML();
            ;
        }

        private static IList<string> GetDmgErrors(string resultContentXml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(resultContentXml);

            IList<string> errors = new List<string>();
            foreach (XmlNode node in xmlDoc.SelectNodes("RETURNDATA/DATA_HOTEL/MESSAGE/ERROR_DESCRIPTION"))
            {
                errors.Add(node.Value);
            }

            return errors;
        }


        public static string ProcessErrorForModel<T, U>(T travcoBookingRequestModel, string message, OTA_HotelAvailRSErrorsError error, ILogger logger)
        {
            var errorMessage = message.Replace("{0}", error.ShortText).Replace("{1}", error.Code).Replace("{2}", error.Value);

            if (travcoBookingRequestModel.GetType().Name == "HotelDescriptiveInfoRes")
            {
                return errorMessage.Replace("HotelAvailRS", "HotelDescriptiveInfoRS");
            }

            var errorHeaderInfo = ErrorHeaderInfo<U, T>(errorMessage, travcoBookingRequestModel, error);


            return ProcessError<U>(errorHeaderInfo, logger);
        }


        private static OTA_HotelAvailRSErrorsError SetError(string code, string shortText, string value, byte type)
        {
            return new OTA_HotelAvailRSErrorsError
            {
                Code = code,
                Type = type,
                ShortText = shortText,
                Value = value
            };
        }

        private static string StandardError<T, U>(string errorMessage, T travcoBookingRequestModel, ILogger logger)
        {
            var error = SetError("450", "Unable to process", "Unable to process this request", 3);

            if (travcoBookingRequestModel.GetType().Namespace.Contains("Cancellation"))
            {
                error = SetError("450", "5644", "BusinessException: Cancellation deadline of NREF has expired", 1);
            }
            else if (travcoBookingRequestModel.GetType().Namespace.Contains("Reservation"))
            {
                error = SetError("111", "booking not available", "booking request is not available", 111);
            }

            return ProcessErrorForModel<T, U>(travcoBookingRequestModel, errorMessage, error, logger);

        }

        #endregion

        #region HOTEL AVAILABILITY

        public static async Task<string> ProcessHotelAvailability(HotelAvail request, IOptions<XMLConfigOptions> config, string errorMessage, bool isResBooking, ILogger logger)
        {
            logger.LogInformation("\nProcessing ProcessHotelAvailability....");
            RETURNDATA travcoResponseModel = null;

            var travcoBookingRequestModel = TranslateXML.ToHotelAvailability(request);

            var resultContent = await SendToTalismanAndGetResponseAsync(travcoBookingRequestModel, config.Value.DMGEndpoint, logger);

            if (isResBooking)
            {
                return resultContent;
            }

            if (!string.IsNullOrEmpty(resultContent))
            {
                travcoResponseModel = resultContent.DeserializeFromXML<RETURNDATA>();
            }

            if (travcoResponseModel?.DATA == null)
            {
                logger.LogError("Hotel Availibility - DMG Response is null");
                return StandardError<BOOKING, ErrorResponse>(errorMessage, travcoBookingRequestModel, logger);
            }

            return TranslateXML.ToHISSearchAvailability(travcoResponseModel, travcoBookingRequestModel);

        }

        #endregion

        #region RESERVATIONS/BOOKING

        public static async Task<string> ProcessReservationsBooking(ReservationsMultiRoomBooking request, IOptions<XMLConfigOptions> config, string errorMessage, ILogger logger)
        {
            logger.LogInformation("\nProcessing ProcessReservationsBooking....");

            ReservationRes response = new ReservationRes
            {
                Header = new Travco.HIS.Model.Response.Reservation.EnvelopeHeader(),
                Body = new Travco.HIS.Model.Response.Reservation.EnvelopeBody
                {
                    OTA_HotelResRS = new OTA_HotelResRS
                    {
                        EchoToken = request.Body.OTA_HotelResRQ.EchoToken,
                        Target = request.Body.OTA_HotelResRQ.Target,
                        TimeStamp = DateTime.UtcNow,
                        Version = 1.000m
                    },
                    RequestId = request.Body.RequestId,
                    Transaction = "HotelResRS"
                }
            };

            logger.LogInformation("Translating to HIS to DMG in ToReservationBooking....");

            var travcoBookingRequestModel = TranslateXML.ToReservationBooking(request);

            var isPriceOk = await CheckHotelAvailablity(request, travcoBookingRequestModel, config, errorMessage, logger);
            if (isPriceOk)
            {
                Travco.HIS.Data.Response.Reservation.RETURNDATA travcoResponseModel = null;
                var resultContent = await SendToTalismanAndGetResponseAsync(travcoBookingRequestModel, config.Value.DMGEndpoint, logger);

                if (!string.IsNullOrEmpty(resultContent))
                {
                    travcoResponseModel = resultContent.DeserializeFromXML<Travco.HIS.Data.Response.Reservation.RETURNDATA>();
                }


                if (travcoResponseModel == null)
                {
                    logger.LogError("Reservaton - DMG Response is null");
                    response.Body.OTA_HotelResRS.Errors = new []
                    {
                        new OTA_Error
                        {
                            Code = 450,
                            Language = "en",
                            ShortText = "Unable to contact booking system",
                            Text = "Unable to contact booking system",
                            Type = 3
                        }
                    };
                }
                else if (!IsAnyValidData(travcoResponseModel))
                {
                    var errors = travcoResponseModel.DATA_HOTEL.Where(x => !String.IsNullOrEmpty(x.MESSAGE.ERROR_DESCRIPTION))
                        .Select(x => new OTA_Error
                        {
                            Code = 450,
                            Language = "en",
                            ShortText = x.MESSAGE.ERROR_CODE + ": " + x.MESSAGE.ERROR_DESCRIPTION,
                            Text = x.MESSAGE.ERROR_CODE + ": " + x.MESSAGE.ERROR_DESCRIPTION,
                            Type = 3
                        }).ToArray();

                    response.Body.OTA_HotelResRS.Errors = errors;
                }
                else
                {
                    // All good. Translate DMG booking into HIS format and set success flag
                    TranslateXML.ToHISReservations(request, travcoResponseModel, travcoBookingRequestModel.AdditionalInfo, response.Body.OTA_HotelResRS);
                }
            }
            else
            {
                response.Body.OTA_HotelResRS.Errors = new []
                {
                    new OTA_Error
                    {
                        Code = 450,
                        Language = "en",
                        ShortText = "No hotel rooms available at the requested price",
                        Text = "No hotel rooms available at the requested price",
                        Type = 3
                    }
                };
            }

            return response.SerializeToXML();
        }

        private static bool IsAnyValidData(Travco.HIS.Data.Response.Reservation.RETURNDATA travcoResponseModel)
        {
            foreach (var item in travcoResponseModel.DATA_HOTEL)
            {
                if (item.MESSAGE == null)
                {
                    return true;
                }
            }

            return false;
        }


        public static async Task<bool> CheckHotelAvailablity(ReservationsMultiRoomBooking request, Travco.HIS.Model.Request.DMG.Reservation.BOOKING travcoBookingRequestModel, IOptions<XMLConfigOptions> config, string errorMessage, ILogger logger)
        {
            var hotelReq = BuildHotelAvaiabilityModel(request);

            var totalPrice = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].DepositPayments.GuaranteePayment.AmountPercent.Amount;

            var isPriceOk = await IsPriceOk(request, travcoBookingRequestModel, hotelReq, totalPrice,  config, errorMessage, logger);

            return isPriceOk;
        }

        public static async Task<bool> IsPriceOk(ReservationsMultiRoomBooking request, Travco.HIS.Model.Request.DMG.Reservation.BOOKING travcoBookingRequestModel, HotelAvail hotelReq, decimal amountPercentAmount, IOptions<XMLConfigOptions> config, string errorMessage, ILogger logger)
        {
            var isValidPriceExist = false;
            var hotelIndex = 0;

            logger.LogInformation("In IsPriceOk....");

            var responseXML = await ProcessHotelAvailability(hotelReq, config, errorMessage, true, logger);

            if (responseXML.Length > 0 && !responseXML.Contains("Error"))
            {
                var responseModelHA = responseXML.DeserializeFromXML<RETURNDATA>();

                foreach (var rateplanCodeReq in request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays)
                {                    
                    foreach (var hotel in responseModelHA.DATA.HOTEL_DATA)
                    {
                        foreach (var subhotel in hotel.SubHotelData)
                        {
                            if (rateplanCodeReq.RatePlans.RatePlan.RatePlanCode == "*" || subhotel.RatePlanDetails.RatePlanCode.Equals(rateplanCodeReq.RatePlans.RatePlan.RatePlanCode))
                            {
                                travcoBookingRequestModel.DATA_HOTEL[hotelIndex++].HOTEL_CODE = subhotel.HOTEL_CODE;

                                if (!isValidPriceExist)
                                {
                                    foreach (var room in subhotel.ROOM_DATA)
                                    {
                                        if (Convert.ToDecimal(room.TOTAL_ADULT_PRICE) <= amountPercentAmount)
                                        {
                                            isValidPriceExist = true;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                return isValidPriceExist;
            }

            return isValidPriceExist;
        }

        public static HotelAvail BuildHotelAvaiabilityModel(ReservationsMultiRoomBooking request)
        {
            var roomStayCandidatesHA = RoomStayCandidatesHotelAvail(request);


            return new HotelAvail
            {
                Header = new EnvelopeHeader
                {
                    Interface = new Interface
                    {
                        ChannelIdentifierId = request.Header.Interface.ChannelIdentifierId,
                        Version = request.Header.Interface.Version,
                        ComponentInfo = new InterfaceComponentInfo
                        {
                            ComponentType = request.Header.Interface.ComponentInfo.ComponentType,
                            User = request.Header.Interface.ComponentInfo.User,
                            Pwd = request.Header.Interface.ComponentInfo.Pwd
                        }
                    }
                },
                Body = new Travco.HIS.Model.Request.HotelAvail.EnvelopeBody
                {
                    RequestId = request.Body.RequestId,
                    Transaction = "HotelAvailRQ",
                    OTA_HotelAvailRQ = new OTA_HotelAvailRQ
                    {
                        EchoToken = request.Body.OTA_HotelResRQ.EchoToken,
                        PrimaryLangID = request.Body.OTA_HotelResRQ.PrimaryLangID,
                        Target = request.Body.OTA_HotelResRQ.Target,
                        TimeStamp = request.Body.OTA_HotelResRQ.TimeStamp,
                        Version = request.Body.OTA_HotelResRQ.Version,
                        AvailRequestSegments = new OTA_HotelAvailRQAvailRequestSegments
                        {
                            AvailRequestSegment = new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegment
                            {
                                StayDateRange = new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentStayDateRange
                                {
                                    Start = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.Start,
                                    End = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.End,
                                    Duration = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.End.Subtract(request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.Start).Days.ToString()
                                },

                                RatePlanCandidates = new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidates
                                {
                                    RatePlanCandidate = new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidate
                                    {
                                        HotelRefs = new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefs
                                        {
                                            HotelRef = new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefsHotelRef
                                            {
                                                HotelCode = request.Body.OTA_HotelResRQ
                                                    .HotelReservations.HotelReservation
                                                    .RoomStays[0].BasicPropertyInfo
                                                    .HotelCode
                                            }
                                        }
                                    }
                                },
                                RoomStayCandidates = roomStayCandidatesHA

                            }
                        }
                    }
                }
            };
        }

        private static OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate[] RoomStayCandidatesHotelAvail(ReservationsMultiRoomBooking request)
        {
            var roomStayCandidatesHA = new List<OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate>();            

            for (var i = 0; i < request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays.Length; i++)
            {
                var guestCounts = new List<OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCountsGuestCount>();

                foreach(var guest in request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[i].GuestCounts)
                {
                    guestCounts.Add(new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCountsGuestCount
                    {
                        AgeQualifyingCode = guest.AgeQualifyingCode,
                        Count = guest.Count
                    });
                };

                roomStayCandidatesHA.Add(new OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate()
                {
                    RoomTypeCode = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[i].RoomTypes.RoomType.RoomTypeCode,
                    Quantity = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[i].RoomRates.RoomRate.NumberOfUnits,
                    GuestCounts = guestCounts.ToArray()
                });
            }

            return roomStayCandidatesHA.ToArray();
        }

        #endregion

        #region CANCELLATION 

        public static async Task<string> ProcessCancellation(ReservationsCancellation request, IOptions<XMLConfigOptions> config, string errorMessage, ILogger logger)
        {
            logger.LogInformation("\nProcessing ProcessCancellation....");

            var travcoBookingRequestModel = TranslateXML.ToBookingCancellation(request);

            var resultContentXml = await SendToTalismanAndGetResponseAsync(travcoBookingRequestModel, config.Value.DMGEndpoint, logger);

            ReservationsCancellationRes response = new ReservationsCancellationRes
            {
                Header = new Travco.HIS.Model.Response.Reservation.Cancellation.EnvelopeHeader(),
                Body = new Travco.HIS.Model.Response.Reservation.Cancellation.EnvelopeBody
                {
                    OTA_CancelRS = new OTA_CancelRS
                    {
                        EchoToken = request.Body.OTA_CancelRQ.EchoToken,
                        Target = request.Body.OTA_CancelRQ.Target,
                        TimeStamp = DateTime.UtcNow,
                        Version = 1.000m
                    },
                    RequestId = request.Body.RequestId,
                    Transaction = "CancelRS"
                }
            };

            var dmgErrors = GetDmgErrors(resultContentXml);

            if (dmgErrors.Count > 0)
            {
                logger.LogError("Booking Request - Error found in the Booking Request response");
                response.Body.OTA_CancelRS.Status = "Ignored";
                response.Body.OTA_CancelRS.Errors = dmgErrors.Select(x => new OTA_Error
                {
                    Language = "en",
                    Type = 3,
                    Code = 450,
                    ShortText = x
                }).ToArray();
            }
            else
            {
                var travcoResponseModel = await BookingEnquiryToHotelCancellation(resultContentXml, travcoBookingRequestModel, config, logger);
                if (travcoResponseModel.DATA_HOTEL == null || (travcoResponseModel.DATA_HOTEL?.MESSAGE != null && travcoResponseModel.DATA_HOTEL.MESSAGE.ERROR_CODE != "S10"))
                {
                    logger.LogError("Cancellation - DMG Response is null");
                    response.Body.OTA_CancelRS.Status = "Ignored";
                    response.Body.OTA_CancelRS.Errors = new[]
                    {
                        new OTA_Error
                        {
                            Language = "en",
                            Type = 3,
                            Code = 450,
                            ShortText = travcoResponseModel.DATA_HOTEL.MESSAGE.ERROR_DESCRIPTION
                        }
                    };
                }
                else
                {
                    TranslateXML.ToHISReservationsCancellation(travcoResponseModel, travcoBookingRequestModel.HishHeaderInfo, logger, response);
                }
            }

            return response.SerializeToXML();
        }

        public static async Task<RETURNDATAHB> BookingEnquiryToHotelCancellation(string resultContentXml, BookingEnquiry travcoBookingRequestModel, IOptions<XMLConfigOptions> _config, ILogger logger)
        {
            logger.LogInformation("Processing BookingEnquiryToHotelCancellation....");

            var bookingEnquiryResponseModel = resultContentXml.DeserializeFromXML<RETURNDATABE>();

            logger.LogInformation("Processing CreateHotelBookingCancellationObject....");

            var hotelBookingCancellation = TranslateXML.CreateHotelBookingCancellationObject(bookingEnquiryResponseModel, travcoBookingRequestModel);

            var hotelBookingCancellationContentXml = await SendToTalismanAndGetResponseAsync(hotelBookingCancellation, _config.Value.DMGEndpoint, logger);

            var travcoResponseModel = hotelBookingCancellationContentXml.DeserializeFromXML<RETURNDATAHB>();

            return travcoResponseModel;
        }

        #endregion

        #region CMS DESCRIPTIVE INFO

        // Generate XML Response Method
        public static string GenerateXMLFromCMS(HotelDescriptiveInfoReq request, ILogger logger, DataTable data)
        {
            logger.LogInformation("\nProcessing GenerateXMLFromCMS....");

            var hotelCode = request.Body.OTA_HotelDescriptiveInfoRQ.HotelDescriptiveInfos.HotelDescriptiveInfo.HotelCode;

            var hotelDescriptiveInfo = new HotelDescriptiveInfoRes
            {
                Header = new Travco.HIS.Model.Response.HotelDescriptiveInfo.EnvelopeHeader
                {
                    Interface = new Travco.HIS.Model.Response.HotelDescriptiveInfo.Interface
                    {
                        ChannelIdentifierId = request.Header.Interface.ChannelIdentifierId,
                        ComponentInfo = new Travco.HIS.Model.Response.HotelDescriptiveInfo.InterfaceComponentInfo
                        {
                            ComponentType = request.Header.Interface.ComponentInfo.ComponentType,
                            User = request.Header.Interface.ComponentInfo.User,
                            Pwd = request.Header.Interface.ComponentInfo.Pwd
                        },
                        Interface1 = request.Header.Interface.Interface1,
                        Version = request.Header.Interface.Version
                    }
                }
            };

            logger.LogInformation("BuildHotelDescriptiveInfoBody....");
            hotelDescriptiveInfo = BuildHotelDescriptiveInfoBody(hotelCode, request, data, hotelDescriptiveInfo);

            string result = hotelDescriptiveInfo.SerializeToXMLSOAP("", "", "soap-env");
            logger.LogInformation(result);

            return result;
        }

        private static HotelDescriptiveInfoRes BuildHotelDescriptiveInfoBody(string hotelCode, HotelDescriptiveInfoReq request, DataTable data, HotelDescriptiveInfoRes hotelDescriptiveInfo)
        {
            hotelDescriptiveInfo.Header.Interface = null;

            hotelDescriptiveInfo = new HotelDescriptiveInfoRes
            {
                Header = hotelDescriptiveInfo.Header,
                Body = new Travco.HIS.Model.Response.HotelDescriptiveInfo.EnvelopeBody
                {
                    RequestId = request.Body.RequestId,
                    Transaction = "HotelDescriptiveInfoRS",
                    OTA_HotelDescriptiveInfoRS = new OTA_HotelDescriptiveInfoRS
                    {
                        EchoToken = request.Body.OTA_HotelDescriptiveInfoRQ.EchoToken,
                        PrimaryLangID = request.Body.OTA_HotelDescriptiveInfoRQ.PrimaryLangID,
                        Target = request.Body.OTA_HotelDescriptiveInfoRQ.Target,
                        TimeStamp = request.Body.OTA_HotelDescriptiveInfoRQ.TimeStamp,
                        Version = request.Body.OTA_HotelDescriptiveInfoRQ.Version
                    }
                }
            };

            if (data.Rows.Count == 0)
            {
                hotelDescriptiveInfo.Body.OTA_HotelDescriptiveInfoRS.Errors = new OTA_Error[1]
                {
                    new OTA_Error { Code = 450, Language = "en", ShortText = "Hotel not found", Type = 3 }
                };
            }
            else
            {
                hotelDescriptiveInfo.Body.OTA_HotelDescriptiveInfoRS.Success = new object();
                hotelDescriptiveInfo.Body.OTA_HotelDescriptiveInfoRS.HotelDescriptiveContents = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContents
                {
                    HotelDescriptiveContent = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent
                    {
                        HotelCode = hotelCode,
                        TPA_Extensions = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions
                        {
                            TPA_Extension = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension
                            {
                                ID = "VQC",
                                Extension = GetExtensions(hotelCode, data, request)
                            }
                        }
                    }
                };

                if (request.Body.OTA_HotelDescriptiveInfoRQ.HotelDescriptiveInfos.HotelDescriptiveInfo.HotelInfo.SendData)
                {
                    hotelDescriptiveInfo.Body.OTA_HotelDescriptiveInfoRS.HotelDescriptiveContents.HotelDescriptiveContent.HotelInfo = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentHotelInfo
                    {
                        HotelName = data.Rows[0][HOTEL_NAME].ToString()
                    };
                }

                if (request.Body.OTA_HotelDescriptiveInfoRQ.HotelDescriptiveInfos.HotelDescriptiveInfo.ContactInfo.SendData)
                {
                    hotelDescriptiveInfo.Body.OTA_HotelDescriptiveInfoRS.HotelDescriptiveContents.HotelDescriptiveContent.ContactInfos = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfos
                    {
                        ContactInfo = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfo
                        {
                            Addresses = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddresses
                            {
                                Address = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddressesAddress
                                {
                                    AddressLine = data.Rows[0][HOTEL_ADDRESS].ToString(),
                                    CityName = data.Rows[0][CITY_NAME].ToString(),
                                    CountryName = data.Rows[0][COUNTRY_NAME].ToString()
                                }
                            }
                        }
                    };
                }
            }

            return hotelDescriptiveInfo;
        }

        private static List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension> GetExtensions(string hotelCode, DataTable data, HotelDescriptiveInfoReq request)
        {
            var extensionList = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension>
            {
                new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension
                {
                    Name = "InterfaceSetup",
                    Item = request.Body.OTA_HotelDescriptiveInfoRQ.HotelDescriptiveInfos.HotelDescriptiveInfo.AffiliationInfo.SendDistribSystems ? GetRatePlansAndRoomTypes(hotelCode, data) : null
                }
            };

            if (request.Body.OTA_HotelDescriptiveInfoRQ.HotelDescriptiveInfos.HotelDescriptiveInfo.AreaInfo.SendRefPoints)
            {
                GetExtensionsDetailsRatePlans(hotelCode, extensionList, data);

                GetExtensionsDetailsRoomTypes(hotelCode, extensionList, data);

                GetExtensionsDetailsAgeCategories(extensionList);
            }
            else
                return extensionList;

            return extensionList;
        }

        private static void GetExtensionsDetailsAgeCategories(List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension> extensionList)
        {
            var extension = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension
            {
                Name = "AgeCategories",
                Item = GetExtensionAgeCategoriesItems()
            };

            extensionList.Add(extension);
        }

        private static List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem> GetExtensionAgeCategoriesItems()
        {
            var itemList = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem>();

            var item = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem();

            item.Detail = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail>();

            var itemAges = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem();

            itemAges.Detail = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail>();

            item.Key = "ADULT";

            var detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
            {
                Key = "AgeFrom",
                Value = "12"
            };

            item.Detail.Add(detailObject);

            itemList.Add(item);

            itemAges.Key = "CHILD";

            var detailsObjectAges = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
            {
                Key = "AgeFrom",
                Value = "2"
            };

            itemAges.Detail.Add(detailsObjectAges);

            detailsObjectAges = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
            {
                Key = "AgeUntil",
                Value = "11"
            };

            itemAges.Detail.Add(detailsObjectAges);

            itemList.Add(itemAges);

            return itemList;
        }

        private static void GetExtensionsDetailsRoomTypes(string hotelCode, List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension> extensionList, DataTable data)
        {
            var extension = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension
            {
                Name = "Roomtypes",
                Item = GetExtensionRoomTypesItems(hotelCode, data)
            };

            extensionList.Add(extension);
        }

        private static List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem> GetExtensionRoomTypesItems(string hotelCode, DataTable data)
        {
            var itemList = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem>();

            var subData = ToEnumerable(data).Select(x => new Tuple<object, object, object>(x[ROOM_CODE], x[EN_ROOM_NAME], x[ROOM_PAX])).Distinct();
            foreach (var row in subData)
            {
                var item = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem();

                item.Detail = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail>();

                item.Key = row.Item1.ToString();

                var detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
                {
                    Key = "MinimumOccupancy",
                    Value = row.Item3.ToString()
                };

                item.Detail.Add(detailObject);

                detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
                {
                    Key = "MaximumOccupancy",
                    Value = row.Item3.ToString()
                };

                item.Detail.Add(detailObject);

                detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
                {
                    Key = "Caption_ENG",
                    Value = row.Item2.ToString()
                };

                item.Detail.Add(detailObject);

                detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
                {
                    Key = "Description_ENG",
                    Value = row.Item2.ToString()
                };

                item.Detail.Add(detailObject);

                itemList.Add(item);
            }

            return itemList;
        }

        private static void GetExtensionsDetailsRatePlans(string hotelCode, List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension> extensionList, DataTable data)
        {
            var extension = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension
            {
                Name = "Rateplans",
                Item = GetExtensionRatePlanItems(hotelCode, data)
            };

            extensionList.Add(extension);
        }

        private static List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem> GetExtensionRatePlanItems(string hotelCode, DataTable data)
        {
            var itemList = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem>();

            var subData = ToEnumerable(data).Select(x => new Tuple<object, object>(x[RATE_PLAN_CODE], x[RATE_PLAN_NAME])).Distinct();

            foreach (var row in subData)
            {
                var item = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem();

                item.Detail = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail>();

                item.Key = row.Item1.ToString();

                var detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
                {
                    Key = "IncludedMealplan",
                    Value = ToMealCodes(row.Item2.ToString().Split('-')[1])
                };

                item.Detail.Add(detailObject);

                detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
                {
                    Key = "Caption_ENG",
                    Value = row.Item2.ToString()
                };

                item.Detail.Add(detailObject);

                detailObject = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
                {
                    Key = "Description_ENG",
                    Value = row.Item2.ToString()
                };

                item.Detail.Add(detailObject);

                itemList.Add(item);
            }

            return itemList;
        }

        private static List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem> GetRatePlansAndRoomTypes(string hotelCode, DataTable dataTable)
        {
            var itemList = new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem>();
            var data = ToEnumerable(dataTable);

            var ratePlanCodes = data.Select(x => x[RATE_PLAN_CODE].ToString()).Distinct();
            foreach (string ratePlanCode in ratePlanCodes)
            {
                var listItemRP = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
                {
                    Key = "Mapping_Rateplan",
                    Value = ratePlanCode,
                    Text = ratePlanCode,
                };

                itemList.Add(listItemRP);
            }           

            var roomCodes = data.Select(x => x[ROOM_CODE].ToString()).Distinct();
            foreach (string roomCode in roomCodes)
            { 
                var listItemRT = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
                {
                    Key = "Mapping_Roomtype",
                    Value = roomCode,
                    Text = roomCode
                };

                itemList.Add(listItemRT);
            }

            itemList.AddRange(new List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem>
            {
                new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
                {
                    Key = "Mapping_Mealplan",
                    Value = "NOM",
                    Text = "NOM"
                },
                new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
                {
                    Key = "Mapping_Mealplan",
                    Value = "BRE",
                    Text = "BRE"
                }
            });

            var listItem = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
            {
                Key = "Mapping_AgeCategory",
                Value = "ADULT",
                Text = "1"
            };

            itemList.Add(listItem);

            listItem = new OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
            {
                Key = "Mapping_AgeCategory",
                Value = "CHILD",
                Text = "4"
            };

            itemList.Add(listItem);

            return itemList;
        }

        // Descriptive Info columns
        const int HOTEL_CODE = 0;
        const int HOTEL_NAME = 1;
        const int SUB_HOTEL_CODE = 2;
        const int HOTEL_ADDRESS = 3;
        const int CITY_NAME = 4;
        const int COUNTRY_NAME = 5;
        const int HOTEL_TELEPHONE = 6;
        const int HOTEL_EMAIL = 7;
        const int CITY_CODE = 8;
        const int RATE_PLAN_CODE = 9;
        const int RATE_PLAN_NAME = 10;
        const int ROOM_CODE = 11;
        const int EN_ROOM_NAME = 12;
        const int JP_ROOM_NAME = 13;
        const int ROOM_PAX = 14;

        #endregion

        private static IEnumerable<DataRow> ToEnumerable(DataTable data)
        {
            IList<DataRow> d = new List<DataRow>();
            foreach (DataRow dataRow in data.Rows)
                d.Add(dataRow);
            return d;
        }
    }
}
