using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Travco.HIS.Api.Dto;

namespace Travco.HIS.Api.Responses
{
    public class SearchDataHAXMLResponse
    {
 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DATA DATA { get; set; }


    }
}
