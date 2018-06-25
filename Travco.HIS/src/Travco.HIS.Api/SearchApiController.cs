using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Travco.HIS.Api.Responses;
using AllocationSearch = Travco.Data.Model.SearchXML.Xml.Request.AllocationEnquiry;
using HotelSearch = Travco.Data.Model.SearchXML.Xml.Request.HotelAvailability;

namespace Travco.HIS.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class SearchApiController : Controller
    {
        protected readonly ILogger _logger;
        protected readonly ISearchServiceClient _client;

        public SearchApiController(
            ILogger logger,
            ISearchServiceClient client
        )
        {
            _logger = logger;
            _client = client;
        }

        [HttpPost("SearchAllocationEnquiry")]
        public async Task<IActionResult> SearchAllocations([FromBody]AllocationSearch.BOOKING request)
        {
            try
            {
                var response = await _client.SearchAllocations(request);
                return FormatResponse(response);
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        [HttpPost("SearchAllocationEnquiryXML")]
        public async Task<IActionResult> SearchAllocationsXml([FromBody]AllocationSearch.BOOKING request)
        {
            try
            {
                var response = await _client.SearchAllocationsXml(request);
                return FormatResponse(response);
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        [HttpPost("SearchHotelAvailablity")]
        public async Task<IActionResult> SearchHotels([FromBody]HotelSearch.BOOKING request)
        {
            try
            {
                var response = await _client.SearchHotels(request);
                return FormatResponse(response);
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        [HttpPost("SearchHotelAvailablityXML")]
        public async Task<IActionResult> SearchHotelsXml([FromBody]HotelSearch.BOOKING request)
        {
            try
            {
                var response = await _client.SearchHotelsXml(request);
                return FormatResponse(response);
            }
            catch (Exception ex)
            {
                return JsonException(ex);
            }
        }

        protected IActionResult FormatResponse(object response)
        {
            switch (Request.Headers["Accept"])
            {
                case MediaTypeNames.Text.Xml:
                case "application/xml":
                    var jsonData = JsonConvert.SerializeObject(response);
                    var body = JsonConvert.DeserializeXNode(jsonData, "RETURNDATA").ToString();
                    return Content(body, MediaTypeNames.Text.Xml);
                default:
                    return Json(response);
            }
        }


        #region Error Handling

        protected ActionResult JsonException(Exception ex)
        {
            if (ex.InnerException is ValidationException)
            {
                return ValidationError(ex);
            }
            else if (ex.InnerException is WebException)
            {
                return ApiError(ex.InnerException as WebException);
            }
            return InternalServerError(ex);
        }

        private ActionResult ValidationError(Exception ex)
        {
            var innerException = ex.InnerException as ValidationException;
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { errors = innerException.Errors });
        }

        private ActionResult InternalServerError(Exception ex)
        {
            _logger.LogError(nameof(InternalServerError), ex);
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Json(new { message = ex.Message });
        }

        private ActionResult ApiError(WebException ex)
        {
            HttpWebResponse response = ex.Response as HttpWebResponse;
            string body = "";
            using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                body = reader.ReadToEnd();
            }
            Response.StatusCode = (int)response.StatusCode;
            return Content(body, response.ContentType);
        }

        #endregion
    }
}
