using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Travco.HIS.Model.Request.DMG.HotelAvail;
using Travco.HIS.Model.Request.HotelAvail;
using Travco.HIS.Model.Response.DMG.SearchAvailability;
using Travco.HIS.Model.Response.HotelAvail;
using DATA = Travco.HIS.Model.Request.DMG.HotelAvail.DATA;
using EnvelopeHeader = Travco.HIS.Model.Response.HotelAvail.EnvelopeHeader;
using Interface = Travco.HIS.Model.Response.HotelAvail.Interface;
using InterfaceComponentInfo = Travco.HIS.Model.Response.HotelAvail.InterfaceComponentInfo;

namespace Travco.Helpers.HIS
{
    public static partial class TranslateXML
    {
        #region HOTEL AVAILABILITY

        #region REQUEST
        /// <summary>
        /// HOTEL AVAILABLITY / SEARCH AVAILABILITY
        /// </summary>
        /// <param name="HISRequest"></param>
        /// <returns></returns>
        public static BOOKING ToHotelAvailability(HotelAvail HISRequest)
        {
            var mealCodeList = new List<string> {"NOM", "BRE", "BLD", "BLU"};

            var availrequestSegment = HISRequest.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            string singleRooms = null;
            string doubleRooms = null;
            string tripleRooms = null;
            string quadRooms = null;
            string extraBedForChild = null;

            BOOKING booking = new BOOKING
            {
                AGENTCODE = HISRequest.Header.Interface.ComponentInfo.User,
                AGENTPASSWORD = HISRequest.Header.Interface.ComponentInfo.Pwd, //"1234567890",
                NeedCancellationDetails = "YES",
                HishHeaderInfo = new HISHeaderInfoSA
                {
                    Header = HISRequest.Header,
                    RequestId = HISRequest.Body.RequestId,
                    Transaction = HISRequest.Body.Transaction,
                    EchoToken = HISRequest.Body.OTA_HotelAvailRQ.EchoToken,
                    PrimaryLangID = HISRequest.Body.OTA_HotelAvailRQ.PrimaryLangID,
                    Target = HISRequest.Body.OTA_HotelAvailRQ.Target,
                    Debug = HISRequest.Body.Debug
                },
                AdditionalInfo = new AdditionalInfoSA
                {
                    RatePlanCode = availrequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode,
                    MealCode = availrequestSegment.RatePlanCandidates.RatePlanCandidate.MealsIncluded != null
                        ? (mealCodeList.Contains(availrequestSegment.RatePlanCandidates.RatePlanCandidate.MealsIncluded
                            .MealPlanCodes.ToUpper())
                            ? availrequestSegment.RatePlanCandidates.RatePlanCandidate.MealsIncluded.MealPlanCodes.ToUpper()
                            : null)
                        : null
                }
            };

            MapRoomTypes(availrequestSegment, ref doubleRooms, ref singleRooms, ref extraBedForChild, ref tripleRooms, ref quadRooms);

            booking.DATA = new DATA
            {
                COUNTRY_CODE = null,
                CITY_CODE = null,
                DATE_DATA = new DATE_DATA
                {
                    CHECK_IN_DATE = availrequestSegment.StayDateRange.Start.ToString("dd/MMM/yyyy"),
                    CHECK_OUT_DATE = availrequestSegment.StayDateRange.End.ToString("dd/MMM/yyyy")
                },
                EDI_CODE = (availrequestSegment.RatePlanCandidates.RatePlanCandidate.HotelRefs.HotelRef.HotelCode.Length > 0)
                        ? availrequestSegment.RatePlanCandidates.RatePlanCandidate.HotelRefs.HotelRef.HotelCode
                        : null,
                ROOMS_DATA = new[]
                {
                    new ROOMS_DATA
                    {
                        SINGLE_ROOMS = singleRooms,
                        DOUBLE_ROOMS = doubleRooms,
                        TRIPLE_ROOMS = tripleRooms,
                        QUAD_ROOMS = quadRooms,
                        DOUBLE_EXTRA_BEDS = extraBedForChild
                    }
                }
            };

            return booking;
        }

