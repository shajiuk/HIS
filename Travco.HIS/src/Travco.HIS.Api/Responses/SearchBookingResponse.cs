using System.Collections.Generic;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Api.Responses
{
    public class SearchBookingResponse
    {
        public string SearchType { get; set; }
        public string Language { get; set; }
        public string ElapsedTimeToDeserializeXML2JSON { get; set; }
        public string ElapsedTimeFromQuery { get; set; }
        public IList<SearchDataResponse> DATA { get; set; }
        public SearchBookingRequest RequestData { get; set; }
        public SearchBookingHARequest RequestHAData { get; set; }
    }
}
