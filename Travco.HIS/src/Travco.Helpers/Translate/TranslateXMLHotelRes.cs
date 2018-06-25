using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Travco.HIS.Model.Request.DMG.Reservation;
using Travco.HIS.Model.Request.DMG.Reservation.Cancellation;
using Travco.HIS.Model.Request.Reservation;
using Travco.HIS.Model.Response.Reservation;
using Travco.HIS.Model.Response.Reservation.Cancellation;
using BookingReservationDMG = Travco.HIS.Model.Request.DMG.Reservation.BOOKING;
using EnvelopeHeaderReservation = Travco.HIS.Model.Response.Reservation.EnvelopeHeader;
using ReturnDataReservationDMG = Travco.HIS.Data.Response.Reservation.RETURNDATA;
using static Travco.HIS.Model.Request.DMG.Reservation.BOOKING;
using DATA_HOTEL = Travco.HIS.Data.Response.Reservation.DATA_HOTEL;
using Interface = Travco.HIS.Model.Response.Reservation.Interface;
using InterfaceComponentInfo = Travco.HIS.Model.Response.Reservation.InterfaceComponentInfo;

namespace Travco.Helpers.HIS
{
    public static partial class TranslateXML
    {
        #region RESERVATION/BOOKING

        #region REQUEST
        /// <summary>
        /// RESERVATIONS
        /// </summary>
        /// <param name="headerInfo"></param>
        /// <returns></returns>
        public static BookingReservationDMG ToReservationBooking(ReservationsMultiRoomBooking HISRequest)
        {
            var booking = new BookingReservationDMG
            {
                AGENTCODE = HISRequest.Header.Interface.ComponentInfo.User,
                AGENTPASSWORD = HISRequest.Header.Interface.ComponentInfo.Pwd, //"1234567890",
                HishHeaderInfo = new HISHeaderInfoRes
                {
                    Header = HISRequest.Header,
                    RequestId = HISRequest.Body.RequestId,
                    Transaction = HISRequest.Body.Transaction,
                    EchoToken = HISRequest.Body.OTA_HotelResRQ.EchoToken,
                    PrimaryLangID = HISRequest.Body.OTA_HotelResRQ.PrimaryLangID,
                    Target = HISRequest.Body.OTA_HotelResRQ.Target
                },
                AdditionalInfo = new AdditionalInfoRes
                {
                    RoomStays = HISRequest.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays
                },
                type = "HB",
                lang = !HISRequest.Body.OTA_HotelResRQ.PrimaryLangID.Contains("-GB") ? HISRequest.Body.OTA_HotelResRQ.PrimaryLangID + "-GB" : HISRequest.Body.OTA_HotelResRQ.PrimaryLangID,
                returnURLNeed = BOOKINGReturnURLNeed.no,
                returnURL = "http://"
            };

            var ran = new Random();

            booking.HEADER = new HEADER
            {
                INTERNAL_CODE1 = "DWEBCN",
                INTERNAL_CODE2 = DateTime.Now.Ticks.ToString(),
                INTERNAL_CODE4 = DateTime.Today.ToString("dd-MMM-yyyy"),
                INTERNAL_CODE5 = "DWEBRS",
                INTERNAL_CODE6 = "",
                INTERNAL_CODE7 = "1",
                INTERNAL_CODE8 = "VB",
                INTERNAL_CODE9 = "travel System"
            };

            var hotelReservation = HISRequest.Body.OTA_HotelResRQ.HotelReservations.HotelReservation;

            var dataHotel = new List<Travco.HIS.Model.Request.DMG.Reservation.DATA_HOTEL>();            
            
            foreach (var room in hotelReservation.RoomStays)
            {
                dataHotel.Add(new Travco.HIS.Model.Request.DMG.Reservation.DATA_HOTEL
                {
                    ROOM_CODE = room.RoomTypes.RoomType.RoomTypeCode,
                    ADULTS = NumOfGuests(room, true),
                    CHILDREN = NumOfGuests(room, false),
                    ARR_DATE = room.TimeSpan.Start.ToString("dd-MMM-yyyy"),
                    DURATION = room.TimeSpan.End.Subtract(room.TimeSpan.Start).Days.ToString(),
                    HOTEL_CODE = room.BasicPropertyInfo.HotelCode,
                    STATUS = "B",
                    INTERNAL_CODE10 = "1",
                    INTERNAL_CODE11 = "1",
                    PAX_NAME = GetResGuestDetails(hotelReservation.ResGuests, room.ResGuestRPHs.ResGuestRPH.RPH),
                    OUR_REF_NO = HISRequest.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.UniqueID.ID,
                    HOTEL_REQUEST = room.SpecialRequests != null ? ToDMGSpecialRequests(room.SpecialRequests.SpecialRequest.Text) : null,
                    RatePlanCode = room.RatePlans.RatePlan.RatePlanCode
                });

            }

            booking.DATA_HOTEL = dataHotel.ToArray();

            return booking;
        }