        private static void MapRoomTypes(OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegment availrequestSegment, ref string doubleRooms, ref string singleRooms, ref string extraBedForChild, ref string tripleRooms, ref string quadRooms)
        {
            foreach(var roomStay in availrequestSegment.RoomStayCandidates)
            {
               
                var roomTypeCode = roomStay.RoomTypeCode;

                if (roomTypeCode == "*")
                {
                    singleRooms = GetRooms(roomStay);
                    doubleRooms = GetRooms(roomStay);
                    tripleRooms = GetRooms(roomStay);
                    quadRooms = GetRooms(roomStay);
                }
                else
                {
                    var roomTypeEnum = HISHelpers.ToRoomType(roomTypeCode);

                    singleRooms = (roomTypeEnum == HISHelpers.RoomType.Single)
                        ? GetRooms(roomStay)
                        : singleRooms;

                    if (roomTypeEnum == HISHelpers.RoomType.Double)
                    {
                        doubleRooms = doubleRoomsAndExtraBed(roomStay, ref extraBedForChild);
                    }

                    tripleRooms = (roomTypeEnum == HISHelpers.RoomType.Triple)
                        ? GetRooms(roomStay)
                        : tripleRooms;
                    quadRooms = (roomTypeEnum == HISHelpers.RoomType.Quad)
                        ? GetRooms(roomStay)
                        : quadRooms;
                }
            }
        }

        private static string doubleRoomsAndExtraBed(OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate roomStayCandidate, ref string extraBedForChild)
        {
            string doubleRooms = GetRooms(roomStayCandidate);

            if (doubleRooms != null)
            {
                foreach (var guest in roomStayCandidate.GuestCounts)
                {
                    if (guest.AgeQualifyingCode == 4)
                    {
                        extraBedForChild = guest.Count.ToString();
                    }
                }
            }

            return doubleRooms;
        }

        private static string GetRooms(OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate roomStayCandidate)
        {
            return roomStayCandidate.Quantity > 0 ? roomStayCandidate.Quantity.ToString() : null;
        }

        #endregion

        #region RESPONSE
        public static string ToHISSearchAvailability(RETURNDATA travcoResponseModel, BOOKING travcoBookingRequestModel)
        {

            var hisString = TranslateAndSerializeToSOAP(travcoResponseModel, travcoBookingRequestModel);

            var hotelAvailability = hisString.DeserializeFromXML<OTA_HotelAvailRQRS>();

            var HIS = hotelAvailability.SerializeToXMLSOAP("", "", "soap-env");
            var httpContent = new StringContent(HIS, Encoding.UTF8, "application/xml");

            return httpContent.ReadAsStringAsync().Result;
        }

