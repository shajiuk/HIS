using System;
using Microsoft.Extensions.Logging;
using Moq;
using Travco.Helpers.HIS;
using Travco.HIS.Data.Response.Reservation;
using Travco.HIS.Model.Request.DMG.Reservation.Cancellation;
using Travco.HIS.Model.Request.Reservation.Cancellation;
using Travco.HIS.Model.Response.DMG.Reservation.Cancellation;
using Travco.HIS.Model.Response.Reservation;
using Xunit;

namespace Travco.HIS.UnitTests
{
    public class TranslateXMLHotelCanxTests : IClassFixture<SetupFixtures>
    {
        private readonly SetupFixtures _setupFixture;
        private readonly ILogger _logger;

        public TranslateXMLHotelCanxTests(SetupFixtures setupFixture)
        {
            _setupFixture = setupFixture;
            _logger = new Mock<ILogger>().Object;
        }

        [Fact]
        public void Is_Serialize_To_Object_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            Assert.NotNull(hotelCanxObject);

            Assert.NotNull(hotelCanxObject.Body);

            Assert.NotNull(hotelCanxObject.Header);

            Assert.NotNull(hotelCanxObject.Header.Interface);

            Assert.NotNull(hotelCanxObject.Header.Interface.ComponentInfo);

            Assert.NotNull(hotelCanxObject.Header.Interface.ComponentInfo.ComponentType);

            Assert.NotNull(hotelCanxObject.Header.Interface.ChannelIdentifierId);

        }

        [Fact]
        public void Is_UniqueId_Provided_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var id = hotelCanxObject.Body.OTA_CancelRQ.UniqueID.ID;

            Assert.NotNull(id);

        }

        [Fact]
        public void Is_UniqueId_In_DMG_BookingEnquiry_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var InputDMGBookingEnquiry = TranslateXML.ToBookingCancellation(hotelCanxObject);

            var expected = hotelCanxObject.Body.OTA_CancelRQ.UniqueID.ID;

            var actual = InputDMGBookingEnquiry.DATA.OUR_REF_NO;
            Assert.Equal(expected, actual);

        }


        [Fact]
        public void Is_UniqueId_In_DMG_BookingEnquiry_Output_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATAHB>();

            var expected = hotelCanxObject.Body.OTA_CancelRQ.UniqueID.ID;

            var actual = OutputDMGBookingEnquiry.DATA_HOTEL.AGENTS_REF_NO;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Is_Travco_Ref_In_DMG_BookingEnquiry_Output_Test()
        {
            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATABE>();

            var expected = OutputDMGBookingEnquiry.DATA_HOTEL.TRAVCO_REF_NO;

            Assert.NotEmpty(expected);

        }


        [Fact]
        public void Is_Status_Is_C_In_DMG_HotelCancel_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var InputDMGBookingEnquiry = TranslateXML.ToBookingCancellation(hotelCanxObject);

            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATABE>();

            var InputDMGHotelCancel = TranslateXML.CreateHotelBookingCancellationObject(OutputDMGBookingEnquiry, InputDMGBookingEnquiry);

            var expected = "C";

            var actual = InputDMGHotelCancel.DATA_HOTEL[0].STATUS;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Is_Same_Travco_Ref_In_DMG_HotelCancel_Input_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var InputDMGBookingEnquiry = TranslateXML.ToBookingCancellation(hotelCanxObject);

            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATABE>();

            var InputDMGHotelCancel = TranslateXML.CreateHotelBookingCancellationObject(OutputDMGBookingEnquiry, InputDMGBookingEnquiry);

            var expected = OutputDMGBookingEnquiry.DATA_HOTEL.TRAVCO_REF_NO;
            var actual = InputDMGHotelCancel.DATA_HOTEL[0].REF_NO;

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Is_Cancelled_In_DMG_HotelCancel_Input_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var InputDMGBookingEnquiry = TranslateXML.ToBookingCancellation(hotelCanxObject);

            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATABE>();

            var InputDMGHotelCancel = TranslateXML.CreateHotelBookingCancellationObject(OutputDMGBookingEnquiry, InputDMGBookingEnquiry);

            var OutputDMGHotelCancel = _setupFixture.HotelCanxOutputDMG.DeserializeFromXML<RETURNDATAHB>();

            var expected = "Cancelled";
            var actual = OutputDMGHotelCancel.DATA_HOTEL.MESSAGE.ERROR_DESCRIPTION.Trim();

            Assert.Equal(expected, actual);

        }


        [Fact]
        public void Is_Status_C_In_DMG_HotelCancel_Output_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var InputDMGBookingEnquiry = TranslateXML.ToBookingCancellation(hotelCanxObject);

            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATABE>();

            var InputDMGHotelCancel = TranslateXML.CreateHotelBookingCancellationObject(OutputDMGBookingEnquiry, InputDMGBookingEnquiry);

            var OutputDMGHotelCancel = _setupFixture.HotelCanxOutputDMG.DeserializeFromXML<RETURNDATAHB>();

            var expected = "C";
            var actual = OutputDMGHotelCancel.DATA_HOTEL.STATUS.Trim();

            Assert.Equal(expected, actual);

        }



        [Fact]
        public void Is_AgentRef_In_DMG_HotelCancel_Input_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var InputDMGBookingEnquiry = TranslateXML.ToBookingCancellation(hotelCanxObject);

            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATABE>();

            var InputDMGHotelCancel = TranslateXML.CreateHotelBookingCancellationObject(OutputDMGBookingEnquiry, InputDMGBookingEnquiry);

            var OutputDMGHotelCancel = _setupFixture.HotelCanxOutputDMG.DeserializeFromXML<RETURNDATAHB>();

            var expected = InputDMGHotelCancel.DATA_HOTEL[0].OUR_REF_NO;
            var actual = OutputDMGHotelCancel.DATA_HOTEL.AGENTS_REF_NO;

            Assert.Equal(expected, actual);

        }


        [Fact]
        public void Is_TravcoRef_In_DMG_HotelCancel_Input_Test()
        {
            var xml = _setupFixture.HotelCanxReq;
            var hotelCanxObject = xml.DeserializeFromXML<ReservationsCancellation>();

            var InputDMGBookingEnquiry = TranslateXML.ToBookingCancellation(hotelCanxObject);

            var OutputDMGBookingEnquiry = _setupFixture.HotelCanxBookingEnquiryOutputDMG.DeserializeFromXML<RETURNDATABE>();

            var InputDMGHotelCancel = TranslateXML.CreateHotelBookingCancellationObject(OutputDMGBookingEnquiry, InputDMGBookingEnquiry);

            var OutputDMGHotelCancel = _setupFixture.HotelCanxOutputDMG.DeserializeFromXML<RETURNDATAHB>();

            var expected = InputDMGHotelCancel.DATA_HOTEL[0].REF_NO;
            var actual = OutputDMGHotelCancel.DATA_HOTEL.TRAVCO_REF_NO;

            Assert.Equal(expected, actual);

        }

    }
}