        private static string ToDMGSpecialRequests(string hisSpecialrequest)
        {
            switch (hisSpecialrequest.ToLower())
            {
                case "non-smoking":
                    return "Non-Smoking Room (Request Only)";

                case "smoking":
                    return "Smoking Room (Request Only)";

                case "honeymoon":
                    return "Honeymooners";

                default:
                    return null;
            }
        }


        private static string NumOfGuests(OTA_HotelResRQHotelReservationsHotelReservationRoomStay room, bool adult)
        {
            foreach (OTA_HotelResRQHotelReservationsHotelReservationRoomStayGuestCountsGuestCount guest in room.GuestCounts)
            {
                if (adult)
                {
                    if (guest.AgeQualifyingCode == 1)
                    {
                        return guest.Count.ToString();
                    }
                }
                else
                {
                    if (guest.AgeQualifyingCode == 4)
                    {
                        return guest.Count.ToString();
                    }
                }
            }

            return null;
        }

        public static string GetResGuestDetails(OTA_HotelResRQHotelReservationsHotelReservationResGuest[] resGuests, byte rphId)
        {
            foreach (var resGuest in resGuests)
            {
                if (resGuest.ResGuestRPH == rphId)
                {
                    return resGuest.Profiles.ProfileInfo.Profile.Consumer.PersonName.Surname + "/" +
                           resGuest.Profiles.ProfileInfo.Profile.Consumer.PersonName.GivenName;
                }
            }

            return null;
        }

        #endregion

        #region RESPONSE

        public static void ToHISReservations(ReservationsMultiRoomBooking request, ReturnDataReservationDMG travcoResponseModel, AdditionalInfoRes additionalInfoRes, OTA_HotelResRS response)
        {
            response.Success = new object();
            response.HotelReservations = new OTA_HotelResRSHotelReservations
            {
                HotelReservation = new OTA_HotelResRSHotelReservationsHotelReservation
                {
                    CreateDateTime = DateTime.Now,
                    RoomStays = GetRoomStays(travcoResponseModel, additionalInfoRes),
                    ResGlobalInfo = GetResGlobalInfo(request, travcoResponseModel)
                }
            };
        }

        private static List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay> GetRoomStays(ReturnDataReservationDMG travcoResponseModel, AdditionalInfoRes additionalInfoRes)
        {
            var roomStays = new List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay>();            

            for (var i = 0; i < travcoResponseModel.DATA_HOTEL.Length; i++)
            {
                var dataHotel = travcoResponseModel.DATA_HOTEL[i];

                if (dataHotel.MESSAGE == null && (additionalInfoRes.RoomStays[i].RatePlans.RatePlan.RatePlanCode == "*" || 
                     dataHotel.TOTAL_PRICE <= additionalInfoRes.RoomStays[i].DepositPayments.GuaranteePayment.AmountPercent.Amount 
                    && dataHotel.RatePlanDetails.RatePlanCode.Equals(additionalInfoRes.RoomStays[i].RatePlans.RatePlan.RatePlanCode)))
                {
                    var roomStay = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay
                    {
                        RoomTypes = GetRoomTypes(dataHotel, additionalInfoRes.RoomStays[i]),
                        RatePlans = GetRatePlans(dataHotel),
                        RoomRates = GetRoomRates(dataHotel),
                        GuestCounts = GetGuestCounts(dataHotel),
                        TimeSpan = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTimeSpan
                        {
                            Start = Convert.ToDateTime(dataHotel.ARR_DATE),
                            End = Convert.ToDateTime(dataHotel.ARR_DATE).AddDays(Convert.ToInt32(dataHotel.DURATION)),
                            Duration = "P" + dataHotel.DURATION + "N"
                        },
                        //DepositPayments = GetDepositPayments(),
                        CancelPenalties = GetCancelPenalties(dataHotel),
                        Total = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTotal
                        {
                            AmountBeforeTax = dataHotel?.TOTAL_PRICE.ToString(),
                            AmountAfterTax = dataHotel?.TOTAL_PRICE.ToString(),
                            DecimalPlaces = 0,
                            CurrencyCode = dataHotel?.CURR_CODE
                        },
                        BasicPropertyInfo = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayBasicPropertyInfo
                        {
                                HotelCode = dataHotel?.HOTEL_CODE
                        }
                    };

                    roomStays.Add(roomStay);
                }
            }

            return roomStays;
  
        }