        public static string TranslateAndSerializeToSOAP(RETURNDATA travcoResponseModel, BOOKING travcoBookingRequestModel)
        {
            var hotelAvailMain = new OTA_HotelAvailRQRS
            {
                Body = new Travco.HIS.Model.Response.HotelAvail.EnvelopeBody
                {
                    OTA_HotelAvailRS = new OTA_HotelAvailRS(),
                    RequestId = travcoBookingRequestModel.HishHeaderInfo.RequestId,
                    Transaction = travcoBookingRequestModel.HishHeaderInfo.Transaction.Replace("RQ", "RS")

                },
                Header = new EnvelopeHeader() //BuildResponseHeader(travcoBookingRequestModel.HishHeaderInfo)
            };

            OTA_HotelAvailRS hotelAvailRs = new OTA_HotelAvailRS
            {
                EchoToken = travcoBookingRequestModel.HishHeaderInfo.EchoToken,
                Target = travcoBookingRequestModel.HishHeaderInfo.Target,
                PrimaryLangID = travcoBookingRequestModel.HishHeaderInfo.PrimaryLangID,
                Success = new object(),
                RoomStays = new List<OTA_HotelAvailRSRoomStay>()

            };
            

            foreach (var hotel in travcoResponseModel.DATA.HOTEL_DATA)
            {
                foreach (var subHotel in hotel.SubHotelData)
                {
                    var boardBasis = (subHotel.RatePlanDetails.RatePlanDescription.Split('-').Length > 0) ? subHotel.RatePlanDetails.RatePlanDescription.Split('-')[1] : "";

                    var mealsIncluded = HISHelpers.ToMealCodes(boardBasis);

                    if (IsValidRate(travcoBookingRequestModel, subHotel, mealsIncluded))
                    {
                        BuildRoomData(subHotel, hotelAvailRs, travcoBookingRequestModel.AdditionalInfo, hotel, travcoBookingRequestModel.DATA.ROOMS_DATA);
                    }
                }
            }

            hotelAvailMain.Body.OTA_HotelAvailRS = hotelAvailRs;

            return hotelAvailMain.SerializeToXMLSOAP("", "", "soap-env");
        }

        private static bool IsValidRate(BOOKING travcoBookingRequestModel, SubHotelData subHotel, string mealsIncluded)
        {
            if (travcoBookingRequestModel.AdditionalInfo.RatePlanCode.Equals("*") || travcoBookingRequestModel.AdditionalInfo.RatePlanCode.Equals(subHotel.RatePlanDetails.RatePlanCode))
            {
                if (travcoBookingRequestModel.AdditionalInfo.MealCode == null || mealsIncluded.Equals(travcoBookingRequestModel.AdditionalInfo.MealCode))
                {
                    return true;
                }
            }

            return false;
        }

        public static void BuildRoomData(SubHotelData subHotel, OTA_HotelAvailRS hotelAvailRs, AdditionalInfoSA additionalInfo, HOTEL_DATA hotel, ROOMS_DATA[] roomsRequested)
        {

            foreach (var room in subHotel.ROOM_DATA)
            {
                var roomTypes = new OTA_HotelAvailRSRoomStayRoomTypes();
                var ratePlans = new OTA_HotelAvailRSRoomStayRatePlans();
                var roomRates = new List<OTA_HotelAvailRSRoomStayRoomRate>();
                var guestCounts = new OTA_HotelAvailRSRoomStayGuestCountsGuestCount[20];
                var timespan = new OTA_HotelAvailRSRoomStayTimeSpan();
                //var depositPayments = new OTA_HotelAvailRSRoomStayDepositPayments();
                var cancelPenalties = new OTA_HotelAvailRSRoomStayCancelPenalties();
                var total = new OTA_HotelAvailRSRoomStayTotal();
        
                GetRoomType(roomTypes, room, roomsRequested);

                GetRatePlan(ratePlans, subHotel, additionalInfo);

                GetRoomRate(roomRates, subHotel, room, roomsRequested);

                GetGuestCount(guestCounts, room);

                GetTimespan(timespan, roomRates);

                //GetDepositPayments(depositPayments, room);

                GetCancellationPenalties(cancelPenalties, room, subHotel);

                GetRoomStayTotal(total, roomRates[0].Rates);

                PopulateRoomStays(hotelAvailRs, roomTypes, ratePlans, roomRates, guestCounts, cancelPenalties, total, timespan, hotel);

            }

        }

