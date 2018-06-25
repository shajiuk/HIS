using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Travco.HIS.Model.Response.DMG.SearchAvailability
{
    [XmlRoot(ElementName = "RatePlanDetails")]
    public class RatePlanDetails
    {
        [XmlElement(ElementName = "RatePlanDescription")]
        public string RatePlanDescription { get; set; }

        [XmlAttribute(AttributeName = "RatePlanCode")]
        public string RatePlanCode { get; set; }
    }

    [XmlRoot(ElementName = "ROOM_DATA")]
    public class ROOM_DATA
    {
        [XmlElement(ElementName = "ROOM_NAME")]
        public string ROOM_NAME { get; set; }

        [XmlElement(ElementName = "ADULT_PRICE_DETAILS")]
        public string ADULT_PRICE_DETAILS { get; set; }

        [XmlElement(ElementName = "CHILD_PRICE_DETAILS")]
        public string CHILD_PRICE_DETAILS { get; set; }

        [XmlElement(ElementName = "MINIMUM_CHARGEABLE_DETAILS")]
        public string MINIMUM_CHARGEABLE_DETAILS { get; set; }

        [XmlAttribute(AttributeName = "ADULT_PRICE")]
        public string ADULT_PRICE { get; set; }

        [XmlAttribute(AttributeName = "CCHARGES_CODE")]
        public string CCHARGES_CODE { get; set; }

        [XmlAttribute(AttributeName = "CHILD_PRICE")]
        public string CHILD_PRICE { get; set; }

        [XmlAttribute(AttributeName = "EXTRA_BED_INDICATOR")]
        public string EXTRA_BED_INDICATOR { get; set; }

        [XmlAttribute(AttributeName = "NO_OF_EXTRA_BEDS")]
        public string NO_OF_EXTRA_BEDS { get; set; }

        [XmlAttribute(AttributeName = "PRICE_CODE")]
        public string PRICE_CODE { get; set; }

        [XmlAttribute(AttributeName = "ROOM_CODE")]
        public string ROOM_CODE { get; set; }

        [XmlAttribute(AttributeName = "ROOM_PAX")]
        public string ROOM_PAX { get; set; }

        [XmlAttribute(AttributeName = "TOTAL_ADULT_PRICE")]
        public string TOTAL_ADULT_PRICE { get; set; }

        [XmlElement(ElementName = "SPECIAL_MESSAGE")]
        public string SPECIAL_MESSAGE { get; set; }

        [XmlAttribute(AttributeName = "SPECIAL_INDICATOR")]
        public string SPECIAL_INDICATOR { get; set; }

        [XmlElement(ElementName = "EarlyBirdDetails")]
        public EarlyBirdDetails EarlyBirdDetails { get; set; }
    }

    [XmlRoot(ElementName = "SubHotelData")]
    public class SubHotelData
    {
        [XmlElement(ElementName = "HOTEL_NAME")]
        public string HOTEL_NAME { get; set; }

        [XmlElement(ElementName = "RatePlanDetails")]
        public RatePlanDetails RatePlanDetails { get; set; }

        [XmlElement(ElementName = "CURRENCY_NAME")]
        public string CURRENCY_NAME { get; set; }

        [XmlElement(ElementName = "ROOM_DATA")]
        public List<ROOM_DATA> ROOM_DATA { get; set; }

        public CancellationDetails CancellationDetails { get; set; }

        [XmlAttribute(AttributeName = "CURRENCY_CODE")]
        public string CURRENCY_CODE { get; set; }

        [XmlAttribute(AttributeName = "HOTEL_CODE")]
        public string HOTEL_CODE { get; set; }

        [XmlAttribute(AttributeName = "STATUS")]
        public string STATUS { get; set; }
    }

    [XmlRoot(ElementName = "HOTEL_DATA")]
    public class HOTEL_DATA
    {
        [XmlElement(ElementName = "HOTEL_NAME")]
        public string HOTEL_NAME { get; set; }

        [XmlElement(ElementName = "HOTEL_STAR")]
        public string HOTEL_STAR { get; set; }

        [XmlElement(ElementName = "SubHotelData")]
        public List<SubHotelData> SubHotelData { get; set; }

        [XmlAttribute(AttributeName = "HOTEL_CODE")]
        public string HOTEL_CODE { get; set; }

        [XmlAttribute(AttributeName = "STATUS")]
        public string STATUS { get; set; }
    }

    [XmlRoot(ElementName = "EarlyBirdDetails")]
    public class EarlyBirdDetails
    {
        [XmlAttribute(AttributeName = "Percentage")]
        public string Percentage { get; set; }

        [XmlAttribute(AttributeName = "ReductionAmount")]
        public string ReductionAmount { get; set; }
    }

    [XmlRoot(ElementName = "DATA")]
    public class DATA
    {
        [XmlElement(ElementName = "COUNTRY_NAME")]
        public string COUNTRY_NAME { get; set; }

        [XmlElement(ElementName = "CITY_NAME")]
        public string CITY_NAME { get; set; }

        [XmlElement(ElementName = "HOTEL_DATA")]
        public List<HOTEL_DATA> HOTEL_DATA { get; set; }

        [XmlAttribute(AttributeName = "CHECK_IN_DATE")]
        public string CHECK_IN_DATE { get; set; }

        [XmlAttribute(AttributeName = "CHECK_OUT_DATE")]
        public string CHECK_OUT_DATE { get; set; }

        [XmlAttribute(AttributeName = "CITY_CODE")]
        public string CITY_CODE { get; set; }

        [XmlAttribute(AttributeName = "COUNTRY_CODE")]
        public string COUNTRY_CODE { get; set; }

        [XmlAttribute(AttributeName = "NO_OF_ADULTS")]
        public string NO_OF_ADULTS { get; set; }

        [XmlAttribute(AttributeName = "NO_OF_CHILDREN")]
        public string NO_OF_CHILDREN { get; set; }
    }

    [XmlRoot(ElementName = "RETURNDATA")]
    public class RETURNDATA
    {
        [XmlElement(ElementName = "MESSAGE")]
        public string MESSAGE { get; set; }

        [XmlElement(ElementName = "DATA")]
        public DATA DATA { get; set; }

        [XmlAttribute(AttributeName = "lang")]
        public string Lang { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation",
            Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string NoNamespaceSchemaLocation { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }

    }

    [XmlRoot(ElementName = "CancellationDetails")]
    public class CancellationDetails
    {        
        public FULL_CANCELLATION_DETAILS FULL_CANCELLATION_DETAILS { get; set; }

        public RETURNDATADATAHOTEL_DATASubHotelDataCancellationDetailsCancellationCharge CancellationCharge { get; set; }
    }
   
    [XmlRoot(ElementName = "FULL_CANCELLATION_DETAILS")]
    public class FULL_CANCELLATION_DETAILS
    {        
        public DETAILS DETAILS { get; set; }
      
        [XmlAttribute]
        public ushort CCHARGES_CODE { get; set; }
        
    }
    
    [XmlRoot(ElementName = "DETAILS")]
    public class DETAILS
    {        
        public string FULL_CANCELLATION_POLICY { get; set; }
        
        public MESSAGE MESSAGE { get; set; }
        
        [XmlAttribute]
        public string EFFECTIVE_FROM { get; set; }
        
        [XmlAttribute]
        public int NO_OF_DAYS_BEFORE_ARRIVAL { get; set; }
        
        [XmlAttribute]
        public string TIME_AFTER { get; set; }
    }
    
    [XmlRoot(ElementName = "MESSAGE")]
    public class MESSAGE
    {
        
        [XmlAttribute]
        public string LAST_DATE_BY_WHICH_TO_CANCEL { get; set; }
        
        [XmlAttribute]
        public string TIME_BEFORE { get; set; }
    }


    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RETURNDATADATAHOTEL_DATASubHotelDataCancellationDetailsCancellationCharge
    {
        /// <remarks/>
        public RETURNDATADATAHOTEL_DATASubHotelDataCancellationDetailsCancellationChargeFirstCancellationCharge FirstCancellationCharge { get; set; }
        /// <remarks/>
        [XmlAttribute]
        public string Before { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string LastDateToCancelWithoutCharge { get; set; }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RETURNDATADATAHOTEL_DATASubHotelDataCancellationDetailsCancellationChargeFirstCancellationCharge
    {
        /// <remarks/>
        public string FullCancellationNarrative { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string After { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public decimal AtPercentage { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string FirstCancellationChargeDate { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public byte NoOfNts { get; set; }
    }
}