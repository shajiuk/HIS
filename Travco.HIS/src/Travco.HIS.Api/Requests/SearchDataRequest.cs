using System.Collections.Generic;
using Travco.Data.Dto.Dtos.Search;
using CheckInDto = Travco.Data.Dto.Dtos.Search.CheckInDto;
using RoomTypeDto = Travco.Data.Dto.Dtos.Search.RoomTypeDto;
using StarRatingDto = Travco.Data.Dto.StarRatingDto;

namespace Travco.HIS.Api.Requests
{
    public class SearchDataRequest 
    {

        public CheckInDto CheckIn { get; set; }
        public double Budget { get; set; } 
        public IList<string> MultiHotelsRequest{ get; set; }
        public IList<string> MultiStarsRequest{ get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Duration { get; set; }
        public int Nights { get; set; }
        public RoomTypeDto RoomType { get; set; }
        public StarRatingDto StarRating { get; set; }
        public string CityAreaCode{ get; set; }
        public string CityCode{ get; set; }
        public string ClerkCode{ get; set; }
        public string ClerkPassword{ get; set; }
        public string CountryCode{ get; set; }
        public string CountryRegionCode{ get; set; }
        public string EdiCode{ get; set; }
        public string EnquiryNo { get; set; }
        public string HotelCode { get; set; }
        public string HotelName{ get; set; }
        public string LocationCode { get; set; }
        public RoomsRequiredDto RoomsRequired { get; set; }

        // Optional data
        public bool FreeNightDetailsRequired { get; set; }
        public bool HotelMessagesRequired { get; set; }
        public bool ReductionAmountRequired { get; set; }
        public string SortingOrder { get; set; }

        // Additional Data
        public bool AmenityRequired { get; set; }
        public bool EmailAddressRequired { get; set; }
        public bool FaxNumberRequired { get; set; }
        public bool HotelAddressRequired { get; set; }
        public bool PictureRequired { get; set; }
        public bool TelephoneNumberRequired { get; set; }

        // Additional Hotel Details
        public bool CityAreaRequired { get; set; }
        public bool EnglishTextRequired { get; set; }
        public bool GeoCodesRequired { get; set; }
        public bool HotelArrivalPointOtherRequired { get; set; }
        public bool HotelArrivalPointRequired { get; set; }
        public bool HotelCityRequired { get; set; }
        public bool HotelDescriptionRequired { get; set; }
        public bool HotelPropertiesRequired { get; set; }
        public bool LocationRequired { get; set; }


    }
}