        private static OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfo GetResGlobalInfo(ReservationsMultiRoomBooking request, ReturnDataReservationDMG dmgData)
        {

            var resList = new List<OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfoHotelReservationID>();

            // send back deafult original HIS references
            var resHISItem = new OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfoHotelReservationID
            {
                ResID_Type = 14,
                ResID_Value = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.UniqueID.ID,
                ResID_Source = "HIS_TOKYO",
                ResID_Date = request.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.CreateDateTime
            };

            resList.Add(resHISItem);

            // send Travco references
            foreach (var resId in dmgData.DATA_HOTEL)
            {
                var resItem = new OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfoHotelReservationID
                {
                    ResID_Type = 14,
                    ResID_Value = resId.TRAVCO_REF_NO,
                    ResID_Source = request.Header.Interface.ComponentInfo.User,
                    ResID_Date = DateTime.UtcNow
                };

                resList.Add(resItem);
            }

            var resGlobalInfo = new OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfo
            {
                HotelReservationIDs = resList.ToArray()
            };

            return resGlobalInfo;
        }

        private static OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenalties GetCancelPenalties(DATA_HOTEL dataHotel)
        {

            var nights =dataHotel.FULL_CANCELLATION_DETAILS?.Length > 0 && dataHotel.FULL_CANCELLATION_DETAILS[0].CANCELLATION_CHARGE.Length > 0
                    ? dataHotel.FULL_CANCELLATION_DETAILS[0].CANCELLATION_CHARGE[0].Split('-')[1].Split('x')[0].Replace(" Nt ", "").TrimStart()
                    : "0";

            var percentage = dataHotel.FULL_CANCELLATION_DETAILS?.Length > 0 && dataHotel.FULL_CANCELLATION_DETAILS[0].CANCELLATION_CHARGE.Length > 0
                    ? dataHotel.FULL_CANCELLATION_DETAILS[0].CANCELLATION_CHARGE[0].Split('-')[1].Split('x')[1].Replace("%", "").TrimStart()
                    : "0";


            return new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenalties
            {
                CancelPenalty = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenalty
                {
                    PolicyCode = "CXP",
                    Deadline = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyDeadline
                    {
                        OffsetTimeUnit = "Day",
                        OffsetUnitMultiplier = Convert.ToByte(nights)
                    },
                    AmountPercent = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyAmountPercent
                    {
                        Percent = Convert.ToByte(Convert.ToDecimal(percentage))
                    }
                }
            };
        }

        private static OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments GetDepositPayments()
        {
            return new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments
            {
                GuaranteePayment = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePayment
                {
                    AmountPercent = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAmountPercent
                    {
                        Percent = 100
                    }
                }
            };
        }

        private static OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayGuestCount[] GetGuestCounts(DATA_HOTEL dataHotel)
        {
            return new[]
            {
                new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayGuestCount
                {
                    AgeQualifyingCode = 1,
                    Count = Convert.ToByte(dataHotel.ADULTS)
                },
                (dataHotel.CHILDREN != null) ? 
                new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayGuestCount
                {
                    AgeQualifyingCode = 4,
                    Count = (dataHotel.CHILDREN != null) ? Convert.ToByte(dataHotel.CHILDREN) : Convert.ToByte(0)
                }: null
            };
        }


        private static OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRates GetRoomRates(DATA_HOTEL dataHotel)
        {
            return new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRates
            {
                RoomRate = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRate
                {
                    NumberOfUnits = Convert.ToByte(dataHotel.NO_OF_ROOMS),
                    EffectiveDate = Convert.ToDateTime(dataHotel.ARR_DATE),
                    ExpireDate = Convert.ToDateTime(dataHotel.ARR_DATE).AddDays(Convert.ToInt32(dataHotel.DURATION)),
                    RoomTypeCode = dataHotel?.ROOM_CODE,
                    RatePlanCode = dataHotel?.RatePlanDetails?.RatePlanCode,
                    Rates = GetRates(dataHotel)
                }
            };
        }
        
