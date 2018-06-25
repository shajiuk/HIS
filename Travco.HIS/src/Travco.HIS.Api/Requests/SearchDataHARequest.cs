using System.Collections.Generic;
using Travco.Data.Dto.Dtos.Search;
using SearchOptionalDataDto = Travco.Data.Dto.Dtos.Search.SearchOptionalDataDto;

namespace Travco.HIS.Api.Requests
{
    public class SearchDataHARequest
    {

        public CheckInDto CheckIn { get; set; }
        public IList<string> MultiHotelsRequest;
        public IList<string> MultiStarsRequest;

        public RoomTypeDto RoomType { get; set; }

        public string CityAreaCode;
        public string CityCode;
        public string ClerkCode;
        public string ClerkPassword;
        public string CountryCode;
        public string CountryRegionCode;
        public string EdiCode;
        public string HotelName;

        public IList<RoomsRequiredDto> RoomsRequired { get; set; }

        // Optional data
        public IList<SearchOptionalDataDto> OptionalData { get; set; }

        // Additional Data
        public IList<SearchAdditionalDataDto> AdditionalData { get; set; }

    }
}
