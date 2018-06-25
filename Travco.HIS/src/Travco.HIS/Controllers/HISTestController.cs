using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Travco.Helpers.HIS;
using Travco.HIS.Model;
using Travco.HIS.Model.Request.HotelAvail;
using Travco.HIS.Model.Request.Reservation.Cancellation;
using Travco.HIS.Model.Response.DMG.Reservation.Cancellation;

namespace Travco.HIS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class HISTestController : Controller
	{
		private readonly ILogger _logger;

        private readonly IMapper _mapper;
	    private readonly IOptions<XMLConfigOptions> _config;
	    private string _standardError;
	    private string _hotelResRSError;
	    private string _noAvailRoomsXml;
	    private string _hotelResCancelRSError;

	    public HISTestController(IMapper mapper, IOptions<XMLConfigOptions> options, ILogger<HISTestController> logger)
        {
            _mapper = mapper;
            _config = options;
            _logger = logger;

            ReadErrorFiles();

        }

        private void ReadErrorFiles()
        {
           _standardError = Utils.GetXml("Data/Response/Error/ErrorResponse.xml");
           _hotelResRSError = Utils.GetXml("Data/Response/Error/ErrorResponse-HotelResRS.xml");
           _hotelResCancelRSError = Utils.GetXml("Data/Response/Error/ErrorResponse-CancelResRS.xml");
           _noAvailRoomsXml = Utils.GetXml("Data/Response/SearchAvailability/NoAvailRoom.xml");

        }


        [HttpPost("TranslateSearchAvailabilityToTravcoXML")]
        public string TranslateSearchAvailabilityToTravcoXML([FromBody] HotelAvail searchAvailabilityRequest)
        {

            try
            {

                var travcoBookingRequestModel = TranslateXML.ToHotelAvailability(searchAvailabilityRequest);

                return travcoBookingRequestModel.SerializeToXML();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "TranslateSearchAvailabilityToTravcoXML ERROR");
                return e.Message;
            }
        }

	    [HttpPost("TranslateReservationsToTravcoXML")]
	    public string TranslateReservationsToTravcoXML([FromBody] ReservationsMultiRoomBooking request)
	    {

	        try
	        {
	            var travcoBookingRequestModel = TranslateXML.ToReservationBooking(request);

	            return travcoBookingRequestModel.SerializeToXML();

	        }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "TranslateSearchAvailabilityToTravcoXML ERROR");
	            return e.Message;
	        }
	    }

     //   [HttpPost("TranslateReservationsSingleRoomBookingToTravcoXML")]
	    //public string TranslateReservationsSingleRoomBookingToTravcoXML([FromBody] ReservationsSingleRoomBooking request)
	    //{

	    //    try
	    //    {

	    //        var travcoBookingRequestModel = TranslateXML.ToReservationSingleRoomBooking(request);

	    //        return Helpers.HIS.Utils.SerializeToXML(travcoBookingRequestModel);

	    //        //return Helpers.HIS.Utils.SerializeToXMLWithNamespace(travcoBookingRequestModel, "xmlns", "xsi");


     //       }
	    //    catch (Exception e)
	    //    {
	    //        return null;
	    //    }
	    //}

	    [HttpPost("HotelAvailabilityResponseDMG")]
	    public async  Task<string> SearchAvailabilityResponseDMG([FromBody] HotelAvail searchAvailabilityRequest)
	    {
	        // Create a New HttpClient object.
	        HttpClient client = new HttpClient();

	        try
	        {

	            var travcoBookingRequestModel = TranslateXML.ToHotelAvailability(searchAvailabilityRequest);

	            return await HISHelpers.SendToTalismanAndGetResponseAsync(travcoBookingRequestModel, _config.Value.DMGEndpoint, _logger);

	        }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "HotelAvailabilityResponseDMG ERROR");
	            return e.Message;
	        }
        }


	    [HttpPost("ReservationResponseDMG")]
	    public async Task<string> ReservationResponseDMG([FromBody] ReservationsMultiRoomBooking request)
	    {
	        // Create a New HttpClient object.
	        HttpClient client = new HttpClient();

	        try
	        {

	            var travcoBookingRequestModel = TranslateXML.ToReservationBooking(request);

	            var isPriceOk = await HISHelpers.CheckHotelAvailablity(request, travcoBookingRequestModel, _config, "", _logger);
	            if (isPriceOk)
	            {
	                var resultContent = await HISHelpers.SendToTalismanAndGetResponseAsync(travcoBookingRequestModel, _config.Value.DMGEndpoint, _logger);

	                return resultContent;
	            }

	            return "Not within price range";
            }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "ReservationResponseDMG ERROR");
	            return e.Message;
	        }
	    }

        [HttpPost("TranslateCancellationToTravcoXML")]
	    public string TranslateReservationsSingleRoomBookingToTravcoXML([FromBody]  ReservationsCancellation request)
	    {

	        try
	        {

	            var travcoBookingRequestModel = TranslateXML.ToReservationCancellation(request);

	            return travcoBookingRequestModel.SerializeToXML();

	            //return Helpers.HIS.Utils.SerializeToXMLWithNamespace(travcoBookingRequestModel, "xmlns", "xsi");


	        }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "TranslateCancellationToTravcoXML ERROR");
	            return e.Message;
	        }
        }


	    [HttpPost("TranslateHISCancelToBookingEnquiry")]
	    public string TranslateHISCancelToBookingEnquiry([FromBody] ReservationsCancellation request)
	    {

	        try
	        {

	            var travcoBookingRequestModel = TranslateXML.ToBookingCancellation(request);

                return travcoBookingRequestModel.SerializeToXML();

	        }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "TranslateHISCancelToBookingEnquiry ERROR");
	            return e.Message;
	        }
        }

	    [HttpPost("TranslateHISCancelToBookingEnquiryDMGOutput")]
	    public async Task<string> TranslateHISCancelToBookingEnquiryDMGOutput([FromBody] ReservationsCancellation request)
	    {

            try
	        {

	            var travcoBookingRequestModel = TranslateXML.ToBookingCancellation(request);

	            var resultContentXml = await HISHelpers.SendToTalismanAndGetResponseAsync(travcoBookingRequestModel, _config.Value.DMGEndpoint, _logger);

	            return resultContentXml;

	        }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "TranslateHISCancelToBookingEnquiryDMGOutput ERROR");
	            return e.Message;
	        }
        }

	    [HttpPost("TranslateHISCancelToBookingEnquiryDMGOutputToHotelCancelDMG")]
	    public async Task<string> TranslateHISCancelToBookingEnquiryDMGOutputToHotelCancelDMG([FromBody] ReservationsCancellation request)
	    {
	        try
	        {

	            var travcoBookingRequestModel = TranslateXML.ToBookingCancellation(request);

	            var resultContentXml = await HISHelpers.SendToTalismanAndGetResponseAsync( travcoBookingRequestModel, _config.Value.DMGEndpoint, _logger);

	            var bookingEnquiryResponseModel = resultContentXml.DeserializeFromXML<RETURNDATABE>();

	            var hotelBookingCancellation = TranslateXML.CreateHotelBookingCancellationObject(bookingEnquiryResponseModel, travcoBookingRequestModel);

                return hotelBookingCancellation.SerializeToXML(); ;

	        }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "TranslateHISCancelToBookingEnquiryDMGOutputToHotelCancelDMG ERROR");
	            return e.Message;
	        }
        }

	    [HttpPost("TranslateHISCancelToBookingEnquiryDMGOutputToHotelCancelDMGOutput")]
	    public async Task<string> TranslateHISCancelToBookingEnquiryDMGOutputToHotelCancelDMGOutput([FromBody] ReservationsCancellation request)
	    {
	        // Create a New HttpClient object.
	        HttpClient client = new HttpClient();

	        try
	        {

	            var travcoBookingRequestModel = TranslateXML.ToBookingCancellation(request);

	            var resultContentXml = await HISHelpers.SendToTalismanAndGetResponseAsync(travcoBookingRequestModel, _config.Value.DMGEndpoint, _logger);

	            var bookingEnquiryResponseModel = resultContentXml.DeserializeFromXML<RETURNDATABE>();

	            var hotelBookingCancellation = TranslateXML.CreateHotelBookingCancellationObject(bookingEnquiryResponseModel, travcoBookingRequestModel);

	            var hotelBookingCancellationContentXml = await HISHelpers.SendToTalismanAndGetResponseAsync(hotelBookingCancellation, _config.Value.DMGEndpoint, _logger);

	            return hotelBookingCancellationContentXml;

	        }
	        catch (Exception e)
	        {
	            _logger.LogError(e, "TranslateHISCancelToBookingEnquiryDMGOutputToHotelCancelDMG ERROR");
	            return e.Message;
            }
	    }

    }
}
