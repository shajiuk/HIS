
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

namespace Travco.HIS.Model.Request.Reservation
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/",IsNullable = false)]
    public partial class ReservationsSingleRoomBooking
    {

        private EnvelopeHeader headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeHeader Header
        {
            get { return this.headerField; }
            set { this.headerField = value; }
        }

        /// <remarks/>
        public EnvelopeBody Body
        {
            get { return this.bodyField; }
            set { this.bodyField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private OTA_HotelResRQ oTA_HotelResRQField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelResRQ OTA_HotelResRQ
        {
            get { return this.oTA_HotelResRQField; }
            set { this.oTA_HotelResRQField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string RequestId
        {
            get { return this.requestIdField; }
            set { this.requestIdField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Transaction
        {
            get { return this.transactionField; }
            set { this.transactionField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class OTA_HotelResRQ
    {

        private OTA_HotelResRQHotelReservations hotelReservationsField;

        private string echoTokenField;

        private System.DateTime timeStampField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservations HotelReservations
        {
            get { return this.hotelReservationsField; }
            set { this.hotelReservationsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string EchoToken
        {
            get { return this.echoTokenField; }
            set { this.echoTokenField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime TimeStamp
        {
            get { return this.timeStampField; }
            set { this.timeStampField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Target
        {
            get { return this.targetField; }
            set { this.targetField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PrimaryLangID
        {
            get { return this.primaryLangIDField; }
            set { this.primaryLangIDField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservations
    {

        private OTA_HotelResRQHotelReservationsHotelReservation hotelReservationField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservation HotelReservation
        {
            get { return this.hotelReservationField; }
            set { this.hotelReservationField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservation
    {

        private OTA_HotelResRQHotelReservationsHotelReservationUniqueID uniqueIDField;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStays roomStaysField;

        private OTA_HotelResRQHotelReservationsHotelReservationResGuest[] resGuestsField;

        private bool roomStayReservationField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationUniqueID UniqueID
        {
            get { return this.uniqueIDField; }
            set { this.uniqueIDField = value; }
        }

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStays RoomStays
        {
            get { return this.roomStaysField; }
            set { this.roomStaysField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ResGuest", IsNullable = false)]
        public OTA_HotelResRQHotelReservationsHotelReservationResGuest[] ResGuests
        {
            get { return this.resGuestsField; }
            set { this.resGuestsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RoomStayReservation
        {
            get { return this.roomStayReservationField; }
            set { this.roomStayReservationField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationUniqueID
    {

        private byte typeField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStays
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStay roomStayField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStay RoomStay
        {
            get { return this.roomStayField; }
            set { this.roomStayField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStay
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes roomTypesField;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlans ratePlansField;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRates roomRatesField;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayGuestCount[] guestCountsField;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayTimeSpan timeSpanField;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments depositPaymentsField;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayBasicPropertyInfo basicPropertyInfoField
            ;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayResGuestRPH[] resGuestRPHsField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes RoomTypes
        {
            get { return this.roomTypesField; }
            set { this.roomTypesField = value; }
        }

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlans RatePlans
        {
            get { return this.ratePlansField; }
            set { this.ratePlansField = value; }
        }

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRates RoomRates
        {
            get { return this.roomRatesField; }
            set { this.roomRatesField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("GuestCount", IsNullable = false)]
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayGuestCount[] GuestCounts
        {
            get { return this.guestCountsField; }
            set { this.guestCountsField = value; }
        }

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayTimeSpan TimeSpan
        {
            get { return this.timeSpanField; }
            set { this.timeSpanField = value; }
        }

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments DepositPayments
        {
            get { return this.depositPaymentsField; }
            set { this.depositPaymentsField = value; }
        }

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayBasicPropertyInfo BasicPropertyInfo
        {
            get { return this.basicPropertyInfoField; }
            set { this.basicPropertyInfoField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ResGuestRPH", IsNullable = false)]
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayResGuestRPH[] ResGuestRPHs
        {
            get { return this.resGuestRPHsField; }
            set { this.resGuestRPHsField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomTypes
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomType roomTypeField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomType RoomType
        {
            get { return this.roomTypeField; }
            set { this.roomTypeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomTypesRoomType
    {

        private string roomTypeCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RoomTypeCode
        {
            get { return this.roomTypeCodeField; }
            set { this.roomTypeCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlans
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlan ratePlanField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlan RatePlan
        {
            get { return this.ratePlanField; }
            set { this.ratePlanField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlan
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanMealsIncluded
            mealsIncludedField;

        private uint ratePlanCodeField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanMealsIncluded
            MealsIncluded
        {
            get { return this.mealsIncludedField; }
            set { this.mealsIncludedField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint RatePlanCode
        {
            get { return this.ratePlanCodeField; }
            set { this.ratePlanCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRatePlansRatePlanMealsIncluded
    {

        private string mealPlanCodesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MealPlanCodes
        {
            get { return this.mealPlanCodesField; }
            set { this.mealPlanCodesField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRates
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRate roomRateField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRate RoomRate
        {
            get { return this.roomRateField; }
            set { this.roomRateField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRate
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRates ratesField;

        private System.DateTime effectiveDateField;

        private System.DateTime expireDateField;

        private uint roomTypeCodeField;

        private byte numberOfUnitsField;

        private uint ratePlanCodeField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRates Rates
        {
            get { return this.ratesField; }
            set { this.ratesField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime EffectiveDate
        {
            get { return this.effectiveDateField; }
            set { this.effectiveDateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime ExpireDate
        {
            get { return this.expireDateField; }
            set { this.expireDateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint RoomTypeCode
        {
            get { return this.roomTypeCodeField; }
            set { this.roomTypeCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte NumberOfUnits
        {
            get { return this.numberOfUnitsField; }
            set { this.numberOfUnitsField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint RatePlanCode
        {
            get { return this.ratePlanCodeField; }
            set { this.ratePlanCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRates
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate rateField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate Rate
        {
            get { return this.rateField; }
            set { this.rateField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRate
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase baseField
            ;

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal
            totalField;

        private System.DateTime effectiveDateField;

        private System.DateTime expireDateField;

        private string rateTimeUnitField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase Base
        {
            get { return this.baseField; }
            set { this.baseField = value; }
        }

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal Total
        {
            get { return this.totalField; }
            set { this.totalField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime EffectiveDate
        {
            get { return this.effectiveDateField; }
            set { this.effectiveDateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime ExpireDate
        {
            get { return this.expireDateField; }
            set { this.expireDateField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RateTimeUnit
        {
            get { return this.rateTimeUnitField; }
            set { this.rateTimeUnitField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateBase
    {

        private ushort amountBeforeTaxField;

        private ushort amountAfterTaxField;

        private string currencyCodeField;

        private byte decimalPlacesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort AmountBeforeTax
        {
            get { return this.amountBeforeTaxField; }
            set { this.amountBeforeTaxField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort AmountAfterTax
        {
            get { return this.amountAfterTaxField; }
            set { this.amountAfterTaxField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CurrencyCode
        {
            get { return this.currencyCodeField; }
            set { this.currencyCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte DecimalPlaces
        {
            get { return this.decimalPlacesField; }
            set { this.decimalPlacesField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayRoomRatesRoomRateRatesRateTotal
    {

        private uint amountBeforeTaxField;

        private uint amountAfterTaxField;

        private string currencyCodeField;

        private byte decimalPlacesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint AmountBeforeTax
        {
            get { return this.amountBeforeTaxField; }
            set { this.amountBeforeTaxField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint AmountAfterTax
        {
            get { return this.amountAfterTaxField; }
            set { this.amountAfterTaxField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CurrencyCode
        {
            get { return this.currencyCodeField; }
            set { this.currencyCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte DecimalPlaces
        {
            get { return this.decimalPlacesField; }
            set { this.decimalPlacesField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayGuestCount
    {

        private byte ageQualifyingCodeField;

        private byte countField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte AgeQualifyingCode
        {
            get { return this.ageQualifyingCodeField; }
            set { this.ageQualifyingCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Count
        {
            get { return this.countField; }
            set { this.countField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayTimeSpan
    {

        private System.DateTime startField;

        private System.DateTime endField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime Start
        {
            get { return this.startField; }
            set { this.startField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime End
        {
            get { return this.endField; }
            set { this.endField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPayments
    {

        private OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePayment
            guaranteePaymentField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePayment
            GuaranteePayment
        {
            get { return this.guaranteePaymentField; }
            set { this.guaranteePaymentField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePayment
    {

        private
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPayments
            acceptedPaymentsField;

        private
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAmountPercent
            amountPercentField;

        /// <remarks/>
        public
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPayments
            AcceptedPayments
        {
            get { return this.acceptedPaymentsField; }
            set { this.acceptedPaymentsField = value; }
        }

        /// <remarks/>
        public
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAmountPercent
            AmountPercent
        {
            get { return this.amountPercentField; }
            set { this.amountPercentField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class
        OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPayments
    {

        private
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPayment
            acceptedPaymentField;

        /// <remarks/>
        public
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPayment
            AcceptedPayment
        {
            get { return this.acceptedPaymentField; }
            set { this.acceptedPaymentField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class
        OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPayment
    {

        private
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPaymentPaymentCard
            paymentCardField;

        /// <remarks/>
        public
            OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPaymentPaymentCard
            PaymentCard
        {
            get { return this.paymentCardField; }
            set { this.paymentCardField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class
        OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPaymentPaymentCard
    {

        private byte cardTypeField;

        private string cardCodeField;

        private string cardNumberField;

        private ushort expireDateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte CardType
        {
            get { return this.cardTypeField; }
            set { this.cardTypeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CardCode
        {
            get { return this.cardCodeField; }
            set { this.cardCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CardNumber
        {
            get { return this.cardNumberField; }
            set { this.cardNumberField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ExpireDate
        {
            get { return this.expireDateField; }
            set { this.expireDateField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class
        OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayDepositPaymentsGuaranteePaymentAmountPercent
    {

        private decimal amountField;

        private string currencyCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Amount
        {
            get { return this.amountField; }
            set { this.amountField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CurrencyCode
        {
            get { return this.currencyCodeField; }
            set { this.currencyCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayBasicPropertyInfo
    {

        private string hotelCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HotelCode
        {
            get { return this.hotelCodeField; }
            set { this.hotelCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaysRoomStayResGuestRPH
    {

        private byte rPHField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte RPH
        {
            get { return this.rPHField; }
            set { this.rPHField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuest
    {

        private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfiles profilesField;

        private byte resGuestRPHField;

        private byte ageQualifyingCodeField;

        private byte ageField;

        private bool ageFieldSpecified;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfiles Profiles
        {
            get { return this.profilesField; }
            set { this.profilesField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ResGuestRPH
        {
            get { return this.resGuestRPHField; }
            set { this.resGuestRPHField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte AgeQualifyingCode
        {
            get { return this.ageQualifyingCodeField; }
            set { this.ageQualifyingCodeField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Age
        {
            get { return this.ageField; }
            set { this.ageField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AgeSpecified
        {
            get { return this.ageFieldSpecified; }
            set { this.ageFieldSpecified = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfiles
    {

        private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfo profileInfoField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfo ProfileInfo
        {
            get { return this.profileInfoField; }
            set { this.profileInfoField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfo
    {

        private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfile profileField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfile Profile
        {
            get { return this.profileField; }
            set { this.profileField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfile
    {

        private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumer consumerField;

        private byte profileTypeField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumer Consumer
        {
            get { return this.consumerField; }
            set { this.consumerField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ProfileType
        {
            get { return this.profileTypeField; }
            set { this.profileTypeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumer
    {

        private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumerPersonName
            personNameField;

        /// <remarks/>
        public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumerPersonName
            PersonName
        {
            get { return this.personNameField; }
            set { this.personNameField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class
        OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumerPersonName
    {

        private string givenNameField;

        private string surnameField;

        /// <remarks/>
        public string GivenName
        {
            get { return this.givenNameField; }
            set { this.givenNameField = value; }
        }

        /// <remarks/>
        public string Surname
        {
            get { return this.surnameField; }
            set { this.surnameField = value; }
        }
    }

}