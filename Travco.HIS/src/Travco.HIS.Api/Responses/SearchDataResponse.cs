using System.Collections.Generic;
using Travco.Data.Dto;
using Travco.Data.Dto.Dtos.Search;
using Travco.HIS.Api.Dto;
using CheckInDto = Travco.Data.Dto.Dtos.Search.CheckInDto;
using FreeNightsDto = Travco.Data.Dto.Dtos.Search.FreeNightsDto;
using RateValidityDto = Travco.Data.Dto.Dtos.Search.RateValidityDto;
using RoomCategoryDto = Travco.Data.Dto.Dtos.Search.RoomCategoryDto;
using RoomTypeDto = Travco.Data.Dto.Dtos.Search.RoomTypeDto;

namespace Travco.HIS.Api.Responses
{
    public class SearchDataResponse
    {
        //public StarRatingDto StarRating { get; set; }

        public CheckInDto CheckIn { get; set; }
        public string Budget { get; set; }
        public MasterRatePlanDto MasterRatePlan { get; set; }
        public IList<RateValidityDto> RateValidity { get; set; }
        public IList<FreeNightsDto> FreeNights { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Duration { get; set; }
        public string Nights { get; set; }
        public RoomTypeDto RoomType { get; set; }
        public RoomCategoryDto RoomCategory { get; set; }
        public double AdultPrice { get; set; }
        public string AdultPriceDetails { get; set; }
        public string CChargesCode { get; set; }
        public string ChildPrice { get; set; }
        public string CurrencyName { get; set; }
        public string Date { get; set; }
        public string EnquiryNo { get; set; }
        public string ExtraBedIndicator { get; set; }
        public string HotelCode { get; set; }
        public string HotelMessages { get; set; }
        public string HotelName { get; set; }
        public string HotelStarCode { get; set; }
        public string HotelStarPath { get; set; }
        public string LocationCode { get; set; }
        public string MainHotelCode { get; set; }
        public string MainHotelName { get; set; }
        public Messages Message { get; set; }
        public string MinimumChargeableDetails { get; set; }
        public string NoOfExtraBeds { get; set; }
        public string Price_code { get; set; }
        public string PriceMessage { get; set; }
        public string PriceCode { get; set; }
        public string PriceCurrency { get; set; }
        public IList<RatePlanDetailsDto> RatePlanDetails { get; set; }
        public string RoomCode { get; set; }
        public string RoomName { get; set; }
        public string RoomPax { get; set; }
        public string SpecialIndicator { get; set; }
        public string SpecialMessage { get; set; }
        public string Status { get; set; }
        public string TotalAdultPrice { get; set; }
        public string TotalChildPrice { get; set; }

        // HA response

        public SearchDataHAResponse DATA_HA { get; set; }

        public string CountryName { get; set; }
        public string CityName { get; set; }

        ////public IList<HotelDto> Hotel;
        public string CountryCode { get; set; }

        public string CityCode { get; set; }

        public RateSellingDto RateSelling { get; set; }
    }
}