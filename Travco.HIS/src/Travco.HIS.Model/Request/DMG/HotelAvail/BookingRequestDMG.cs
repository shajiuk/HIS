﻿using Travco.HIS.Model.Request.HotelAvail;

namespace Travco.HIS.Model.Request.DMG.HotelAvail
{
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    // 
    // This source code was auto-generated by xsd, Version=4.6.1055.0.
    // 


    /// <remarks/>
    //[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    //[System.AttributeUsage()]
    //[System.Diagnostics.DebuggerStepThroughAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class BOOKING
    {

        /// <remarks/>
        public DATA DATA { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string type { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue("en-GB")]
        public string lang { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(BOOKINGNeedDTD.no)]
        public BOOKINGNeedDTD NeedDTD { get; set; }

        /// <remarks/>
        [XmlAttribute]        
        public string NeedCancellationDetails { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(BOOKINGReturnURLNeed.no)]
        public BOOKINGReturnURLNeed returnURLNeed { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string returnURL { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string AGENTCODE { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string AGENTPASSWORD { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public BOOKINGTOTAL_NO_OF_HOTELS_NEED TOTAL_NO_OF_HOTELS_NEED { get; set; }

        /// <remarks/>
        [XmlIgnore]
        public bool TOTAL_NO_OF_HOTELS_NEEDSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(BOOKINGAVAILABLE_HOTELS_ONLY.NO)]
        public BOOKINGAVAILABLE_HOTELS_ONLY
            AVAILABLE_HOTELS_ONLY { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string PAGE_SIZE { get; set; }

        [XmlIgnore]
        public HISHeaderInfoSA HishHeaderInfo { get; set; }

        [XmlIgnore]
        public AdditionalInfoSA AdditionalInfo { get; set; }

        [XmlIgnore]
        public int Debug { get; set; }

        public BOOKING()
        {
            type = "HA";
            //lang = "en-GB";
            NeedDTD = BOOKINGNeedDTD.no;
            returnURLNeed = BOOKINGReturnURLNeed.no;
            AVAILABLE_HOTELS_ONLY = BOOKINGAVAILABLE_HOTELS_ONLY.NO;

        }
    }


    public class HISHeaderInfo : IHISHeaderInfo
    {

        [XmlIgnore]
        public string RequestId { get; set; }

        [XmlIgnore]
        public string Transaction { get; set; }

        [XmlIgnore]
        public string EchoToken { get; set; }

        [XmlIgnore]
        public string Target { get; set; }

        [XmlIgnore]
        public string PrimaryLangID { get; set; }
        [XmlIgnore]
        public int Debug { get; set; }

    }

    public class HISHeaderInfoSA : HISHeaderInfo
    {
        [XmlIgnore]
        public Model.Request.HotelAvail.EnvelopeHeader Header { get; set; }
    }

    // This is used to store values to be used to filter the DMG data when returning back to HIS.
    // Thesse arent in the DMG query to pass in
    public class AdditionalInfoSA 
    {
        [XmlIgnore]
        public string MealCode { get; set; }

        [XmlIgnore]
        public string RatePlanCode { get; set; }

    }



    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    //// [System.SerializableAttribute()]
    [DebuggerStepThrough]
    // [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class DATA
    {

        /// <remarks/>
        [XmlElement("ROOMS_DATA")]
        public ROOMS_DATA[] ROOMS_DATA { get; set; }

        /// <remarks/>
        public DATE_DATA DATE_DATA { get; set; }

        /// <remarks/>
        [XmlElement("OPTIONAL_DATA")]
        public OPTIONAL_DATA[] OPTIONAL_DATA { get; set; }

        /// <remarks/>
        [XmlElement("ADDITIONAL_DATA")]
        public ADDITIONAL_DATA[] ADDITIONAL_DATA { get; set; }

        /// <remarks/>
        public REQUEST_PART REQUEST_PART { get; set; }

        /// <remarks/>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string HotelName { get; set; }

        /// <remarks/>
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("MultiStarRequest", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public string[]
            MultiStarsRequest { get; set; }

        /// <remarks/>
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("EdiCode", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public string[]
            MultiHotelsRequest { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string COUNTRY_CODE { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string CITY_CODE { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string EDI_CODE { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string CountryRegionCode { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string CityAreaCode { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string ClerkCode { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string ClerkPassword { get; set; }
    }

    /// <remarks/>
    // [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    //// [System.SerializableAttribute()]
    [DebuggerStepThrough]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class ROOMS_DATA
    {

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string SINGLE_ROOMS { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string DOUBLE_ROOMS { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string TRIPLE_ROOMS { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string QUAD_ROOMS { get; set; }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string DOUBLE_EXTRA_BEDS { get; set; }

        /// <remarks/>
        [XmlText]
        public string Value { get; set; }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [DebuggerStepThrough]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class DATE_DATA
    {

        /// <remarks/>
        [XmlAttribute]
        public string CHECK_IN_DATE { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string CHECK_OUT_DATE { get; set; }

        /// <remarks/>
        [XmlText]
        public string Value { get; set; }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [DebuggerStepThrough]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class OPTIONAL_DATA
    {

        /// <remarks/>
        [XmlAttribute]
        public string STAR_RATING { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public float BUDGET { get; set; }

        /// <remarks/>
        [XmlIgnore]
        public bool BUDGETSpecified { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string Location { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(OPTIONAL_DATANeedReductionAmount.NO)]
        public OPTIONAL_DATANeedReductionAmount
            NeedReductionAmount { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(OPTIONAL_DATANeedHotelMessages.NO)]
        public OPTIONAL_DATANeedHotelMessages
            NeedHotelMessages { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(OPTIONAL_DATANeedFreeNightDetails.NO)]
        public OPTIONAL_DATANeedFreeNightDetails
            NeedFreeNightDetails { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(OPTIONAL_DATASortingOrder.Low)]
        public OPTIONAL_DATASortingOrder SortingOrder { get; set; }

        /// <remarks/>
        [XmlText] public string Value;

        public OPTIONAL_DATA()
        {
            NeedReductionAmount = OPTIONAL_DATANeedReductionAmount.NO;
            NeedHotelMessages = OPTIONAL_DATANeedHotelMessages.NO;
            NeedFreeNightDetails = OPTIONAL_DATANeedFreeNightDetails.NO;
            SortingOrder = OPTIONAL_DATASortingOrder.Low;
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    //// [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum OPTIONAL_DATANeedReductionAmount
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum OPTIONAL_DATANeedHotelMessages
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum OPTIONAL_DATANeedFreeNightDetails
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    //// [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum OPTIONAL_DATASortingOrder
    {

        /// <remarks/>
        Low,

        /// <remarks/>
        High
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    //// [System.SerializableAttribute()]
    [DebuggerStepThrough]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class ADDITIONAL_DATA
    {

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAHOTEL_ADDRESS_NEED.NO)]
        public ADDITIONAL_DATAHOTEL_ADDRESS_NEED
            HOTEL_ADDRESS_NEED { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATATELEPHONE_NO_NEED.NO)]
        public ADDITIONAL_DATATELEPHONE_NO_NEED
            TELEPHONE_NO_NEED { get; set; }

        /// <remarks/>
        [XmlAttribute] [DefaultValue(ADDITIONAL_DATAFAX_NO_NEED.NO)] public ADDITIONAL_DATAFAX_NO_NEED FAX_NO_NEED;

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATABED_PICTURE_NEED.NO)]
        public ADDITIONAL_DATABED_PICTURE_NEED
            BED_PICTURE_NEED { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAMAP_PICTURE_NEED.NO)]
        public ADDITIONAL_DATAMAP_PICTURE_NEED
            MAP_PICTURE_NEED { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAEMAIL_NEED.NO)]
        public ADDITIONAL_DATAEMAIL_NEED EMAIL_NEED { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAPICTURE_NEED.NO)]
        public ADDITIONAL_DATAPICTURE_NEED PICTURE_NEED { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAAMENITY_NEED.NO)]
        public ADDITIONAL_DATAAMENITY_NEED AMENITY_NEED { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAHotelDescription.NO)]
        public ADDITIONAL_DATAHotelDescription
            HotelDescription { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAHotelCity.NO)]
        public ADDITIONAL_DATAHotelCity HotelCity { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAHotelArrivalPointOther.NO)]
        public
            ADDITIONAL_DATAHotelArrivalPointOther HotelArrivalPointOther { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAHotelArrivalPoint.NO)]
        public ADDITIONAL_DATAHotelArrivalPoint
            HotelArrivalPoint { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAGeoCodes.NO)]
        public ADDITIONAL_DATAGeoCodes GeoCodes { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAHotelProperties.NO)]
        public ADDITIONAL_DATAHotelProperties
            HotelProperties { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATALocation.NO)]
        public ADDITIONAL_DATALocation Location { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATACityArea.NO)]
        public ADDITIONAL_DATACityArea CityArea { get; set; }

        /// <remarks/>
        [XmlAttribute]
        [DefaultValue(ADDITIONAL_DATAEnglishTextNeed.NO)]
        public ADDITIONAL_DATAEnglishTextNeed
            EnglishTextNeed { get; set; }

        /// <remarks/>
        // [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }

        public ADDITIONAL_DATA()
        {



            BED_PICTURE_NEED = ADDITIONAL_DATABED_PICTURE_NEED.NO;
            MAP_PICTURE_NEED = ADDITIONAL_DATAMAP_PICTURE_NEED.NO;



            HotelDescription = ADDITIONAL_DATAHotelDescription.NO;
            HotelCity = ADDITIONAL_DATAHotelCity.NO;
            HotelArrivalPointOther = ADDITIONAL_DATAHotelArrivalPointOther.NO;
            HotelArrivalPoint = ADDITIONAL_DATAHotelArrivalPoint.NO;
            GeoCodes = ADDITIONAL_DATAGeoCodes.NO;
            HotelProperties = ADDITIONAL_DATAHotelProperties.NO;
            Location = ADDITIONAL_DATALocation.NO;
            CityArea = ADDITIONAL_DATACityArea.NO;
            EnglishTextNeed = ADDITIONAL_DATAEnglishTextNeed.NO;
        }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    //// [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAHOTEL_ADDRESS_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATATELEPHONE_NO_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAFAX_NO_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATABED_PICTURE_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAMAP_PICTURE_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAEMAIL_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    //// [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAPICTURE_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAAMENITY_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAHotelDescription
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAHotelCity
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAHotelArrivalPointOther
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAHotelArrivalPoint
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAGeoCodes
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAHotelProperties
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATALocation
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATACityArea
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum ADDITIONAL_DATAEnglishTextNeed
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [DebuggerStepThrough]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class REQUEST_PART
    {

        /// <remarks/>
        //  [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string STARTING_NUMBER { get; set; }

        /// <remarks/>
        //  [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string ENDING_NUMBER { get; set; }

        /// <remarks/>
        // [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum BOOKINGNeedDTD
    {

        /// <remarks/>
        yes,

        /// <remarks/>
        no
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum BOOKINGReturnURLNeed
    {

        /// <remarks/>
        yes,

        /// <remarks/>
        no
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum BOOKINGTOTAL_NO_OF_HOTELS_NEED
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }

    /// <remarks/>
    [GeneratedCode("xsd", "4.6.1055.0")]
    // [System.SerializableAttribute()]
    [XmlType(AnonymousType = true)]
    public enum BOOKINGAVAILABLE_HOTELS_ONLY
    {

        /// <remarks/>
        YES,

        /// <remarks/>
        NO
    }
}
