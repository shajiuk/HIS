using System.Collections.Generic;
using System.Xml.Serialization;
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
namespace Travco.HIS.Model.Response.Reservation
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class ReservationRes
    {

        private EnvelopeHeader headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeHeader
    {

        private Interface interfaceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
        public Interface Interface
        {
            get
            {
                return this.interfaceField;
            }
            set
            {
                this.interfaceField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    [XmlRoot(Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/", IsNullable = false)]
    public partial class Interface
    {

        private InterfaceComponentInfo componentInfoField;

        private string channelIdentifierIdField;

        private string versionField;

        private string interface1Field;

        /// <remarks/>
        public InterfaceComponentInfo ComponentInfo
        {
            get
            {
                return this.componentInfoField;
            }
            set
            {
                this.componentInfoField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ChannelIdentifierId
        {
            get
            {
                return this.channelIdentifierIdField;
            }
            set
            {
                this.channelIdentifierIdField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute("Interface")]
        public string Interface1
        {
            get
            {
                return this.interface1Field;
            }
            set
            {
                this.interface1Field = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    public partial class InterfaceComponentInfo
    {

        private string userField;

        private string pwdField;

        private string componentTypeField;

        /// <remarks/>
        [XmlAttribute()]
        public string User
        {
            get
            {
                return this.userField;
            }
            set
            {
                this.userField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Pwd
        {
            get
            {
                return this.pwdField;
            }
            set
            {
                this.pwdField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ComponentType
        {
            get
            {
                return this.componentTypeField;
            }
            set
            {
                this.componentTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private OTA_HotelResRS oTA_HotelResRSField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelResRS OTA_HotelResRS
        {
            get
            {
                return this.oTA_HotelResRSField;
            }
            set
            {
                this.oTA_HotelResRSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string RequestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Transaction
        {
            get
            {
                return this.transactionField;
            }
            set
            {
                this.transactionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
    public partial class OTA_HotelResRS
    {

        private object successField;

        private OTA_Warning[] warningsField;

        private OTA_Error[] errorsField;

        private OTA_HotelResRSHotelReservations hotelReservationsField;

        private System.DateTime timeStampField;

        private string echoTokenField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        public object Success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Warning", IsNullable = false)]
        public OTA_Warning[] Warnings
        {
            get
            {
                return this.warningsField;
            }
            set
            {
                this.warningsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Error", IsNullable = false)]
        public OTA_Error[] Errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservations HotelReservations
        {
            get
            {
                return this.hotelReservationsField;
            }
            set
            {
                this.hotelReservationsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public System.DateTime TimeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string EchoToken
        {
            get
            {
                return this.echoTokenField;
            }
            set
            {
                this.echoTokenField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Target
        {
            get
            {
                return this.targetField;
            }
            set
            {
                this.targetField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public decimal Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string PrimaryLangID
        {
            get
            {
                return this.primaryLangIDField;
            }
            set
            {
                this.primaryLangIDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservations
    {

        private OTA_HotelResRSHotelReservationsHotelReservation hotelReservationField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservation HotelReservation
        {
            get
            {
                return this.hotelReservationField;
            }
            set
            {
                this.hotelReservationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservation
    {

        private List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay> roomStaysField;

        private OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfo resGlobalInfoField;

        private System.DateTime createDateTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("RoomStay", IsNullable = false)]
        public List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay> RoomStays
        {
            get
            {
                return this.roomStaysField;
            }
            set
            {
                this.roomStaysField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfo ResGlobalInfo
        {
            get
            {
                return this.resGlobalInfoField;
            }
            set
            {
                this.resGlobalInfoField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public System.DateTime CreateDateTime
        {
            get
            {
                return this.createDateTimeField;
            }
            set
            {
                this.createDateTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStays
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay roomStayField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay RoomStay
        {
            get
            {
                return this.roomStayField;
            }
            set
            {
                this.roomStayField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStay
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes roomTypesField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlans ratePlansField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRates roomRatesField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayGuestCount[] guestCountsField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTimeSpan timeSpanField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments depositPaymentsField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenalties cancelPenaltiesField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTotal totalField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayBasicPropertyInfo basicPropertyInfoField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes RoomTypes
        {
            get
            {
                return this.roomTypesField;
            }
            set
            {
                this.roomTypesField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlans RatePlans
        {
            get
            {
                return this.ratePlansField;
            }
            set
            {
                this.ratePlansField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRates RoomRates
        {
            get
            {
                return this.roomRatesField;
            }
            set
            {
                this.roomRatesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("GuestCount", IsNullable = false)]
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayGuestCount[] GuestCounts
        {
            get
            {
                return this.guestCountsField;
            }
            set
            {
                this.guestCountsField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTimeSpan TimeSpan
        {
            get
            {
                return this.timeSpanField;
            }
            set
            {
                this.timeSpanField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments DepositPayments
        {
            get
            {
                return this.depositPaymentsField;
            }
            set
            {
                this.depositPaymentsField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenalties CancelPenalties
        {
            get
            {
                return this.cancelPenaltiesField;
            }
            set
            {
                this.cancelPenaltiesField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTotal Total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayBasicPropertyInfo BasicPropertyInfo
        {
            get
            {
                return this.basicPropertyInfoField;
            }
            set
            {
                this.basicPropertyInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomType roomTypeField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomType RoomType
        {
            get
            {
                return this.roomTypeField;
            }
            set
            {
                this.roomTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomType
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomTypeRoomDescription roomDescriptionField;

        private string roomTypeCodeField;

        private byte numberOfUnitsField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomTypeRoomDescription RoomDescription
        {
            get
            {
                return this.roomDescriptionField;
            }
            set
            {
                this.roomDescriptionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string RoomTypeCode
        {
            get
            {
                return this.roomTypeCodeField;
            }
            set
            {
                this.roomTypeCodeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte NumberOfUnits
        {
            get
            {
                return this.numberOfUnitsField;
            }
            set
            {
                this.numberOfUnitsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomTypeRoomDescription
    {

        private string textField;

        /// <remarks/>
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlans
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlan ratePlanField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlan RatePlan
        {
            get
            {
                return this.ratePlanField;
            }
            set
            {
                this.ratePlanField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlan
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanRatePlanDescription ratePlanDescriptionField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanMealsIncluded mealsIncludedField;

        private string ratePlanCodeField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanRatePlanDescription RatePlanDescription
        {
            get
            {
                return this.ratePlanDescriptionField;
            }
            set
            {
                this.ratePlanDescriptionField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanMealsIncluded MealsIncluded
        {
            get
            {
                return this.mealsIncludedField;
            }
            set
            {
                this.mealsIncludedField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string RatePlanCode
        {
            get
            {
                return this.ratePlanCodeField;
            }
            set
            {
                this.ratePlanCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanRatePlanDescription
    {

        private string nameField;

        /// <remarks/>
        [XmlAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanMealsIncluded
    {

        private string mealPlanCodesField;

        /// <remarks/>
        [XmlAttribute()]
        public string MealPlanCodes
        {
            get
            {
                return this.mealPlanCodesField;
            }
            set
            {
                this.mealPlanCodesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRates
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRate roomRateField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRate RoomRate
        {
            get
            {
                return this.roomRateField;
            }
            set
            {
                this.roomRateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRate
    {

        private List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate> ratesField;

        private byte numberOfUnitsField;

        private System.DateTime effectiveDateField;

        private System.DateTime expireDateField;

        private string roomTypeCodeField;

        private string ratePlanCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Rate", IsNullable = false)]
        public List<OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate> Rates
        {
            get
            {
                return this.ratesField;
            }
            set
            {
                this.ratesField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte NumberOfUnits
        {
            get
            {
                return this.numberOfUnitsField;
            }
            set
            {
                this.numberOfUnitsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public System.DateTime EffectiveDate
        {
            get
            {
                return this.effectiveDateField;
            }
            set
            {
                this.effectiveDateField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public System.DateTime ExpireDate
        {
            get
            {
                return this.expireDateField;
            }
            set
            {
                this.expireDateField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string RoomTypeCode
        {
            get
            {
                return this.roomTypeCodeField;
            }
            set
            {
                this.roomTypeCodeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string RatePlanCode
        {
            get
            {
                return this.ratePlanCodeField;
            }
            set
            {
                this.ratePlanCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRates
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate rateField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate Rate
        {
            get
            {
                return this.rateField;
            }
            set
            {
                this.rateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase baseField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal totalField;

        private System.DateTime effectiveDateField;

        private System.DateTime expireDateField;

        private string rateTimeUnitField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase Base
        {
            get
            {
                return this.baseField;
            }
            set
            {
                this.baseField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal Total
        {
            get
            {
                return this.totalField;
            }
            set
            {
                this.totalField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public System.DateTime EffectiveDate
        {
            get
            {
                return this.effectiveDateField;
            }
            set
            {
                this.effectiveDateField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public System.DateTime ExpireDate
        {
            get
            {
                return this.expireDateField;
            }
            set
            {
                this.expireDateField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string RateTimeUnit
        {
            get
            {
                return this.rateTimeUnitField;
            }
            set
            {
                this.rateTimeUnitField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase
    {

        private decimal amountBeforeTaxField;

        private decimal amountAfterTaxField;

        private byte decimalPlacesField;

        private string currencyCodeField;

        /// <remarks/>
        [XmlAttribute()]
        public decimal AmountBeforeTax
        {
            get
            {
                return this.amountBeforeTaxField;
            }
            set
            {
                this.amountBeforeTaxField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public decimal AmountAfterTax
        {
            get
            {
                return this.amountAfterTaxField;
            }
            set
            {
                this.amountAfterTaxField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte DecimalPlaces
        {
            get
            {
                return this.decimalPlacesField;
            }
            set
            {
                this.decimalPlacesField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CurrencyCode
        {
            get { return (currencyCodeField == "PDS" ? "GBP" : currencyCodeField); }
            set { this.currencyCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal
    {

        private decimal amountBeforeTaxField;

        private decimal amountAfterTaxField;

        private byte decimalPlacesField;

        private string currencyCodeField;

        /// <remarks/>
        [XmlAttribute()]
        public decimal AmountBeforeTax
        {
            get
            {
                return this.amountBeforeTaxField;
            }
            set
            {
                this.amountBeforeTaxField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public decimal AmountAfterTax
        {
            get
            {
                return this.amountAfterTaxField;
            }
            set
            {
                this.amountAfterTaxField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte DecimalPlaces
        {
            get
            {
                return this.decimalPlacesField;
            }
            set
            {
                this.decimalPlacesField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CurrencyCode
        {
            get { return (currencyCodeField == "PDS" ? "GBP" : currencyCodeField); }
            set { this.currencyCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayGuestCount
    {

        private byte ageQualifyingCodeField;

        private byte countField;

        /// <remarks/>
        [XmlAttribute()]
        public byte AgeQualifyingCode
        {
            get
            {
                return this.ageQualifyingCodeField;
            }
            set
            {
                this.ageQualifyingCodeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte Count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTimeSpan
    {

        private System.DateTime startField;

        private System.DateTime endField;

        private string durationField;

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public System.DateTime Start
        {
            get
            {
                return this.startField;
            }
            set
            {
                this.startField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public System.DateTime End
        {
            get
            {
                return this.endField;
            }
            set
            {
                this.endField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePayment guaranteePaymentField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePayment GuaranteePayment
        {
            get
            {
                return this.guaranteePaymentField;
            }
            set
            {
                this.guaranteePaymentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePayment
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAmountPercent amountPercentField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAmountPercent AmountPercent
        {
            get
            {
                return this.amountPercentField;
            }
            set
            {
                this.amountPercentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAmountPercent
    {

        private byte percentField;

        /// <remarks/>
        [XmlAttribute()]
        public byte Percent
        {
            get
            {
                return this.percentField;
            }
            set
            {
                this.percentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenalties
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenalty cancelPenaltyField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenalty CancelPenalty
        {
            get
            {
                return this.cancelPenaltyField;
            }
            set
            {
                this.cancelPenaltyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenalty
    {

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyDeadline deadlineField;

        private OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyAmountPercent amountPercentField;

        private string policyCodeField;

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyDeadline Deadline
        {
            get
            {
                return this.deadlineField;
            }
            set
            {
                this.deadlineField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyAmountPercent AmountPercent
        {
            get
            {
                return this.amountPercentField;
            }
            set
            {
                this.amountPercentField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string PolicyCode
        {
            get
            {
                return this.policyCodeField;
            }
            set
            {
                this.policyCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyDeadline
    {

        private string offsetTimeUnitField;

        private byte offsetUnitMultiplierField;

        /// <remarks/>
        [XmlAttribute()]
        public string OffsetTimeUnit
        {
            get
            {
                return this.offsetTimeUnitField;
            }
            set
            {
                this.offsetTimeUnitField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte OffsetUnitMultiplier
        {
            get
            {
                return this.offsetUnitMultiplierField;
            }
            set
            {
                this.offsetUnitMultiplierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayCancelPenaltiesCancelPenaltyAmountPercent
    {

        private int percentField;

        /// <remarks/>
        [XmlAttribute()]
        public int Percent
        {
            get
            {
                return this.percentField;
            }
            set
            {
                this.percentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayTotal
    {

        private string amountBeforeTaxField;

        private string amountAfterTaxField;

        private byte decimalPlacesField;

        private string currencyCodeField;

        /// <remarks/>
        [XmlAttribute()]
        public string AmountBeforeTax
        {
            get
            {
                return this.amountBeforeTaxField;
            }
            set
            {
                this.amountBeforeTaxField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string AmountAfterTax
        {
            get
            {
                return this.amountAfterTaxField;
            }
            set
            {
                this.amountAfterTaxField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte DecimalPlaces
        {
            get
            {
                return this.decimalPlacesField;
            }
            set
            {
                this.decimalPlacesField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CurrencyCode
        {
            get { return (currencyCodeField == "PDS" ? "GBP" : currencyCodeField); }
            set { this.currencyCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationRoomStaysRoomStayBasicPropertyInfo
    {

        private string hotelCodeField;

        /// <remarks/>
        [XmlAttribute()]
        public string HotelCode
        {
            get
            {
                return this.hotelCodeField;
            }
            set
            {
                this.hotelCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfo
    {

        private OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfoHotelReservationID[] hotelReservationIDsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("HotelReservationID", IsNullable = false)]
        public OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfoHotelReservationID[] HotelReservationIDs
        {
            get
            {
                return this.hotelReservationIDsField;
            }
            set
            {
                this.hotelReservationIDsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class OTA_HotelResRSHotelReservationsHotelReservationResGlobalInfoHotelReservationID
    {

        private byte resID_TypeField;

        private string resID_ValueField;

        private string resID_SourceField;

        private System.DateTime resID_DateField;

        /// <remarks/>
        [XmlAttribute()]
        public byte ResID_Type
        {
            get
            {
                return this.resID_TypeField;
            }
            set
            {
                this.resID_TypeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ResID_Value
        {
            get
            {
                return this.resID_ValueField;
            }
            set
            {
                this.resID_ValueField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ResID_Source
        {
            get
            {
                return this.resID_SourceField;
            }
            set
            {
                this.resID_SourceField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public System.DateTime ResID_Date
        {
            get
            {
                return this.resID_DateField;
            }
            set
            {
                this.resID_DateField = value;
            }
        }
    }



}
