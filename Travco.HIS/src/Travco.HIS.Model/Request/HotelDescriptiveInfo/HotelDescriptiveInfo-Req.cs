namespace Travco.HIS.Model.Request.HotelDescriptiveInfo
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class HotelDescriptiveInfoReq
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
    [System.Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/", IsNullable = false)]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttribute()]
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
        [System.Xml.Serialization.XmlAttribute("Interface")]
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    public partial class InterfaceComponentInfo
    {

        private string userField;

        private string pwdField;

        private string componentTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private OTA_HotelDescriptiveInfoRQ oTA_HotelDescriptiveInfoRQField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelDescriptiveInfoRQ OTA_HotelDescriptiveInfoRQ
        {
            get
            {
                return this.oTA_HotelDescriptiveInfoRQField;
            }
            set
            {
                this.oTA_HotelDescriptiveInfoRQField = value;
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
    public partial class OTA_HotelDescriptiveInfoRQ
    {

        private OTA_HotelDescriptiveInfoRQHotelDescriptiveInfos hotelDescriptiveInfosField;

        private string echoTokenField;

        private System.DateTime timeStampField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRQHotelDescriptiveInfos HotelDescriptiveInfos
        {
            get
            {
                return this.hotelDescriptiveInfosField;
            }
            set
            {
                this.hotelDescriptiveInfosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRQHotelDescriptiveInfos
    {

        private OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfo hotelDescriptiveInfoField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfo HotelDescriptiveInfo
        {
            get
            {
                return this.hotelDescriptiveInfoField;
            }
            set
            {
                this.hotelDescriptiveInfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfo
    {

        private OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoHotelInfo hotelInfoField;

        private OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAreaInfo areaInfoField;

        private OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAffiliationInfo affiliationInfoField;

        private OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoContactInfo contactInfoField;

        private string hotelCodeField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoHotelInfo HotelInfo
        {
            get
            {
                return this.hotelInfoField;
            }
            set
            {
                this.hotelInfoField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAreaInfo AreaInfo
        {
            get
            {
                return this.areaInfoField;
            }
            set
            {
                this.areaInfoField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAffiliationInfo AffiliationInfo
        {
            get
            {
                return this.affiliationInfoField;
            }
            set
            {
                this.affiliationInfoField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoContactInfo ContactInfo
        {
            get
            {
                return this.contactInfoField;
            }
            set
            {
                this.contactInfoField = value;
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
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoHotelInfo
    {

        private bool sendDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool SendData
        {
            get
            {
                return this.sendDataField;
            }
            set
            {
                this.sendDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAreaInfo
    {

        private bool sendRefPointsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool SendRefPoints
        {
            get
            {
                return this.sendRefPointsField;
            }
            set
            {
                this.sendRefPointsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoAffiliationInfo
    {

        private bool sendDistribSystemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool SendDistribSystems
        {
            get
            {
                return this.sendDistribSystemsField;
            }
            set
            {
                this.sendDistribSystemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRQHotelDescriptiveInfosHotelDescriptiveInfoContactInfo
    {

        private bool sendDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool SendData
        {
            get
            {
                return this.sendDataField;
            }
            set
            {
                this.sendDataField = value;
            }
        }
    }


}
