using System.Collections.Generic;
using Travco.Data.Dto;
using Travco.HIS.Api.Dto;

namespace Travco.HIS.Api.Responses
{
    public class SearchResponse
    {

        public List<HotelDto> Hotel { get; set; }

        public string Code { get; set; } // Include, Hotel Code
        public string Name { get; set; } // Include		
        public IList<SearchDataResponse> DATA { get; set; }

    }
}
