using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Travco.Data.Dto.Dtos.Search;
using Travco.HIS.Api.Dto;
using RatePlanDetailsDto = Travco.Data.Dto.Dtos.Search.RatePlanDetailsDto;


namespace Travco.HIS.Api.Responses
{
    public class SearchDataXMLResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BUDGET { get; set; }

        [JsonIgnore]
        public IList<RateValidityDto> RateValidity { get; set; }

        [JsonProperty(PropertyName = "@ADULTS")]
        public int ADULTS { get; set; }

        [JsonProperty(PropertyName = "@CHILDREN")]
        public int CHILDREN { get; set; }

        [JsonProperty(PropertyName = "@DURATION")]
        public int DURATION { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NIGHTS { get; set; }

        [JsonProperty(PropertyName = "@ADULT_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public double? ADULT_PRICE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ADULT_PRICE_DETAILS { get; set; }

        [JsonProperty(PropertyName = "@CCHARGES_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string CCHARGES_CODE { get; set; }

        [JsonProperty(PropertyName = "@CHILD_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public string CHILD_PRICE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CHILD_PRICE_DETAILS { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CURRENCY_NAME { get; set; }

        [JsonProperty(PropertyName = "@DATE", NullValueHandling = NullValueHandling.Ignore)]
        public string DATE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DATE_LAST_AVAIL { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DATE_NEXT_AVAIL { get; set; }

        [JsonProperty(PropertyName = "@ENQUIRY_NO", NullValueHandling = NullValueHandling.Ignore)]
        public string ENQUIRY_NO { get; set; }

        [JsonProperty(PropertyName = "@EXTRA_BED_INDICATOR", NullValueHandling = NullValueHandling.Ignore)]
        public string EXTRA_BED_INDICATOR { get; set; }

        [JsonProperty(PropertyName = "@HOTEL_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_CODE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_NAME { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_STAR { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Hotel_Star_Code { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HotelMessages { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LOCATION_CODE { get; set; }

        [JsonProperty(PropertyName = "@MainHotelCode", NullValueHandling = NullValueHandling.Ignore)]
        public string MainHotelCode { get; set; }

        public string MainHotelName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Messages MESSAGE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MINIMUM_CHARGEABLE_DETAILS { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NO_OF_EXTRA_BEDS { get; set; }

        [JsonProperty(PropertyName = "@PRICE_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string PRICE_CODE { get; set; }

        [JsonProperty(PropertyName = "@PRICE_CURRENCY", NullValueHandling = NullValueHandling.Ignore)]
        public string PRICE_CURRENCY { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PRICE_MESSAGE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RatePlanDetailsDto RatePlanDetails { get; set; }

        [JsonProperty(PropertyName = "@ROOM_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string ROOM_CODE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ROOM_NAME { get; set; }

        [JsonProperty(PropertyName = "@ROOM_PAX", NullValueHandling = NullValueHandling.Ignore)]
        public string ROOM_PAX { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SPECIAL_INDICATOR { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SPECIAL_MESSAGE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string STATUS { get; set; }

        [JsonProperty(PropertyName = "@TOTAL_ADULT_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public string TOTAL_ADULT_PRICE { get; set; }

        [JsonProperty(PropertyName = "@TOTAL_CHILD_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public string TOTAL_CHILD_PRICE { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ReducedPriceDetails ReducedPriceDetails;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<FreeNightsDto> FreeNights { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public FreeNightsDetails FreeNightsDetails { get; set; }

        // HA - ADDITIONAL RESPONSE FIELDS

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DATA DATA { get; set; }

    }
}