        private static List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate> GetRates(DATA_HOTEL dataHotel)
        {
            return new List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate>
            {
                // Need to confirm how base price really works, since it had previously been commented out as:
                // "Removed until confirmation with HIS as this will require a lot of work to breakdown by different date rates"
                new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate
                {
                    Base = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase
                    {
                        AmountAfterTax = dataHotel.TOTAL_PRICE,
                        AmountBeforeTax = dataHotel.TOTAL_PRICE,
                        CurrencyCode = dataHotel.CURR_CODE,
                        DecimalPlaces = 0
                    },
                    EffectiveDate = Convert.ToDateTime(dataHotel.ARR_DATE),
                    ExpireDate = Convert.ToDateTime(dataHotel.ARR_DATE).AddDays(Convert.ToInt32(dataHotel.DURATION)),
                    RateTimeUnit = "Day",
                    Total = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal
                    {
                        AmountAfterTax = dataHotel.TOTAL_PRICE,
                        AmountBeforeTax = dataHotel.TOTAL_PRICE,
                        CurrencyCode = dataHotel.CURR_CODE,
                        DecimalPlaces = 0
                    }
                }
            };
        }

        private static OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate GetRate(DATA_HOTEL dataHotel)
        {
            // As above, need some details on Base pricing ...
            return new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate
            {
                EffectiveDate = Convert.ToDateTime(dataHotel.ARR_DATE),
                ExpireDate = Convert.ToDateTime(dataHotel.ARR_DATE).AddDays(Convert.ToInt32(dataHotel.DURATION)),
                RateTimeUnit = "Day",
                Base = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase
                {
                    AmountAfterTax = dataHotel.TOTAL_PRICE,
                    AmountBeforeTax = dataHotel.TOTAL_PRICE, //room.CHILD_PRICE,
                    CurrencyCode = dataHotel.CURR_CODE,
                    DecimalPlaces = 0
                },
                Total = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal
                {
                    AmountAfterTax = dataHotel.TOTAL_PRICE,
                    AmountBeforeTax = dataHotel.TOTAL_PRICE, //room.CHILD_PRICE,
                    CurrencyCode = dataHotel.CURR_CODE,
                    DecimalPlaces = 0
                }
            };
        }

        private static OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlans GetRatePlans(DATA_HOTEL dataHotel)
        {
            var boardBasis = (dataHotel.RatePlanDetails != null && dataHotel.RatePlanDetails.RatePlanDescription.Split('-').Length > 0) ? dataHotel.RatePlanDetails.RatePlanDescription.Split('-')[1] : "";

            var mealsIncluded = HISHelpers.ToMealCodes(boardBasis);


            return new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlans
            {
                RatePlan = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlan
                {
                    RatePlanCode = dataHotel.RatePlanDetails?.RatePlanCode,
                    RatePlanDescription = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanRatePlanDescription
                    {
                        Name = dataHotel.RatePlanDetails?.RatePlanDescription
                    },
                    MealsIncluded = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanMealsIncluded
                    {
                        MealPlanCodes = mealsIncluded

                    }

                }
            };
        }

        private static OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes GetRoomTypes(DATA_HOTEL dataHotel, OTA_HotelResRQHotelReservationsHotelReservationRoomStay roomStay)
        {

            var roomCodeReq = HISHelpers.ToRoomType(roomStay.RoomTypes.RoomType.RoomTypeCode);
            var roomCodeRes = HISHelpers.ToRoomType(dataHotel.ROOM_CODE);

            if (!roomCodeReq.Equals(roomCodeRes)) return null;

            return new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes
            {
                RoomType = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomType
                {
                    RoomTypeCode = dataHotel.ROOM_CODE,
                    RoomDescription = new OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomTypeRoomDescription
                    {
                        Text = dataHotel.ROOM_NAME
                    },
                    NumberOfUnits = Convert.ToByte(dataHotel.NO_OF_ROOMS)
                }
            };
        }

        #endregion

        #endregion
    }
}
