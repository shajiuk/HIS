using System.Collections.Generic;

namespace Travco.HIS.Model.Response.HotelDescriptiveInfo
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute("Envelope",Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class HotelDescriptiveInfoRes
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
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
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
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    [System.Xml.Serialization.XmlRoot(Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/", IsNullable = false)]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        [System.Xml.Serialization.XmlAttributeAttribute("Interface")]
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
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
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
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private OTA_HotelDescriptiveInfoRS oTA_HotelDescriptiveInfoRSField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelDescriptiveInfoRS OTA_HotelDescriptiveInfoRS
        {
            get
            {
                return this.oTA_HotelDescriptiveInfoRSField;
            }
            set
            {
                this.oTA_HotelDescriptiveInfoRSField = value;
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
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
    public partial class OTA_HotelDescriptiveInfoRS
    {

        private object successField;

        private OTA_Error[] errorField;

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContents hotelDescriptiveContentsField;

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

        [System.Xml.Serialization.XmlArrayItemAttribute("Error")]
        public OTA_Error[] Errors
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContents HotelDescriptiveContents
        {
            get
            {
                return this.hotelDescriptiveContentsField;
            }
            set
            {
                this.hotelDescriptiveContentsField = value;
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
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContents
    {

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent hotelDescriptiveContentField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent HotelDescriptiveContent
        {
            get
            {
                return this.hotelDescriptiveContentField;
            }
            set
            {
                this.hotelDescriptiveContentField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent
    {
        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentHotelInfo hotelInfoField;

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfos contactInfosField;

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions tPA_ExtensionsField;

        private string hotelCodeField;

        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentHotelInfo HotelInfo
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
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfos ContactInfos
        {
            get
            {
                return this.contactInfosField;
            }
            set
            {
                this.contactInfosField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions TPA_Extensions
        {
            get
            {
                return this.tPA_ExtensionsField;
            }
            set
            {
                this.tPA_ExtensionsField = value;
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
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentHotelInfo
    {

        private string hotelNameField;

        /// <remarks/>
        public string HotelName
        {
            get
            {
                return this.hotelNameField;
            }
            set
            {
                this.hotelNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfos
    {

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfo contactInfoField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfo ContactInfo
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfo
    {

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddresses addressesField;

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoPhones phonesField;

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoEmails emailsField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddresses Addresses
        {
            get
            {
                return this.addressesField;
            }
            set
            {
                this.addressesField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoPhones Phones
        {
            get
            {
                return this.phonesField;
            }
            set
            {
                this.phonesField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoEmails Emails
        {
            get
            {
                return this.emailsField;
            }
            set
            {
                this.emailsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddresses
    {

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddressesAddress addressField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddressesAddress Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddressesAddress
    {

        private string addressLineField;

        private string cityNameField;

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddressesAddressStateProv stateProvField;

        private string countryNameField;

        /// <remarks/>
        public string AddressLine
        {
            get
            {
                return this.addressLineField;
            }
            set
            {
                this.addressLineField = value;
            }
        }

        /// <remarks/>
        public string CityName
        {
            get
            {
                return this.cityNameField;
            }
            set
            {
                this.cityNameField = value;
            }
        }

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddressesAddressStateProv StateProv
        {
            get
            {
                return this.stateProvField;
            }
            set
            {
                this.stateProvField = value;
            }
        }

        /// <remarks/>
        public string CountryName
        {
            get
            {
                return this.countryNameField;
            }
            set
            {
                this.countryNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoAddressesAddressStateProv
    {

        private string stateCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StateCode
        {
            get
            {
                return this.stateCodeField;
            }
            set
            {
                this.stateCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoPhones
    {

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoPhonesPhone phoneField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoPhonesPhone Phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoPhonesPhone
    {

        private byte phoneTechTypeField;

        private string phoneNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte PhoneTechType
        {
            get
            {
                return this.phoneTechTypeField;
            }
            set
            {
                this.phoneTechTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoEmails
    {

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoEmailsEmail emailField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoEmailsEmail Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentContactInfosContactInfoEmailsEmail
    {

        private byte emailTypeField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte EmailType
        {
            get
            {
                return this.emailTypeField;
            }
            set
            {
                this.emailTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions
    {

        private OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension tPA_ExtensionField;

        /// <remarks/>
        public OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension TPA_Extension
        {
            get
            {
                return this.tPA_ExtensionField;
            }
            set
            {
                this.tPA_ExtensionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension
    {

        private List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension> extensionField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Extension")]
        public List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension> Extension
        {
            get
            {
                return this.extensionField;
            }
            set
            {
                this.extensionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension
    {

        private List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem> itemField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item")]
        public List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem> Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
    {

        private List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail> detailField;

        private string textField;

        private string keyField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Detail")]
        public List<OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail> Detail
        {
            get
            {
                return this.detailField;
            }
            set
            {
                this.detailField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class OTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
    {

        private string keyField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


}
