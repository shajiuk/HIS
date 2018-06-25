using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Travco.Helpers.HIS;
using Travco.HIS.Model.Request.HotelAvail;
using Travco.HIS.Model.Response.DMG.SearchAvailability;
using Travco.HIS.Model.Response.HotelAvail;
using Xunit;

namespace Travco.HIS.UnitTests
{
    public class TranslateXMLHotelAvailTests : IClassFixture<SetupFixtures>
    {
        private readonly SetupFixtures _setupFixture;
        private readonly ILogger _logger;
        public TranslateXMLHotelAvailTests(SetupFixtures setupFixture)
        {
            _setupFixture = setupFixture;
            _logger = new Mock<ILogger>().Object;
        }

        [Fact]
        public void Is_Serialize_To_Object_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            Assert.NotNull(hotelAvailObject);

            Assert.NotNull(hotelAvailObject.Body);

            Assert.NotNull(hotelAvailObject.Header);

            Assert.NotNull(hotelAvailObject.Header.Interface);

            Assert.NotNull(hotelAvailObject.Header.Interface.ComponentInfo);

            Assert.NotNull(hotelAvailObject.Header.Interface.ComponentInfo.ComponentType);

            Assert.NotNull(hotelAvailObject.Header.Interface.ChannelIdentifierId);

        }

        [Fact]
        public void Is_Date_Range_Valid_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var availReqSeg = hotelAvailObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            availReqSeg.StayDateRange.Start = new DateTime(2018, 8, 21);
            availReqSeg.StayDateRange.End = new DateTime(2018, 9, 16);

