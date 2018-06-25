using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Travco.Data.Common;
using HotelSearch = Travco.Data.Model.SearchXML.Xml.Request.HotelAvailability;
using AllocationSearch = Travco.Data.Model.SearchXML.Xml.Request.AllocationEnquiry;
using Travco.HIS.Api.Responses;
using Travco.HIS.Api.Requests;
using Travco.Framework.RestClient;

namespace Travco.HIS.Api
{
    public class SearchServiceClient : ServiceClient, ISearchServiceClient
    {
        protected override string ClientName => "search";

        public SearchServiceClient(
            IOptions<SearchOptions> options,
            HttpClient httpClient,
            IAuthorisationSettings authSettings
        ) : base(new Uri(options.Value.ServiceName), httpClient, authSettings)
        {
        }

        public async Task<SearchResponse> SearchAllocations(SearchBookingRequest request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchAllocationEnquiry");
            message.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchResponse>(text);
        }

        public async Task<SearchResponse> SearchAllocations(AllocationSearch.BOOKING request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchAllocationEnquiryXml");
            message.Content = new StringContent(SerialiseXml(request), Encoding.UTF8, "application/json");
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchResponse>(text);
        }

        public async Task<SearchResponse> SearchAllocationsXml(SearchBookingRequest request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchAllocationEnquiry");
            message.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            message.Headers.Add("Accept", MediaTypeNames.Text.Xml);
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchResponse>(text);
        }

        public async Task<SearchResponse> SearchAllocationsXml(AllocationSearch.BOOKING request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchAllocationEnquiryXml");
            message.Content = new StringContent(SerialiseXml(request), Encoding.UTF8, "text/xml");
            message.Headers.Add("Accept", MediaTypeNames.Text.Xml);
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchResponse>(text);
        }

        public async Task<SearchBookingHAResponse> SearchHotels(SearchBookingRequest request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchHotelAvailability");
            message.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchBookingHAResponse>(text);
        }

        public async Task<SearchBookingHAResponse> SearchHotels(HotelSearch.BOOKING request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchHotelAvailabilityXml");
            message.Content = new StringContent(SerialiseXml(request), Encoding.UTF8, "text/xml");
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchBookingHAResponse>(text);
        }

        public async Task<SearchBookingHAResponse> SearchHotelsXml(SearchBookingRequest request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchHotelAvailability");
            message.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            message.Headers.Add("Accept", MediaTypeNames.Text.Xml);
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchBookingHAResponse>(text);
        }

        public async Task<SearchBookingHAResponse> SearchHotelsXml(HotelSearch.BOOKING request)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "api/Search/SearchHotelAvailabilityXml");
            message.Content = new StringContent(SerialiseXml(request), Encoding.UTF8, "text/xml");
            message.Headers.Add("Accept", MediaTypeNames.Text.Xml);
            var response = await Send(message);
            var text = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<SearchBookingHAResponse>(text);
        }

        private async Task<HttpResponseMessage> Send(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // Unless our config is completely borked (at which point this will exception out anyway), 
                // this typically means an expired token, so get a fresh one and try again
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authHelper.GetNewToken());
                var sigh = new HttpRequestMessage
                {
                    Content = request.Content,
                    Method = request.Method,
                    RequestUri = request.RequestUri,
                    Version = request.Version
                };
                foreach (var header in request.Headers)
                    sigh.Headers.Add(header.Key, header.Value);
                foreach (var property in request.Properties)
                    sigh.Properties.Add(property);
                response = await _httpClient.SendAsync(sigh);
            }
            return response;
        }

        private string SerialiseXml<T>(T o)
        {
            using (var writer = new StringWriter())
            {
                var serialiser = new XmlSerializer(typeof(T));
                serialiser.Serialize(writer, o);
                return writer.ToString();
            }
        }
    }
}