        private static void GetGuestCount(OTA_HotelAvailRSRoomStayGuestCountsGuestCount[] guestCounts, ROOM_DATA room)
        {
            if (room.ROOM_PAX != null)
            {
                guestCounts[0] = new OTA_HotelAvailRSRoomStayGuestCountsGuestCount
                {
                    AgeQualifyingCode = 1,
                    Count = Convert.ToByte(room.ROOM_PAX)
                };

                // child - apply the extra beds for the double or twin rooms only
                if (room.ROOM_PAX == "2")
                {
                    if (room.NO_OF_EXTRA_BEDS != null)
                    {
                        guestCounts[1] = new OTA_HotelAvailRSRoomStayGuestCountsGuestCount
                        {
                            AgeQualifyingCode = 4,
                            Count = Convert.ToByte(room.NO_OF_EXTRA_BEDS)
                        };
                    }
                }
            }
        }

        private static void GetTimespan(OTA_HotelAvailRSRoomStayTimeSpan timespan, List<OTA_HotelAvailRSRoomStayRoomRate> roomRates)
        {
            timespan.Start = roomRates[0].EffectiveDate;

            foreach (var room in roomRates[0].Rates)
            {
                timespan.End = room.ExpireDate;
            }

            timespan.Duration = "P" + timespan.End.Subtract(timespan.Start).Days + "N";
        }

        private static void GetRoomStayTotal(OTA_HotelAvailRSRoomStayTotal total, IList<OTA_HotelAvailRSRoomStayRoomRateRate> rates)
        {
            foreach (var rate in rates)
            {
                total.AmountAfterTax += rate.Total.AmountAfterTax;
                total.AmountBeforeTax += rate.Total.AmountBeforeTax;
                total.DecimalPlaces = rate.Total.DecimalPlaces;
                total.CurrencyCode = rate.Total.CurrencyCode;
            }
        }

        private static void GetCancellationPenalties(OTA_HotelAvailRSRoomStayCancelPenalties cancelPenalties, ROOM_DATA room, SubHotelData subHotel)
        {
            if (!string.IsNullOrEmpty(room.CCHARGES_CODE))
            {
                if (subHotel.CancellationDetails != null)
                    cancelPenalties.CancelPenalty = new OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenalty
                    {
                        PolicyCode = "CXP", //room.CCHARGES_CODE,
                        Deadline = new OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyDeadline
                        {
                            AbsoluteDeadline = Convert.ToDateTime(subHotel.CancellationDetails.FULL_CANCELLATION_DETAILS.DETAILS.MESSAGE.LAST_DATE_BY_WHICH_TO_CANCEL + " " + subHotel.CancellationDetails.FULL_CANCELLATION_DETAILS.DETAILS.MESSAGE.TIME_BEFORE ),
                            OffsetTimeUnit = "Day",
                            OffsetUnitMultiplier = subHotel.CancellationDetails.FULL_CANCELLATION_DETAILS.DETAILS.NO_OF_DAYS_BEFORE_ARRIVAL
                        },
                        AmountPercent = new OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyAmountPercent
                        {
                            NmbrOfNights = 1
                        }
                    };
            }
        }

        private static void GetDepositPayments(OTA_HotelAvailRSRoomStayDepositPayments depositPayments, ROOM_DATA room)
        {
            if (!string.IsNullOrEmpty(room.CCHARGES_CODE))
            {
                depositPayments.GuaranteePayment = new OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePayment
                {                    
                    AmountPercent = new OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePaymentAmountPercent
                    {
                        NmbrOfNights = 0,
                        Percent = 100
                    }

                };
            }
        }