            Assert.True(availReqSeg.StayDateRange.End > availReqSeg.StayDateRange.Start);

        }

        [Fact]
        public void Is_Rateplan_Provided_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var availReqSeg = hotelAvailObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            Assert.NotNull(availReqSeg.RatePlanCandidates.RatePlanCandidate.RatePlanCode);

            Assert.True(availReqSeg.RatePlanCandidates.RatePlanCandidate.RatePlanCode.Length>0);

        }


        [Fact]
        public void Is_HotelCode_Provided_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var availReqSeg = hotelAvailObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            Assert.NotNull(availReqSeg.RatePlanCandidates.RatePlanCandidate.HotelRefs.HotelRef.HotelCode);
        }


        [Fact]
        public void Is_MealPlanCode_Provided_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var availReqSeg = hotelAvailObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            Assert.NotNull(availReqSeg.RatePlanCandidates.RatePlanCandidate.MealsIncluded.MealPlanCodes);
        }

        [Fact]
        public void Is_RoomCode_Provided_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var availReqSeg = hotelAvailObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            foreach (var room in availReqSeg.RoomStayCandidates)
            {
                Assert.NotNull(room.RoomTypeCode);
                Assert.True(room.RoomTypeCode.Length > 0);
            }

        }

        [Fact]
        public void Is_Quantity_Provided_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var availReqSeg = hotelAvailObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            foreach (var room in availReqSeg.RoomStayCandidates)
            {
                Assert.True(room.Quantity > 0);
            }
            
        }

        [Fact]
        public void Is_HIS_Translated_Correctly_To_DMG_Test()
        {
            var xml = _setupFixture.HotelAvailReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var actual = TranslateXML.ToHotelAvailability(hotelAvailObject).SerializeToXML();

            Assert.Equal(_setupFixture.HotelAvailInputToDMG, actual);

        }

        [Fact]
        public void Is_HIS_With_Child_Translated_Correctly_To_DMG_Test()
        {
            var xml = _setupFixture.HotelAvailWithChildReq;
            var hotelAvailObject = xml.DeserializeFromXML<HotelAvail>();

            var actual = TranslateXML.ToHotelAvailability(hotelAvailObject).SerializeToXML();

            Assert.Equal(_setupFixture.HotelAvailInputWithChildToDMG, actual);

        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_Date_Range_Test()
        {

            var InputDMG = _setupFixture.GetHotelAvailTranslatedToDMG();

            var OutputDMG = _setupFixture.HotelAvailDMGOutput.DeserializeFromXML<RETURNDATA>();

            var startDateOutputDMGExpected = DateTime.Parse(OutputDMG.DATA.CHECK_IN_DATE);
            var endDateOutputDMGExpected = DateTime.Parse(OutputDMG.DATA.CHECK_OUT_DATE);


            var translatedToHIS = TranslateXML.ToHISSearchAvailability(OutputDMG, InputDMG).DeserializeFromXML<OTA_HotelAvailRQRS>();

            var startDateActual = translatedToHIS.Body.OTA_HotelAvailRS.RoomStays[0].TimeSpan.Start;
            var endDateActual = translatedToHIS.Body.OTA_HotelAvailRS.RoomStays[0].TimeSpan.End;

            Assert.Equal(startDateActual, startDateOutputDMGExpected);
            Assert.Equal(endDateActual, endDateOutputDMGExpected);

        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_HotelCode_Test()
        {
            var InputDMG = _setupFixture.GetHotelAvailTranslatedToDMG();

            var expected = InputDMG.DATA.EDI_CODE;

            var OutputDMG = _setupFixture.HotelAvailDMGOutput.DeserializeFromXML<RETURNDATA>();

            var translatedToHIS = TranslateXML.ToHISSearchAvailability(OutputDMG, InputDMG).DeserializeFromXML<OTA_HotelAvailRQRS>();

            var actual = translatedToHIS.Body.OTA_HotelAvailRS.RoomStays[0].BasicPropertyInfo.HotelCode;

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_RoomTypeCode_Test()
        {

            var InputDMG = _setupFixture.GetHotelAvailTranslatedToDMG();

            var expected = _setupFixture.HotelAvailHISReqObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment.RoomStayCandidates[0].RoomTypeCode;

            var OutputDMG = _setupFixture.HotelAvailDMGOutput.DeserializeFromXML<RETURNDATA>();

            var translatedToHIS = TranslateXML.ToHISSearchAvailability(OutputDMG, InputDMG).DeserializeFromXML<OTA_HotelAvailRQRS>();

            foreach (var room in translatedToHIS.Body.OTA_HotelAvailRS.RoomStays)
            {
                var actual = room.RoomTypes.RoomType.RoomTypeCode;
                Assert.Equal(HISHelpers.ToRoomType(actual), HISHelpers.ToRoomType(expected));
            }
            
        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_RatePlanCode_Test()
        {

            var InputDMG = _setupFixture.GetHotelAvailTranslatedToDMG();

            var expected = _setupFixture.HotelAvailHISReqObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode;

            //var resultContent = HISHelpers.SendToTalismanAndGetResponseAsync(InputDMG, "http://xmlv7test.travco.co.uk/trlink/link1/show", _logger);
            var OutputDMG = _setupFixture.HotelAvailDMGOutput.DeserializeFromXML<RETURNDATA>();

            var translatedToHIS = TranslateXML.ToHISSearchAvailability(OutputDMG, InputDMG).DeserializeFromXML<OTA_HotelAvailRQRS>();

            foreach (var room in translatedToHIS.Body.OTA_HotelAvailRS.RoomStays)
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

            var InputDMG = _setupFixture.GetHotelAvailTranslatedToDMG();

            var resultContent = HISHelpers.SendToTalismanAndGetResponseAsync(InputDMG, "http://xmlv7test.travco.co.uk/trlink/link1/show", _logger);
            var OutputDMG = _setupFixture.HotelAvailDMGOutput.DeserializeFromXML<RETURNDATA>();

            var translatedToHIS = TranslateXML.ToHISSearchAvailability(OutputDMG, InputDMG).DeserializeFromXML<OTA_HotelAvailRQRS>();

            var expected = translatedToHIS.Body.OTA_HotelAvailRS.RoomStays[0].RoomRates[0].Rates[0].Base.AmountBeforeTax;

            var availRequestSegment = _setupFixture.HotelAvailHISReqObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            foreach (var subhotel in OutputDMG.DATA.HOTEL_DATA[0].SubHotelData)
            {
                foreach (var room in subhotel.ROOM_DATA)
                {
                    if (availRequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode == "*" || availRequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode == subhotel.RatePlanDetails.RatePlanCode)
                    {
                        TranslateXML.ParsePriceText(room.ADULT_PRICE_DETAILS.Split(' '), out var price);

                        var actual = Convert.ToDecimal(price);
                        if (room.CHILD_PRICE_DETAILS != null)
                        {
                            TranslateXML.ParsePriceText(room.CHILD_PRICE_DETAILS.Split(' '), out var childprice);
                            actual = Convert.ToDecimal(price) + Convert.ToDecimal(childprice);
                        }

                        Assert.Equal(expected, actual);
                    }
                }                
            }
        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_TotalPrice_Test()
        {

            RETURNDATA outputDMG = _setupFixture.GetHISOutput(_logger, out OTA_HotelAvailRQRS translatedToHIS);

            var availRequestSegment = _setupFixture.HotelAvailHISReqObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;

            var expected = translatedToHIS.Body.OTA_HotelAvailRS.RoomStays[0].RoomRates[0].Rates[0].Total.AmountBeforeTax;

            foreach (var subhotel in outputDMG.DATA.HOTEL_DATA[0].SubHotelData)
            {
                foreach (var room in subhotel.ROOM_DATA)
                {
                    // check for rateplan code
                    if (availRequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode == "*" || availRequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode == subhotel.RatePlanDetails.RatePlanCode)
                    {
                        var numNights = TranslateXML.ParsePriceText(room.ADULT_PRICE_DETAILS.Split(' '), out var price);

                        var actual = Convert.ToDecimal(numNights) * Convert.ToDecimal(price);

                        Assert.Equal(expected, actual);
                    }
                }
            }
        }

        [Fact]
        public void Is_DMG_Translated_Correctly_To_HIS_With_Child_TotalPrice_Test()
        {
            RETURNDATA outputDMG = _setupFixture.GetHISWithChildOutput(_logger, out OTA_HotelAvailRQRS translatedToHIS);

            var availRequestSegment = _setupFixture.HotelAvailHISReqObject.Body.OTA_HotelAvailRQ.AvailRequestSegments.AvailRequestSegment;
           
            foreach (var roomStay in translatedToHIS.Body.OTA_HotelAvailRS.RoomStays)
            {
                var expected = roomStay.RoomRates[0].Rates[0].Total.AmountBeforeTax;

                foreach (var subhotel in outputDMG.DATA.HOTEL_DATA[0].SubHotelData)
                {
                    foreach (var room in subhotel.ROOM_DATA)
                    {
                        // check for rateplan code
                        if (availRequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode == "*" || availRequestSegment.RatePlanCandidates.RatePlanCandidate.RatePlanCode == subhotel.RatePlanDetails.RatePlanCode)
                        {
                            var actual = GetActualPriceWithChild(room);

                            Assert.Equal(expected, actual);
                        }
                    }
                }
            }
        }

        private static decimal GetActualPriceWithChild(ROOM_DATA room)
        {
            var numNights = TranslateXML.ParsePriceText(room.ADULT_PRICE_DETAILS.Split(' '), out var price);

            var actual = Convert.ToDecimal(numNights) * Convert.ToDecimal(price);
            if (room.CHILD_PRICE_DETAILS != null)
            {
                TranslateXML.ParsePriceText(room.CHILD_PRICE_DETAILS.Split(' '), out var childprice);
                actual = Convert.ToDecimal(numNights) * Convert.ToDecimal(price) + Convert.ToDecimal(numNights) * Convert.ToDecimal(childprice);
            }

            return actual;
        }
    }
}
