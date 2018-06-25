using System;
using System.Data;
using System.Net.Http;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Travco.Helpers.HIS;
using Travco.HIS.Model;
using Travco.HIS.Model.Request.HotelAvail;
using Travco.HIS.Model.Request.HotelDescriptiveInfo;
using Travco.HIS.Model.Request.Reservation.Cancellation;

namespace Travco.HIS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class HISController : Controller
    {
        private readonly ILogger _logger;

        private readonly IMapper _mapper;
	    private readonly IOptions<XMLConfigOptions> _config;
	    private string _standardError;
	    private string _hotelResRSError;
	    private string _noAvailRoomsXml;
	    private string _hotelResCancelRSError;

        public HISController(IMapper mapper, IOptions<XMLConfigOptions> options, ILogger<HISController> logger)
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

        [HttpPost("HotelAvailability")]
	    public async Task<string> HotelAvailability([FromBody] HotelAvail request)
	    {
	        try
	        {
	            return await HISHelpers.ProcessHotelAvailability(request, _config, _standardError, false, _logger);
	        }
	        catch (Exception e)
	        {
                _logger.LogError(e, "HotelAvailability ERROR");
                throw;
            }
	    }

	    [HttpPost("ReservationsBooking")]
	    public async Task<string> ReservationsBooking([FromBody]ReservationsMultiRoomBooking request)
	    {
	        try
	        {	            
	            return await HISHelpers.ProcessReservationsBooking(request, _config, _hotelResRSError, _logger);
	        }
	        catch (HttpRequestException e)
	        {
                _logger.LogError(e, "ReservationsBooking ERROR");
                throw;
	        }
	    }


	    [HttpPost("ReservationsCancellation")]
	    public async Task<string> ReservationsCancellation([FromBody]ReservationsCancellation request)
	    {
	        try
	        {
	            // HIS => DMG Booking Enquiry => DMG Hotel Booking Cancellation => HIS Cancellation Response 

	            return await HISHelpers.ProcessCancellation(request, _config, _hotelResCancelRSError, _logger);
	        }
	        catch (HttpRequestException e)
	        {
                _logger.LogError(e, "ReservationsCancellation ERROR");
                throw;
            }
	    }

        // Getting Hotel Descriptive Info Response
	    [HttpPost("HotelDescriptiveInfo")]
	    public async Task<string> HotelDescriptiveInfo([FromBody] HotelDescriptiveInfoReq request)
	    {
	        try
	        {
                DataTable data = new DataTable();

                using (IDbConnection connection = new SqlConnection(_config.Value.CMSConnection))
                {
                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = $"SELECT HotelCode, HotelName, SubHotelCode, HotelAddress, CityName, CountryName, HotelTelephone, HotelEmail, CityCode, RatePlanCode, RatePlanName, RoomCode, EN_RoomName, JP_RoomName, RoomPax FROM CmsData WHERE HotelCode = '{request.Body.OTA_HotelDescriptiveInfoRQ.HotelDescriptiveInfos.HotelDescriptiveInfo.HotelCode}'";
                        using (IDataReader reader = command.ExecuteReader())
                        {
                            data.Load(reader);
                        }
                    }
                }

                return HISHelpers.GenerateXMLFromCMS(request, _logger, data);
            }
            catch (Exception e)
	        {
	            Console.WriteLine("\nException Caught!");
	            Console.WriteLine("Message :{0} ", "No Data");
	            return e.Message;
	        }
	    }
    }
}
