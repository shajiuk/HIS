using System;
using Microsoft.Extensions.Logging;
using Moq;
using Travco.Helpers.HIS;
using Travco.HIS.Data.Response.Reservation;
using Travco.HIS.Model.Response.Reservation;
using Xunit;

namespace Travco.HIS.UnitTests
{
    public class TranslateXMLHotelResTests : IClassFixture<SetupFixtures>
    {
        private readonly SetupFixtures _setupFixture;
        private readonly ILogger _logger;
        public TranslateXMLHotelResTests(SetupFixtures setupFixture)
        {
            _setupFixture = setupFixture;
            _logger = new Mock<ILogger>().Object;
        }

        [Fact]
        public void Is_Serialize_To_Object_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            Assert.NotNull(hotelResObject);

            Assert.NotNull(hotelResObject.Body);

            Assert.NotNull(hotelResObject.Header);

            Assert.NotNull(hotelResObject.Header.Interface);

            Assert.NotNull(hotelResObject.Header.Interface.ComponentInfo);

            Assert.NotNull(hotelResObject.Header.Interface.ComponentInfo.ComponentType);

            Assert.NotNull(hotelResObject.Header.Interface.ChannelIdentifierId);

        }

        [Fact]
        public void Is_Date_Range_Valid_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var roomStays = hotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0];

            roomStays.TimeSpan.Start = new DateTime(2018, 8, 21);
            roomStays.TimeSpan.End = new DateTime(2018, 9, 16);

            Assert.True(roomStays.TimeSpan.End > roomStays.TimeSpan.Start);

        }

        [Fact]
        public void Is_Rateplan_Provided_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var roomStays = hotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].RatePlans;

            Assert.NotNull(roomStays.RatePlan.RatePlanCode);

            Assert.True(roomStays.RatePlan.RatePlanCode.Length>0);

        }


        [Fact]
        public void Is_HotelCode_Provided_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var roomStays = hotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0];

            Assert.NotNull(roomStays.BasicPropertyInfo.HotelCode);
        }


        [Fact]
        public void Is_MealPlanCode_Provided_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var roomStays = hotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0];

            Assert.NotNull(roomStays.RatePlans.RatePlan.MealsIncluded.MealPlanCodes);
        }

        [Fact]
        public void Is_RoomCode_Provided_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var roomStays = hotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays;

            foreach (var room in roomStays)
            {
                Assert.NotNull(room.RoomTypes.RoomType.RoomTypeCode);
                Assert.True(room.RoomTypes.RoomType.RoomTypeCode.Length > 0);
            }

        }

        [Fact]
        public void Is_GuestCount_Provided_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var roomStays = hotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays;

            foreach (var room in roomStays)
            { 
                Assert.True(room.GuestCounts[0].Count > 0);
            }
            
        }

        [Fact]
        public void Is_HIS_Translated_Correctly_To_DMG_Test()
        {
            var xml = _setupFixture.HotelResReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var hisInputToDMGObject = TranslateXML.ToReservationBooking(hotelResObject);
            hisInputToDMGObject.HEADER.INTERNAL_CODE4 = "15-Jun-2018";

            hisInputToDMGObject.HEADER.INTERNAL_CODE2 = "636646794895041907";

            var actual = hisInputToDMGObject.SerializeToXML();

            Assert.Equal(_setupFixture.HotelResInputToDMG, actual);

        }

        [Fact]
        public void Is_HIS_With_Child_Translated_Correctly_To_DMG_Test()
        {
            var xml = _setupFixture.HotelResWithChildReq;
            var hotelResObject = xml.DeserializeFromXML<ReservationsMultiRoomBooking>();

            var hisInputToDMGObject = TranslateXML.ToReservationBooking(hotelResObject);
            hisInputToDMGObject.HEADER.INTERNAL_CODE4 = "15-Jun-2018";

            hisInputToDMGObject.HEADER.INTERNAL_CODE2 = "636646794895041907";

            var actual = hisInputToDMGObject.SerializeToXML();

            Assert.Equal(_setupFixture.HotelResInputWithChildToDMG, actual);

        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_Date_Range_Test()
        {

            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            //var resultContent = HISHelpers.SendToTalismanAndGetResponseAsync(InputDMG, "http://xmlv7test.travco.co.uk/trlink/link1/show", _logger);

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();
            //var OutputDMG = resultContent.Result.DeserializeFromXML<RETURNDATA>();

            var startDateOutputDMGExpected = DateTime.Parse(OutputDMG.DATA_HOTEL[0].ARR_DATE);
            var endDateOutputDMGExpected = DateTime.Parse(OutputDMG.DATA_HOTEL[0].ARR_DATE).AddDays(Convert.ToInt32(OutputDMG.DATA_HOTEL[0].DURATION));

            var reservationRes = new OTA_HotelResRS();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo,reservationRes);

            var startDateActual = reservationRes.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.Start;
            var endDateActual = reservationRes.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.End;

            Assert.Equal(startDateOutputDMGExpected, startDateActual);
            Assert.Equal(endDateOutputDMGExpected, endDateActual);

        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_HotelCode_Test()
        {

            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            var expected = InputDMG.DATA_HOTEL[0].HOTEL_CODE;

            var reservationRes  =new OTA_HotelResRS();

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo, reservationRes);

            foreach (var hotel in OutputDMG.DATA_HOTEL)
            {
                if (expected == hotel.MainHotelCode)
                {
                    expected = hotel.HOTEL_CODE;
                }

                foreach (var room in reservationRes.HotelReservations.HotelReservation.RoomStays)
                {
                    var actual = room.BasicPropertyInfo.HotelCode;

                    Assert.Equal(actual, expected);
                }
            }
        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_RoomTypeCode_Test()
        {

            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            var expected = _setupFixture.HotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].RoomTypes.RoomType.RoomTypeCode;

            var reservationRes = new OTA_HotelResRS();

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo, reservationRes);

            foreach (var room in reservationRes.HotelReservations.HotelReservation.RoomStays)
            {
                var actual = room.RoomTypes.RoomType.RoomTypeCode;
                Assert.Equal(HISHelpers.ToRoomType(actual), HISHelpers.ToRoomType(expected));
            }

        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_RatePlanCode_Test()
        {

            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            var expected = _setupFixture.HotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].RatePlans.RatePlan.RatePlanCode;

            var reservationRes = new OTA_HotelResRS();

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo, reservationRes);

            foreach (var room in reservationRes.HotelReservations.HotelReservation.RoomStays)
            {
                var actual = room.RatePlans.RatePlan.RatePlanCode;

                if (expected.Equals("*"))
                {
                    actual = expected;
                }

                Assert.Equal(actual, expected);
            }

        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_BasePrice_Test()
        {

            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            var reservationRes = new OTA_HotelResRS();

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo, reservationRes);

            var expected = 0.0M;
            var actual = 0.0M;

            foreach (var hotel in OutputDMG.DATA_HOTEL)
            {
                foreach (var room in reservationRes.HotelReservations.HotelReservation.RoomStays)
                {
                     expected = Convert.ToDecimal(hotel.TOTAL_PRICE);

                    if (room.RatePlans.RatePlan.RatePlanCode == "*" || room.RatePlans.RatePlan.RatePlanCode == hotel.RatePlanDetails.RatePlanCode)
                    {
                         actual = Convert.ToDecimal(room.RoomRates.RoomRate.Rates[0].Base.AmountAfterTax);

                        if (expected == actual) break;

                    }
                }
                Assert.Equal(expected, actual);

            }
        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_TotalPrice_Test()
        {

            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            var reservationRes = new OTA_HotelResRS();

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo, reservationRes);

            var expected = 0.0M;
            var actual = 0.0M;

            foreach (var hotel in OutputDMG.DATA_HOTEL)
            {
                foreach (var room in reservationRes.HotelReservations.HotelReservation.RoomStays)
                {
                    expected = Convert.ToDecimal(hotel.TOTAL_PRICE);

                    if (room.RatePlans.RatePlan.RatePlanCode == "*" || room.RatePlans.RatePlan.RatePlanCode == hotel.RatePlanDetails.RatePlanCode)
                    {
                        actual = Convert.ToDecimal(room.RoomRates.RoomRate.Rates[0].Total.AmountAfterTax);

                        if (expected == actual) break;

                    }
                }
                Assert.Equal(expected, actual);

            }
        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_Timespan_Duration_Test()
        {
            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            var reservationRes = new OTA_HotelResRS();

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo, reservationRes);

            var duration = _setupFixture.HotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.End - _setupFixture.HotelResObject.Body.OTA_HotelResRQ.HotelReservations.HotelReservation.RoomStays[0].TimeSpan.Start;

            var expected = "P" + duration.Days + "N";

            foreach (var room in reservationRes.HotelReservations.HotelReservation.RoomStays)
            {
                var actual = room.TimeSpan.Duration;

                Assert.Equal(expected, actual);
            }

        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_Travco_Ref_No_Test()
        {
            var InputDMG = _setupFixture.GetHotelResTranslatedToDMG();

            var reservationRes = new OTA_HotelResRS();

            var OutputDMG = _setupFixture.HotelResDMGOutput.DeserializeFromXML<RETURNDATA>();

            TranslateXML.ToHISReservations(_setupFixture.HotelResObject, OutputDMG, InputDMG.AdditionalInfo, reservationRes);

            var actual = "";

            foreach (var hotel in OutputDMG.DATA_HOTEL)
            {
                var expected = hotel.TRAVCO_REF_NO;

                foreach (var resId in reservationRes.HotelReservations.HotelReservation.ResGlobalInfo.HotelReservationIDs)
                {
                    actual = resId.ResID_Value;

                    if (expected == actual) break;
                }
                
                Assert.Equal(expected, actual);
            }

        }
    }
}
