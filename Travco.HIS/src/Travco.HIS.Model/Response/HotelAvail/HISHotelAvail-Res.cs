using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

namespace Travco.HIS.Model.Response.HotelAvail
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public class OTA_HotelAvailRQRS
    {

        private EnvelopeHeader headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeHeader Header
        {
            get { return headerField; }
            set { headerField = value; }
        }

        /// <remarks/>
        public EnvelopeBody Body
        {
            get { return bodyField; }
            set { bodyField = value; }
        }
    }

    public interface IEnvelopeHeader
    {
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class EnvelopeHeader : IEnvelopeHeader
    {

        private Interface interfaceField;

        /// <remarks/>
        [XmlElement(Namespace ="http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
        public Interface Interface
        {
            get { return interfaceField; }
            set { interfaceField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    [XmlRoot(Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/", IsNullable = false)]
    public class Interface
    {

        private InterfaceComponentInfo componentInfoField;

        private string channelIdentifierIdField;

        private string versionField;

        private string interface1Field;

        /// <remarks/>
        public InterfaceComponentInfo ComponentInfo
        {
            get { return componentInfoField; }
            set { componentInfoField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ChannelIdentifierId
        {
            get { return channelIdentifierIdField; }
            set { channelIdentifierIdField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Version
        {
            get { return versionField; }
            set { versionField = value; }
        }

        /// <remarks/>
        [XmlAttribute("Interface")]
        public string Interface1
        {
            get { return interface1Field; }
            set { interface1Field = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    public class InterfaceComponentInfo
    {

        private string userField;

        private string pwdField;

        private string componentTypeField;

        /// <remarks/>
        [XmlAttribute]
        public string User
        {
            get { return userField; }
            set { userField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Pwd
        {
            get { return pwdField; }
            set { pwdField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ComponentType
        {
            get { return componentTypeField; }
            set { componentTypeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,
        Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class EnvelopeBody
    {

        private OTA_HotelAvailRS oTA_HotelAvailRSField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>       
        [XmlElement(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelAvailRS OTA_HotelAvailRS
        {
            get { return oTA_HotelAvailRSField; }
            set { oTA_HotelAvailRSField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string RequestId
        {
            get { return requestIdField; }
            set { requestIdField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Transaction
        {
            get { return transactionField; }
            set { transactionField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    [XmlRoot(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
    public class OTA_HotelAvailRS
    {

        private object successField;

        private List<OTA_HotelAvailRSRoomStay> roomStaysField;

        private DateTime timeStampField;

        private string echoTokenField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        public object Success
        {
            get { return successField; }
            set { successField = value; }
        }

        /// <remarks/>
        [XmlArrayItem("RoomStay", IsNullable = false)]
        public List<OTA_HotelAvailRSRoomStay> RoomStays
        {
            get { return roomStaysField; }
            set { roomStaysField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public DateTime TimeStamp
        {
            get { return timeStampField; }
            set { timeStampField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string EchoToken
        {
            get { return echoTokenField; }
            set { echoTokenField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Target
        {
            get { return targetField; }
            set { targetField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal Version
        {
            get { return versionField; }
            set { versionField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string PrimaryLangID
        {
            get { return primaryLangIDField; }
            set { primaryLangIDField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStay
    {

        private OTA_HotelAvailRSRoomStayRoomTypes roomTypesField;

        private OTA_HotelAvailRSRoomStayRatePlans ratePlansField;

        private List<OTA_HotelAvailRSRoomStayRoomRate> roomRatesField;

        private OTA_HotelAvailRSRoomStayGuestCountsGuestCount[] guestCountsField;

        private OTA_HotelAvailRSRoomStayTimeSpan timeSpanField;

        private OTA_HotelAvailRSRoomStayDepositPayments depositPaymentsField;

        private OTA_HotelAvailRSRoomStayCancelPenalties cancelPenaltiesField;

        private OTA_HotelAvailRSRoomStayTotal totalField;

        private OTA_HotelAvailRSRoomStayBasicPropertyInfo basicPropertyInfoField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRoomTypes RoomTypes
        {
            get { return roomTypesField; }
            set { roomTypesField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRatePlans RatePlans
        {
            get { return ratePlansField; }
            set { ratePlansField = value; }
        }

        /// <remarks/>
        [XmlArrayItem("RoomRate", IsNullable = false)]
        public List<OTA_HotelAvailRSRoomStayRoomRate> RoomRates
        {
            get { return roomRatesField; }
            set { roomRatesField = value; }
        }

        /// <remarks/>
        [XmlArrayItem("GuestCount", IsNullable = false)]
        public OTA_HotelAvailRSRoomStayGuestCountsGuestCount[] GuestCounts
        {
            get { return guestCountsField; }
            set { guestCountsField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayTimeSpan TimeSpan
        {
            get { return timeSpanField; }
            set { timeSpanField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayDepositPayments DepositPayments
        {
            get
            {
                return depositPaymentsField;
            }
            set
            {
                depositPaymentsField = value;
            }
        }
        public OTA_HotelAvailRSRoomStayCancelPenalties CancelPenalties
        {
            get { return cancelPenaltiesField; }
            set { cancelPenaltiesField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayTotal Total
        {
            get { return totalField; }
            set { totalField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayBasicPropertyInfo BasicPropertyInfo
        {
            get { return basicPropertyInfoField; }
            set { basicPropertyInfoField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRoomTypes
    {

        private OTA_HotelAvailRSRoomStayRoomTypesRoomType roomTypeField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRoomTypesRoomType RoomType
        {
            get { return roomTypeField; }
            set { roomTypeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public  class OTA_HotelAvailRSRoomStayRoomTypesRoomType
    {

        private OTA_HotelAvailRSRoomStayRoomTypesRoomTypeRoomDescription roomDescriptionField;

        private string roomTypeCodeField;

        private string numberOfUnitsField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRoomTypesRoomTypeRoomDescription RoomDescription
        {
            get { return roomDescriptionField; }
            set { roomDescriptionField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RoomTypeCode
        {
            get { return roomTypeCodeField; }
            set { roomTypeCodeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string NumberOfUnits
        {
            get { return numberOfUnitsField; }
            set { numberOfUnitsField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRoomTypesRoomTypeRoomDescription
    {

        private string textField;

        /// <remarks/>
        public string Text
        {
            get { return textField; }
            set { textField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRatePlans
    {

        private OTA_HotelAvailRSRoomStayRatePlansRatePlan ratePlanField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRatePlansRatePlan RatePlan
        {
            get { return ratePlanField; }
            set { ratePlanField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRatePlansRatePlan
    {

        private OTA_HotelAvailRSRoomStayRatePlansRatePlanRatePlanDescription ratePlanDescriptionField;

        private OTA_HotelAvailRSRoomStayRatePlansRatePlanMealsIncluded mealsIncludedField;

        private string ratePlanCodeField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRatePlansRatePlanRatePlanDescription RatePlanDescription
        {
            get { return ratePlanDescriptionField; }
            set { ratePlanDescriptionField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRatePlansRatePlanMealsIncluded MealsIncluded
        {
            get { return mealsIncludedField; }
            set { mealsIncludedField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RatePlanCode
        {
            get { return ratePlanCodeField; }
            set { ratePlanCodeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRatePlansRatePlanRatePlanDescription
    {

        private string nameField;

        /// <remarks/>
        [XmlAttribute]
        public string Name
        {
            get { return nameField; }
            set { nameField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRatePlansRatePlanMealsIncluded
    {

        private string mealPlanCodesField;

        /// <remarks/>
        [XmlAttribute]
        public string MealPlanCodes
        {
            get { return mealPlanCodesField; }
            set { mealPlanCodesField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRoomRate
    {


        private List<OTA_HotelAvailRSRoomStayRoomRateRate> ratesField;

        private string numberOfUnitsField;

        private DateTime effectiveDateField;

        private DateTime expireDateField;

        private string roomTypeCodeField;

        private string ratePlanCodeField;

        /// <remarks/>
        [XmlArrayItem("Rate", IsNullable = false)]
        public List<OTA_HotelAvailRSRoomStayRoomRateRate> Rates
        {
            get { return ratesField; }
            set { ratesField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string NumberOfUnits
        {
            get { return numberOfUnitsField; }
            set { numberOfUnitsField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime EffectiveDate
        {
            get { return effectiveDateField; }
            set { effectiveDateField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime ExpireDate
        {
            get { return expireDateField; }
            set { expireDateField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RoomTypeCode
        {
            get { return roomTypeCodeField; }
            set { roomTypeCodeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RatePlanCode
        {
            get { return ratePlanCodeField; }
            set { ratePlanCodeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRoomRateRate
    {


        private OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateBase baseField;

        private OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateTotal totalField;

        private DateTime effectiveDateField;

        private DateTime expireDateField;

        private string rateTimeUnitField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateBase Base
        {
            get { return baseField; }
            set { baseField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateTotal Total
        {
            get { return totalField; }
            set { totalField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime EffectiveDate
        {
            get { return effectiveDateField; }
            set { effectiveDateField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime ExpireDate
        {
            get { return expireDateField; }
            set { expireDateField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RateTimeUnit
        {
            get { return rateTimeUnitField; }
            set { rateTimeUnitField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateBase
    {

        private decimal amountBeforeTaxField;

        private decimal amountAfterTaxField;

        private byte decimalPlacesField;

        private string currencyCodeField;

        /// <remarks/>
        [XmlAttribute]
        public decimal AmountBeforeTax
        {
            get { return amountBeforeTaxField; }
            set { amountBeforeTaxField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal AmountAfterTax
        {
            get { return amountAfterTaxField; }
            set { amountAfterTaxField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte DecimalPlaces
        {
            get { return decimalPlacesField; }
            set { decimalPlacesField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string CurrencyCode
        {
            get { return (currencyCodeField == "PDS" ? "GBP" : currencyCodeField);  }
            set { currencyCodeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayRoomRatesRoomRateRatesRateTotal
    {

        private decimal amountBeforeTaxField;

        private decimal amountAfterTaxField;

        private byte decimalPlacesField;

        private string currencyCodeField;

        /// <remarks/>
        [XmlAttribute]
        public decimal AmountBeforeTax
        {
            get { return amountBeforeTaxField; }
            set { amountBeforeTaxField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal AmountAfterTax
        {
            get { return amountAfterTaxField; }
            set { amountAfterTaxField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte DecimalPlaces
        {
            get { return decimalPlacesField; }
            set { decimalPlacesField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string CurrencyCode
        {
            get { return (currencyCodeField == "PDS" ? "GBP" : currencyCodeField); }
            set { currencyCodeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayGuestCounts
    {

        private OTA_HotelAvailRSRoomStayGuestCountsGuestCount guestCountField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayGuestCountsGuestCount GuestCount
        {
            get { return guestCountField; }
            set { guestCountField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayGuestCountsGuestCount
    {

        private byte ageQualifyingCodeField;

        private byte countField;

        /// <remarks/>
        [XmlAttribute]
        public byte AgeQualifyingCode
        {
            get { return ageQualifyingCodeField; }
            set { ageQualifyingCodeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte Count
        {
            get { return countField; }
            set { countField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayTimeSpan
    {

        private DateTime startField;

        private DateTime endField;

        private string durationField;

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime Start
        {
            get { return startField; }
            set { startField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime End
        {
            get { return endField; }
            set { endField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Duration
        {
            get { return durationField; }
            set { durationField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayDepositPayments
    {

        private OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePayment guaranteePaymentField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePayment GuaranteePayment
        {
            get
            {
                return guaranteePaymentField;
            }
            set
            {
                guaranteePaymentField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePayment
    {

        private OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePaymentAmountPercent amountPercentField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePaymentAmountPercent AmountPercent
        {
            get
            {
                return amountPercentField;
            }
            set
            {
                amountPercentField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayDepositPaymentsGuaranteePaymentAmountPercent
    {

        private byte percentField;

        private byte nmbrOfNightsField;

        /// <remarks/>
        [XmlAttribute]
        public byte Percent
        {
            get
            {
                return percentField;
            }
            set
            {
                percentField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte NmbrOfNights
        {
            get
            {
                return nmbrOfNightsField;
            }
            set
            {
                nmbrOfNightsField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayCancelPenalties
    {

        private OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenalty cancelPenaltyField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenalty CancelPenalty
        {
            get { return cancelPenaltyField; }
            set { cancelPenaltyField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenalty
    {

        private OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyDeadline deadlineField;

        private OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyAmountPercent amountPercentField;

        private string policyCodeField;

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyDeadline Deadline
        {
            get { return deadlineField; }
            set { deadlineField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyAmountPercent AmountPercent
        {
            get { return amountPercentField; }
            set { amountPercentField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string PolicyCode
        {
            get { return policyCodeField; }
            set { policyCodeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyDeadline
    {

        private string offsetTimeUnitField;

        private int offsetUnitMultiplierField;

        /// <remarks/>
        [XmlAttribute]
        public string OffsetTimeUnit
        {
            get { return offsetTimeUnitField; }
            set { offsetTimeUnitField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public int OffsetUnitMultiplier
        {
            get { return offsetUnitMultiplierField; }
            set { offsetUnitMultiplierField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public DateTime AbsoluteDeadline {get;set;}

    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayCancelPenaltiesCancelPenaltyAmountPercent
    {

        private byte nmbrOfNightsField;

        /// <remarks/>
        [XmlAttribute]
        public byte NmbrOfNights
        {
            get { return nmbrOfNightsField; }
            set { nmbrOfNightsField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayTotal
    {

        private decimal amountBeforeTaxField;

        private decimal amountAfterTaxField;

        private byte decimalPlacesField;

        private string currencyCodeField;

        /// <remarks/>
        [XmlAttribute]
        public decimal AmountBeforeTax
        {
            get { return amountBeforeTaxField; }
            set { amountBeforeTaxField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal AmountAfterTax
        {
            get { return amountAfterTaxField; }
            set { amountAfterTaxField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte DecimalPlaces
        {
            get { return decimalPlacesField; }
            set { decimalPlacesField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string CurrencyCode
        {
            get { return (currencyCodeField == "PDS" ? "GBP" : currencyCodeField); }
            set { currencyCodeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRSRoomStayBasicPropertyInfo
    {

        private string hotelCodeField;

        /// <remarks/>
        [XmlAttribute]
        public string HotelCode
        {
            get { return hotelCodeField; }
            set { hotelCodeField = value; }
        }
    }

}