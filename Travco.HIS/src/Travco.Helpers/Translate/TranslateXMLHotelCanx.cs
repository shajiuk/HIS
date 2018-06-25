using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Travco.HIS.Model.Request.DMG.Reservation;
using Travco.HIS.Model.Request.DMG.Reservation.Cancellation;
using Travco.HIS.Model.Request.Reservation.Cancellation;
using Travco.HIS.Model.Response.DMG.Reservation.Cancellation;
using Travco.HIS.Model.Response.Reservation.Cancellation;
using BookingCancellationDMG = Travco.HIS.Model.Request.DMG.Reservation.Cancellation.BOOKING;
using BookingReservationDMG = Travco.HIS.Model.Request.DMG.Reservation.BOOKING;
using ReturnDataReservationCancellationDMG = Travco.HIS.Model.Response.DMG.Reservation.Cancellation.RETURNDATABE;

namespace Travco.Helpers.HIS
{
    public static partial class TranslateXML
    {

        #region CANCELLATIONS

        /// <summary>
        /// CANCELLATIONS
        /// </summary>
        /// <param name="headerInfo"></param>
        /// <returns></returns>
        public static BookingCancellationDMG ToReservationCancellation(ReservationsCancellation HISRequest)
        {
            BookingCancellationDMG booking = new BookingCancellationDMG
            {
                AGENTCODE = HISRequest.Header.Interface.ComponentInfo.User,
                AGENTPASSWORD = HISRequest.Header.Interface.ComponentInfo.Pwd, //"1234567890",
                HishHeaderInfo = new HISHeaderInfoResCanx
                {
                    Header = HISRequest.Header,
                    RequestId = HISRequest.Body.RequestId,
                    Transaction = HISRequest.Body.Transaction,
                    EchoToken = HISRequest.Body.OTA_CancelRQ.EchoToken,
                    PrimaryLangID = HISRequest.Body.OTA_CancelRQ.PrimaryLangID,
                    Target = HISRequest.Body.OTA_CancelRQ.Target
                },
                type = "HB",
                lang = !HISRequest.Body.OTA_CancelRQ.PrimaryLangID.Contains("-GB") ? HISRequest.Body.OTA_CancelRQ.PrimaryLangID + "-GB" : HISRequest.Body.OTA_CancelRQ.PrimaryLangID,
                returnURLNeed = BOOKINGReturnURLNeed.no,
                returnURL = "http://"
            };

            // var availrequestSegment = HISRequest.Body.OTA_HotelResRQ.HotelReservations.HotelReservation;


            booking.DATA = new BOOKINGDATA
            {
                CHECK_IN_DATE = HISRequest.Body.OTA_CancelRQ.CancelType
            };

            return booking;
        }

        public static BookingEnquiry ToBookingCancellation(ReservationsCancellation HISRequest)
        {
            BookingEnquiry booking = new BookingEnquiry
            {
                AGENTCODE = HISRequest.Header.Interface.ComponentInfo.User,
                AGENTPASSWORD = HISRequest.Header.Interface.ComponentInfo.Pwd, //"1234567890",  
                HishHeaderInfo = new HISHeaderInfoResCanx
                {
                    Header = HISRequest.Header,
                    RequestId = HISRequest.Body.RequestId,
                    Transaction = HISRequest.Body.Transaction,
                    EchoToken = HISRequest.Body.OTA_CancelRQ.EchoToken,
                    PrimaryLangID = HISRequest.Body.OTA_CancelRQ.PrimaryLangID,
                    Target = HISRequest.Body.OTA_CancelRQ.Target
                },
                HEADER = new BookingEnquiryHeader
                {
                    INTERNAL_CODE1 = "DWEBCN",
                    INTERNAL_CODE2 = "HTMLENQ",
                    INTERNAL_CODE4 = "DWEBRS",
                    INTERNAL_CODE7 = "VB",
                    INTERNAL_CODE8 = "travel system"
                },
                DATA = new BookingEnquiryData
                {
                     OUR_REF_NO = HISRequest.Body.OTA_CancelRQ.UniqueID.ID
                },
                type = "BE",
                lang = !HISRequest.Body.OTA_CancelRQ.PrimaryLangID.Contains("-GB") ? HISRequest.Body.OTA_CancelRQ.PrimaryLangID + "-GB" : HISRequest.Body.OTA_CancelRQ.PrimaryLangID,
                returnURL = "http://"
            };

            // var availrequestSegment = HISRequest.Body.OTA_HotelResRQ.HotelReservations.HotelReservation;

            return booking;
        }

