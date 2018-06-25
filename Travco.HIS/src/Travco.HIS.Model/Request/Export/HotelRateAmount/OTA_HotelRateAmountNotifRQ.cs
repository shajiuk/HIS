using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travco.HIS.Model.Request.Export.HotelRateAmount
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class HotelRateAmountNotifRQ
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private OTA_HotelRateAmountNotifRQ oTA_HotelRateAmountNotifRQField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelRateAmountNotifRQ OTA_HotelRateAmountNotifRQ
        {
            get
            {
                return this.oTA_HotelRateAmountNotifRQField;
            }
            set
            {
                this.oTA_HotelRateAmountNotifRQField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
    public partial class OTA_HotelRateAmountNotifRQ
    {

        private OTA_HotelRateAmountNotifRQRateAmountMessages rateAmountMessagesField;

        private string targetField;

        private System.DateTime timeStampField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        public OTA_HotelRateAmountNotifRQRateAmountMessages RateAmountMessages
        {
            get
            {
                return this.rateAmountMessagesField;
            }
            set
            {
                this.rateAmountMessagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelRateAmountNotifRQRateAmountMessages
    {

        private OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage[] rateAmountMessageField;

        private string hotelCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("RateAmountMessage")]
        public OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage[] RateAmountMessage
        {
            get
            {
                return this.rateAmountMessageField;
            }
            set
            {
                this.rateAmountMessageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessage
    {

        private OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageStatusApplicationControl statusApplicationControlField;

        private OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRate[] ratesField;

        /// <remarks/>
        public OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageStatusApplicationControl StatusApplicationControl
        {
            get
            {
                return this.statusApplicationControlField;
            }
            set
            {
                this.statusApplicationControlField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Rate", IsNullable = false)]
        public OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRate[] Rates
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageStatusApplicationControl
    {

        private System.DateTime startField;

        private System.DateTime endField;

        private string ratePlanCodeField;

        private string invCodeField;

        private byte isRoomField;

        private string invCodeApplicationField;

        private string ratePlanCodeTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InvCode
        {
            get
            {
                return this.invCodeField;
            }
            set
            {
                this.invCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte IsRoom
        {
            get
            {
                return this.isRoomField;
            }
            set
            {
                this.isRoomField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string InvCodeApplication
        {
            get
            {
                return this.invCodeApplicationField;
            }
            set
            {
                this.invCodeApplicationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RatePlanCodeType
        {
            get
            {
                return this.ratePlanCodeTypeField;
            }
            set
            {
                this.ratePlanCodeTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRate
    {

        private OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt[] baseByGuestAmtsField;

        private byte numberOfUnitsField;

        private string rateTimeUnitField;

        private byte unitMultiplierField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("BaseByGuestAmt", IsNullable = false)]
        public OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt[] BaseByGuestAmts
        {
            get
            {
                return this.baseByGuestAmtsField;
            }
            set
            {
                this.baseByGuestAmtsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte UnitMultiplier
        {
            get
            {
                return this.unitMultiplierField;
            }
            set
            {
                this.unitMultiplierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelRateAmountNotifRQRateAmountMessagesRateAmountMessageRateBaseByGuestAmt
    {

        private decimal amountBeforeTaxField;

        private decimal amountAfterTaxField;

        private string currencyCodeField;

        private int decimalPlacesField;

        private byte ageQualifyingCodeField;

        private int numberOfGuestsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int DecimalPlaces
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int NumberOfGuests
        {
            get
            {
                return this.numberOfGuestsField;
            }
            set
            {
                this.numberOfGuestsField = value;
            }
        }
    }


}
