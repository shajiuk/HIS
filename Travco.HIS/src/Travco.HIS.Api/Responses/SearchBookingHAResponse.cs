using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Api.Responses
{
    public class SearchBookingHAResponse
    {
        public string SearchType { get; set; }
        public string Language { get; set; }
        public IList<SearchDataHAResponse> DATA { get; set; }
        public IList<SearchBookingRequest> RequestData { get; set; }
        public SearchBookingHARequest RequestHAData { get; set; }
    }
}
