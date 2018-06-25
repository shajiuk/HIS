using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Travco.Data.Dto.Dtos.Search;
using Travco.HIS.Api.Dto;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Api.Responses
{
    public class SearchBookingHAXMLResponse
    {
        [JsonProperty(PropertyName = "@type")]
        public string SearchType { get; set; }

        [JsonProperty(PropertyName = "@lang")]
        public string Language { get; set; }

        public string RecordsReturned { get; set; }
        public string ElapsedTimeToDeserializeXML2JSON { get; set; }
        public string ElapsedTimeFromQuery { get; set; }
        public string ElapsedTimeToDeserializeJSON2XML { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DATA> DATA{ get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RatePlanDetailsDto RatePlanDetails { get; set; }

        [JsonIgnore]
        public SearchBookingRequest RequestData { get; set; }

        [JsonIgnore]
        public SearchBookingHARequest RequestHAData { get; set; }
    }
}
