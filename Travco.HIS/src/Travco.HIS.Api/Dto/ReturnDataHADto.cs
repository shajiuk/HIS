using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Api.Dto
{
    public class ReturnDataHADto
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MESSAGE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<DATA> DATA;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TOTAL_NO_OF_HOTELS;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string lang;

        public ReturnDataHADto()
        {
            this.type = "HA";
        }
    }

    public partial class DATA
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string COUNTRY_NAME;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]       
        public string CITY_NAME;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]       
        public IList<HOTEL_DATA> HOTEL_DATA;

        [JsonProperty(PropertyName = "@COUNTRY_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string COUNTRY_CODE;

        [JsonProperty(PropertyName = "@CITY_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string CITY_CODE;

        [JsonProperty(PropertyName = "@NO_OF_ADULTS", NullValueHandling = NullValueHandling.Ignore)]
        public string NO_OF_ADULTS;

        [JsonProperty(PropertyName = "@NO_OF_CHILDREN", NullValueHandling = NullValueHandling.Ignore)]
        public string NO_OF_CHILDREN;

        [JsonProperty(PropertyName = "@CHECK_IN_DATE", NullValueHandling = NullValueHandling.Ignore)]
        public string CHECK_IN_DATE;

        [JsonProperty(PropertyName = "@CHECK_OUT_DATE", NullValueHandling = NullValueHandling.Ignore)]
        public string CHECK_OUT_DATE;

        [JsonIgnore]
        public SearchBookingHARequest RequestHAData { get; set; }

    }

    public partial class HOTEL_DATA
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_NAME;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_STAR;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<HOTEL_ADDITIONAL_DATA> HOTEL_ADDITIONAL_DATA;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HotelMessagesHotelMessage[] HotelMessages;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<SubHotelData> SubHotelData;

        [JsonProperty(PropertyName = "@HOTEL_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_CODE;

        [JsonProperty(PropertyName = "@STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public string STATUS;
    }

    public partial class HOTEL_ADDITIONAL_DATA
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_PICTURE;

        [JsonProperty(PropertyName = "HOTEL_AMENITY", NullValueHandling = NullValueHandling.Ignore)]
        public IList<HOTEL_AMENITY> HOTEL_AMENITY;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HOTEL_ADDRESS HOTEL_ADDRESS;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HOTEL_ADDITIONAL_DATAHotelDescription HotelDescription;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HOTEL_ADDITIONAL_DATALocation Location;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HOTEL_ADDITIONAL_DATAGeoCodes GeoCodes;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HOTEL_ADDITIONAL_DATAHotelProperties HotelProperties;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<HOTEL_ADDITIONAL_DATAHotelArrivalPointOthers> HotelArrivalPointOthers;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<HOTEL_ADDITIONAL_DATAHotelArrivalPoint> HotelArrivalPoints;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<HOTEL_ADDITIONAL_DATAHotelCity> HotelCities;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<HOTEL_ADDITIONAL_DATAHotelCityArea> HotelCityAreas;

        [JsonProperty(PropertyName = "@TELEPHONE_NO", NullValueHandling = NullValueHandling.Ignore)]
        public string TELEPHONE_NO;

        [JsonProperty(PropertyName = "@FAX_NO", NullValueHandling = NullValueHandling.Ignore)]
        public string FAX_NO;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BED_PICTURE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MAP_PICTURE;

        [JsonProperty(PropertyName = "@EMAIL", NullValueHandling = NullValueHandling.Ignore)]
        public string EMAIL;

        [JsonIgnore]
        public SearchBookingHARequest RequestHAData { get; set; }

        [JsonIgnore]
        public FreeNightsDetails FreeNightDetails { get; set; }

        // The following controls the display of the above fields. 
        // This avoids thh use of if statements by using the Newtonsoft ShouldSerialize prefix 
        // with the property name that needs displaying For HOTEL_AMENITY this would be ShouldSerializeHOTEL_AMENITY()- very neet!! 
        public bool ShouldSerializeHOTEL_AMENITY()
        {
            // don't serialize the HOTEL_AMENITY property if HOTEL_AMENITY is not required
            return RequestHAData.Data.AdditionalData[0].AmenityRequired;
        }

        public bool ShouldSerializeHOTEL_PICTURE()
        {
            // don't serialize the HOTEL_PICTURE property if HOTEL_PICTURE is not required
            return RequestHAData.Data.AdditionalData[0].PictureRequired;
        }

        public bool ShouldSerializeHOTEL_ADDRESS()
        {
            return RequestHAData.Data.AdditionalData[0].HotelAddressRequired;
        }

        public bool ShouldSerializeHotelDescription()
        {
            return RequestHAData.Data.AdditionalData[0].HotelDescriptionRequired;
        }

        public bool ShouldSerializeLocation()
        {
            return RequestHAData.Data.AdditionalData[0].LocationRequired;
        }

        public bool ShouldSerializeGeoCodes()
        {
            return RequestHAData.Data.AdditionalData[0].GeoCodesRequired;
        }

        public bool ShouldSerializeHotelProperties()
        {
            return RequestHAData.Data.AdditionalData[0].HotelPropertiesRequired;
        }

        public bool ShouldSerializeHotelArrivalPointOthers()
        {
            return RequestHAData.Data.AdditionalData[0].HotelArrivalPointOtherRequired;
        }

        public bool ShouldSerializeHotelArrivalPoints()
        {
            return RequestHAData.Data.AdditionalData[0].HotelArrivalPointRequired;
        }

        public bool ShouldSerializeTELEPHONE_NO()
        {
            return RequestHAData.Data.AdditionalData[0].TelephoneNumberRequired;
        }

        public bool ShouldSerializeFAX_NO()
        {
            return RequestHAData.Data.AdditionalData[0].FaxNumberRequired;
        }

        public bool ShouldSerializeEMAIL()
        {
            return RequestHAData.Data.AdditionalData[0].EmailAddressRequired;
        }

        public bool ShouldSerializeHotelCityAreas()
        {
            return RequestHAData.Data.AdditionalData[0].HotelCityRequired;
        }

        public bool ShouldSerializeHotelCities()
        {
            return RequestHAData.Data.AdditionalData[0].HotelCityRequired;
        }

        public bool ShouldSerializeEnglishTextNeed()
        {
            // don't serialize the HOTEL_AMENITY property if HOTEL_AMENITY is not required
            return RequestHAData.Data.AdditionalData[0].EnglishTextRequired;
        }

    }

    public partial class HOTEL_AMENITY_DATA
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_AMENITY_NAME;

        [JsonProperty(PropertyName = "@HOTEL_AMENITY_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_AMENITY_CODE;
    }

    public partial class HOTEL_ADDRESS
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ADDRESS_LINE1;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ADDRESS_LINE2;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CITY;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string STATE_OR_PROVINCE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string COUNTRY;
    }

    public partial class HOTEL_ADDITIONAL_DATAHotelDescription
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Overview;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Location;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Exterior;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LobbyAndInterior;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LeisureFacilities;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Rooms;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RestaurantsAndBars;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FamilyInformation;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OtherInformation;
    }

    public partial class HOTEL_ADDITIONAL_DATALocation
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string LocationName;

        [JsonProperty(PropertyName = "@LocationCode", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationCode;
    }

    public partial class HOTEL_ADDITIONAL_DATAGeoCodes
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Longitude;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Latitude;
    }

     public partial class HOTEL_ADDITIONAL_DATAHotelProperties
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Website;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CheckIn;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CheckOut;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NoOfDisabledRooms;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NoOfFloors;
    }

    public partial class HOTEL_ADDITIONAL_DATAHotelArrivalPointOthers
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<HOTEL_ADDITIONAL_DATAHotelArrivalPointOther> HotelArrivalPointOther { get; set;}
    }

    public partial class HOTEL_ADDITIONAL_DATAHotelArrivalPointOther
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ArrivalPointName;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Distance;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Units;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HOTEL_ADDITIONAL_DATAHotelArrivalPointOtherIsNearest IsNearest;

        [JsonProperty(PropertyName = "@ArrivalPointCategoryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ArrivalPointCategoryCode;
    }

    public enum HOTEL_ADDITIONAL_DATAHotelArrivalPointOtherIsNearest
    {
        yes,
        no,
    }

    public partial class HOTEL_ADDITIONAL_DATAHotelArrivalPoint
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ArrivalPointName;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ArrivalPtCode;
    }

    public partial class HOTEL_ADDITIONAL_DATAHotelCity
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HotelCityName;

        [JsonProperty(PropertyName = "@HotelCity", NullValueHandling = NullValueHandling.Ignore)]
        public string HotelCity;
    }

    public partial class HOTEL_ADDITIONAL_DATAHotelCityArea
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CityAreaName;

        [JsonProperty(PropertyName = "@CityAreaCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CityAreaCode;
    }

    public partial class HotelMessagesHotelMessage
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HotelMessageText;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HotelMessageCode;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FromDate;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ToDate;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HotelMessagesHotelMessageMessageIndicator MessageIndicator;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool MessageIndicatorSpecified;
    }

    public enum HotelMessagesHotelMessageMessageIndicator
    {

        Block,
        Information,
    }

    public partial class SubHotelData
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_NAME;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public RatePlanDetails RatePlanDetails;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CURRENCY_NAME;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //[System.Xml.Serialization.XmlElementAttribute("ROOM_DATA")]
        public List<ROOM_DATA> ROOM_DATA;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_PICTURE;

        [JsonProperty(PropertyName = "@HOTEL_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string HOTEL_CODE;

        [JsonProperty(PropertyName = "@CURRENCY_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string CURRENCY_CODE;

        [JsonProperty(PropertyName = "@STATUS", NullValueHandling = NullValueHandling.Ignore)]
        public string STATUS;
    }

    public partial class RatePlanDetails
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RatePlanDescription;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RatePlanCode;
    }

    public partial class ROOM_DATA
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ROOM_NAME;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ADULT_PRICE_DETAILS;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CHILD_PRICE_DETAILS;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SPECIAL_MESSAGE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MINIMUM_CHARGEABLE_DETAILS MINIMUM_CHARGEABLE_DETAILS;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ReducedPriceDetails ReducedPriceDetails;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public FreeNightsDetails FreeNightsDetails;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EarlyBirdDetails EarlyBirdDetails;

        [JsonProperty(PropertyName = "@ROOM_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string ROOM_CODE;

        [JsonProperty(PropertyName = "@ROOM_PAX", NullValueHandling = NullValueHandling.Ignore)]
        public string ROOM_PAX;

        [JsonProperty(PropertyName = "@ADULT_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ADULT_PRICE;

        [JsonProperty(PropertyName = "@CHILD_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CHILD_PRICE;

        [JsonProperty(PropertyName = "@TOTAL_ADULT_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TOTAL_ADULT_PRICE;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public bool TOTAL_ADULT_PRICESpecified;

        [JsonProperty(PropertyName = "@TOTAL_CHILD_PRICE", NullValueHandling = NullValueHandling.Ignore)]
        public decimal TOTAL_CHILD_PRICE;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public bool TOTAL_CHILD_PRICESpecified;

        [JsonProperty(PropertyName = "@PRICE_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string PRICE_CODE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SPECIAL_INDICATOR;

        [JsonProperty(PropertyName = "@CCHARGES_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string CCHARGES_CODE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string CCHARGES_OVERLAP_CODE;

        [JsonProperty(PropertyName = "@EXTRA_BED_INDICATOR", NullValueHandling = NullValueHandling.Ignore)]
        public string EXTRA_BED_INDICATOR;

        [JsonProperty(PropertyName = "@NO_OF_EXTRA_BEDS", NullValueHandling = NullValueHandling.Ignore)]
        public string NO_OF_EXTRA_BEDS;
    }

    public partial class MINIMUM_CHARGEABLE_DETAILS
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] MINIMUM_CHARGEABLE_MESSAGE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float MINIMUM_CHARGEABLE_ADULT_PRICE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool MINIMUM_CHARGEABLE_ADULT_PRICESpecified;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float MINIMUM_CHARGEABLE_CHILD_PRICE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool MINIMUM_CHARGEABLE_CHILD_PRICESpecified;
    }

    public partial class ReducedPriceDetails
    {

        [JsonProperty(PropertyName = "@AdultReductionAmount", NullValueHandling = NullValueHandling.Ignore)]
        public float AdultReductionAmount;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public bool AdultReductionAmountSpecified;

        [JsonProperty(PropertyName = "@AdultReductionPercentage", NullValueHandling = NullValueHandling.Ignore)]
        public decimal AdultReductionPercentage;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public bool AdultReductionPercentageSpecified;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public float ChildReductionAmount;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public bool ChildReductionAmountSpecified;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public decimal ChildReductionPercentage;

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        //public bool ChildReductionPercentageSpecified;
    }

     public partial class FreeNightsDetails
    {

        [JsonProperty(PropertyName = "@NoOfAdultFreeNights", NullValueHandling = NullValueHandling.Ignore)]
        public string NoOfAdultFreeNights;

        [JsonProperty(PropertyName = "@AdultFreeNightsPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal AdultFreeNightsPrice;

        //[JsonProperty(PropertyName = "@AdultFreeNightsPriceSpecified", NullValueHandling = NullValueHandling.Ignore)]
        //public bool AdultFreeNightsPriceSpecified;

        [JsonProperty(PropertyName = "@MinimumAdultDuration", NullValueHandling = NullValueHandling.Ignore)]
        public string MinimumAdultDuration;

        [JsonProperty(PropertyName = "@NoOfChildFreeNights", NullValueHandling = NullValueHandling.Ignore)]
        public string NoOfChildFreeNights;

        [JsonProperty(PropertyName = "@ChildFreeNightsPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal ChildFreeNightsPrice;

        [JsonProperty(PropertyName = "@ChildFreeNightsPriceSpecified", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChildFreeNightsPriceSpecified;

        [JsonProperty(PropertyName = "@MinimumChildDuration", NullValueHandling = NullValueHandling.Ignore)]
        public string MinimumChildDuration;
    }

    public partial class EarlyBirdDetails
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Percentage;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float ReductionAmount;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool ReductionAmountSpecified;
    }

    public partial class HotelMessages
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public HotelMessagesHotelMessage[] HotelMessage;
    }

    public partial class HOTEL_AMENITY
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<HOTEL_AMENITY_DATA> HOTEL_AMENITY_DATA;
    }

    public partial class Messages
    {       

        [JsonProperty(PropertyName = "@ERROR_CODE", NullValueHandling = NullValueHandling.Ignore)]
        public string ERROR_CODE;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ERROR_DESCRIPTION;

    }

}