        private static void GetRoomRate(List<OTA_HotelAvailRSRoomStayRoomRate> roomRates, SubHotelData subHotel, ROOM_DATA room, ROOMS_DATA[] roomsRequested)
        {
            var adultPriceDetails = room.ADULT_PRICE_DETAILS.Split(' ');
            var startDate = new DateTime();
            var endDate = new DateTime();
            var numNights = 0;

            if (adultPriceDetails.Length > 0)
            {
                startDate = Convert.ToDateTime(adultPriceDetails[0]);
                numNights = Convert.ToInt32(adultPriceDetails[1].Remove(adultPriceDetails[1].IndexOf("n")));
                endDate = startDate.AddDays(numNights);
            }

            var rateSplitsAdults = room.ADULT_PRICE_DETAILS.Split(';');
            var rateChilden = room.CHILD_PRICE_DETAILS?.Contains("@") == true ? room.CHILD_PRICE_DETAILS.Split('@')[1] : "0";

            var roomStayRoomRate = new OTA_HotelAvailRSRoomStayRoomRate
            {
                RatePlanCode = subHotel.RatePlanDetails.RatePlanCode,
                RoomTypeCode = room.ROOM_CODE,

                NumberOfUnits = HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Single
                                ? roomsRequested[0].SINGLE_ROOMS
                                : HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Double
                                    ? roomsRequested[0].DOUBLE_ROOMS
                                    : HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Triple
                                        ? roomsRequested[0].TRIPLE_ROOMS
                                        : HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Quad
                                            ? roomsRequested[0].QUAD_ROOMS
                                            : null,

                EffectiveDate = startDate,
                ExpireDate = endDate,
                Rates = new List<OTA_HotelAvailRSRoomStayRoomRateRate>()
            };            

            for (var index = 0; index < rateSplitsAdults.Length; index++)
            {
                if (!rateSplitsAdults[index].Contains("Free"))
                {
                    var splits = rateSplitsAdults[index];
                    roomStayRoomRate.Rates.Add(Rate(subHotel, numNights, splits, rateChilden));
                }
            }

            roomRates.Add(roomStayRoomRate);
        }

        private static OTA_HotelAvailRSRoomStayRoomRateRate Rate(SubHotelData subHotel, int numNights, string splits, string rateChilden)
        {

            var datePrice = splits.Split(' ');
            var date = Convert.ToDateTime(datePrice[0]);

            var nights = ParsePriceText(datePrice, out var price);

            return new OTA_HotelAvailRSRoomStayRoomRateRate
            {
                EffectiveDate = date,
                ExpireDate = Convert.ToDateTime(date).AddDays(nights),
                RateTimeUnit = "Day",
                Base = new OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateBase
                {
                    AmountAfterTax = Convert.ToDecimal(price) + Convert.ToDecimal(rateChilden),
                    AmountBeforeTax = Convert.ToDecimal(price) + Convert.ToDecimal(rateChilden), //room.CHILD_PRICE,
                    CurrencyCode = subHotel.CURRENCY_CODE,
                    DecimalPlaces = 0
                },
                Total = new OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateTotal
                {
                    AmountAfterTax = Convert.ToDecimal(price) *  numNights + Convert.ToDecimal(rateChilden) * numNights,
                    AmountBeforeTax = Convert.ToDecimal(price) * numNights + Convert.ToDecimal(rateChilden) * numNights,
                    CurrencyCode = subHotel.CURRENCY_CODE,
                    DecimalPlaces = 0
                }
            };

        }

        public static int ParsePriceText(string[] datePrice, out string price)
        {
            var nightsPrice = datePrice[1].Split('@');
            var nights = Convert.ToInt32(nightsPrice[0].Replace("nts", "").Replace("nt", ""));
            price = nightsPrice[1];
            return nights;
        }

        private static void GetRatePlan(OTA_HotelAvailRSRoomStayRatePlans ratePlans, SubHotelData subHotel, AdditionalInfoSA additionalInfo)
        {
            if (subHotel.RatePlanDetails.RatePlanDescription != null)
            {
                ratePlans.RatePlan = new OTA_HotelAvailRSRoomStayRatePlansRatePlan
                {
                    MealsIncluded = new OTA_HotelAvailRSRoomStayRatePlansRatePlanMealsIncluded
                    {
                        MealPlanCodes = HISHelpers.ToMealCodes(subHotel.RatePlanDetails.RatePlanDescription.Split('-')[1])
                    }
                };

                if (additionalInfo.RatePlanCode == subHotel.RatePlanDetails.RatePlanCode || additionalInfo.RatePlanCode == "*")
                {
                    ratePlans.RatePlan.RatePlanCode = subHotel.RatePlanDetails.RatePlanCode;
                    ratePlans.RatePlan.RatePlanDescription = new OTA_HotelAvailRSRoomStayRatePlansRatePlanRatePlanDescription
                    {
                        Name = subHotel.RatePlanDetails.RatePlanDescription
                    };
                }
            }
        }

