using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Api.Responses
{
    public class SearchBookingXMLResponse
    {
        [JsonProperty(PropertyName = "@type")]
        public string SearchType { get; set; }

        [JsonProperty(PropertyName = "@lang")]
        public string Language { get; set; }
        public string RecordsReturned { get; set; }
        public string ElapsedTimeToDeserializeJSON2XML { get; set; }
        public string ElapsedTimeFromQuery { get; set; }
        public string ElapsedTimeToDeserializeXML2JSON { get; set; }
        public IList<SearchDataXMLResponse> DATA { get; set; }
        public SearchBookingRequest RequestData { get; set; }
        public SearchBookingHARequest RequestHAData { get; set; }

    }
}