        public static BookingReservationDMG CreateHotelBookingCancellationObject(ReturnDataReservationCancellationDMG travcoResponseModel, BookingEnquiry bookingEnquiry)
        {
            BookingReservationDMG booking = new BookingReservationDMG
            {
                AGENTCODE = bookingEnquiry.AGENTCODE,
                AGENTPASSWORD = bookingEnquiry.AGENTPASSWORD,
                HishHeaderInfo = new HISHeaderInfoRes
                {

                    RequestId = bookingEnquiry.HishHeaderInfo.RequestId,
                    Transaction = bookingEnquiry.HishHeaderInfo.Transaction,
                    EchoToken = bookingEnquiry.HishHeaderInfo.EchoToken,
                    PrimaryLangID = bookingEnquiry.HishHeaderInfo.PrimaryLangID,
                    Target = bookingEnquiry.HishHeaderInfo.Target
                },
                HEADER = new HEADER
                {
                    INTERNAL_CODE2 = bookingEnquiry.HishHeaderInfo.RequestId + "-" + DateTime.Now.Millisecond,
                    INTERNAL_CODE4 = travcoResponseModel.DATA_HOTEL.ARR_DATE,
                    INTERNAL_CODE6 = travcoResponseModel.DATA_HOTEL.TRAVCO_REF_NO
                }
            };

            booking.DATA_HOTEL = new List<DATA_HOTEL>
            {
                new DATA_HOTEL()
                {
                    REF_NO = travcoResponseModel.DATA_HOTEL.TRAVCO_REF_NO,
                    PAX_NAME = "LeadPax",
                    OUR_REF_NO = travcoResponseModel.DATA_HOTEL.AGENTS_REF_NO,
                    ARR_DATE = travcoResponseModel.DATA_HOTEL.ARR_DATE,
                    DURATION = travcoResponseModel.DATA_HOTEL.DURATION.ToString(),
                    HOTEL_CODE = travcoResponseModel.DATA_HOTEL.HOTEL_CODE,
                    ROOM_CODE = travcoResponseModel.DATA_HOTEL.ROOM_CODE,
                    ADULTS = travcoResponseModel.DATA_HOTEL.ADULTS.ToString(),
                    STATUS = "C"
                }
            }.ToArray();

            return booking;
        }

        public static void ToHISReservationsCancellation(RETURNDATAHB travcoResponseModel, HISHeaderInfoResCanx headerInfo, ILogger logger, ReservationsCancellationRes response)
        {
            logger.LogInformation("Processing ToHISReservationsCancellation....");

            response.Body.OTA_CancelRS.Success = new object();
            response.Body.OTA_CancelRS.Status = (travcoResponseModel.DATA_HOTEL.STATUS == "P") ? "Pending" : "Cancelled";
            response.Body.OTA_CancelRS.UniqueID = new OTA_CancelRSUniqueID
            {
                Type = 15,
                ID = travcoResponseModel.DATA_HOTEL.TRAVCO_REF_NO
            };
            response.Body.OTA_CancelRS.CancelInfoRS = new OTA_CancelRSCancelInfoRS
            {
                UniqueID = new OTA_CancelRSCancelInfoRSUniqueID
                {
                    ID = travcoResponseModel.DATA_HOTEL.AGENTS_REF_NO,
                    Type = 15
                }
            };
        }

        #endregion
    }
}
