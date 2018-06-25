namespace Travco.HIS.Model.Request.Export.HotelAvail
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class HotelAvailNotifRQ
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

        private OTA_HotelAvailNotifRQ oTA_HotelAvailNotifRQField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelAvailNotifRQ OTA_HotelAvailNotifRQ
        {
            get
            {
                return this.oTA_HotelAvailNotifRQField;
            }
            set
            {
                this.oTA_HotelAvailNotifRQField = value;
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
    public partial class OTA_HotelAvailNotifRQ
    {

        private OTA_HotelAvailNotifRQAvailStatusMessages availStatusMessagesField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        private System.DateTime timeStampField;

        /// <remarks/>
        public OTA_HotelAvailNotifRQAvailStatusMessages AvailStatusMessages
        {
            get
            {
                return this.availStatusMessagesField;
            }
            set
            {
                this.availStatusMessagesField = value;
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelAvailNotifRQAvailStatusMessages
    {

        private OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage[] availStatusMessageField;

        private string hotelCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("AvailStatusMessage")]
        public OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage[] AvailStatusMessage
        {
            get
            {
                return this.availStatusMessageField;
            }
            set
            {
                this.availStatusMessageField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessage
    {

        private OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl statusApplicationControlField;

        private OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus restrictionStatusField;

        private OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStay lengthsOfStayField;

        private byte bookingLimitField;

        private string bookingLimitMessageTypeField;

        /// <remarks/>
        public OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl StatusApplicationControl
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
        public OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus RestrictionStatus
        {
            get
            {
                return this.restrictionStatusField;
            }
            set
            {
                this.restrictionStatusField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStay LengthsOfStay
        {
            get
            {
                return this.lengthsOfStayField;
            }
            set
            {
                this.lengthsOfStayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte BookingLimit
        {
            get
            {
                return this.bookingLimitField;
            }
            set
            {
                this.bookingLimitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BookingLimitMessageType
        {
            get
            {
                return this.bookingLimitMessageTypeField;
            }
            set
            {
                this.bookingLimitMessageTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageStatusApplicationControl
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageRestrictionStatus
    {

        private string restrictionField;

        private string statusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Restriction
        {
            get
            {
                return this.restrictionField;
            }
            set
            {
                this.restrictionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStay
    {

        private OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay[] lengthOfStayField;

        private byte arrivalDateBasedField;

        private int? fixedPatternLengthField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LengthOfStay")]
        public OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay[] LengthOfStay
        {
            get
            {
                return this.lengthOfStayField;
            }
            set
            {
                this.lengthOfStayField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ArrivalDateBased
        {
            get
            {
                return this.arrivalDateBasedField;
            }
            set
            {
                this.arrivalDateBasedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FixedPatternLength
        {
            get
            {
                return this.fixedPatternLengthField.HasValue ? fixedPatternLengthField.Value.ToString() : null;
            }
            set
            {
                this.fixedPatternLengthField = value == null ? (int?)null : System.Convert.ToInt32(value);
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelAvailNotifRQAvailStatusMessagesAvailStatusMessageLengthsOfStayLengthOfStay
    {

        private string minMaxMessageTypeField;

        private string timeUnitField;

        private int timeField;

        private bool openStatusIndicatorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MinMaxMessageType
        {
            get
            {
                return this.minMaxMessageTypeField;
            }
            set
            {
                this.minMaxMessageTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TimeUnit
        {
            get
            {
                return this.timeUnitField;
            }
            set
            {
                this.timeUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool OpenStatusIndicator
        {
            get
            {
                return this.openStatusIndicatorField;
            }
            set
            {
                this.openStatusIndicatorField = value;
            }
        }
    }




}