        private static void GetRoomType(OTA_HotelAvailRSRoomStayRoomTypes roomTypes, ROOM_DATA room, ROOMS_DATA[] roomsRequested)
        {
            roomTypes.RoomType = new OTA_HotelAvailRSRoomStayRoomTypesRoomType
            {
                RoomTypeCode = room.ROOM_CODE,

                NumberOfUnits = HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Single
                                ? roomsRequested[0].SINGLE_ROOMS
                                : HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Double
                                    ? roomsRequested[0].DOUBLE_ROOMS
                                    : HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Triple
                                        ? roomsRequested[0].TRIPLE_ROOMS
                                        : HISHelpers.ToRoomType(room.ROOM_CODE) == HISHelpers.RoomType.Quad
                                            ? roomsRequested[0].QUAD_ROOMS
                                            : null,

                RoomDescription = new OTA_HotelAvailRSRoomStayRoomTypesRoomTypeRoomDescription
                {
                    Text = room.ROOM_NAME
                }
            };

        }

        private static void PopulateRoomStays(OTA_HotelAvailRS hotelAvailRs, OTA_HotelAvailRSRoomStayRoomTypes roomTypes, OTA_HotelAvailRSRoomStayRatePlans ratePlans, 
            List<OTA_HotelAvailRSRoomStayRoomRate> roomRates, OTA_HotelAvailRSRoomStayGuestCountsGuestCount[] guestCounts, OTA_HotelAvailRSRoomStayCancelPenalties cancelPenalties, 
            OTA_HotelAvailRSRoomStayTotal total,OTA_HotelAvailRSRoomStayTimeSpan timespan, HOTEL_DATA hotel)
        {
            hotelAvailRs.RoomStays.Add(new OTA_HotelAvailRSRoomStay
                {
                    RoomTypes = roomTypes,
                    RatePlans = ratePlans,
                    RoomRates = roomRates,
                    GuestCounts = guestCounts,
                    TimeSpan = timespan,
                    //DepositPayments = depositPayments,
                    CancelPenalties = cancelPenalties,
                    Total = total,

                    BasicPropertyInfo = new OTA_HotelAvailRSRoomStayBasicPropertyInfo
                    {
                        HotelCode = hotel.HOTEL_CODE
                    }
                }
            );
        }

        private static EnvelopeHeader BuildResponseHeader(HISHeaderInfoSA headerInfo)
        {

            var header = new EnvelopeHeader()
            {
                Interface = new Interface
                {
                    ChannelIdentifierId = headerInfo.Header.Interface.ChannelIdentifierId,
                    Version = headerInfo.Header.Interface.Version,
                    Interface1 = headerInfo.Header.Interface.Interface1,
                    ComponentInfo = new InterfaceComponentInfo
                    {
                        ComponentType = headerInfo.Header.Interface.ComponentInfo.ComponentType,
                        User = headerInfo.Header.Interface.ComponentInfo.User,
                        Pwd = headerInfo.Header.Interface.ComponentInfo.Pwd
                    }
                }
            };

            return header;
        }
        #endregion

        #endregion

        public static PropertyInfo SetProperty(PropertyInfo prop, object value)
        {
            switch (prop.PropertyType.Name)
            {
                case "Int32":
                    prop.SetValue(prop, Convert.ToInt32(value));
                    break;
                default:
                    prop.SetValue(prop, value.ToString());
                    break;
            }

            return prop;
        }
    }
}
