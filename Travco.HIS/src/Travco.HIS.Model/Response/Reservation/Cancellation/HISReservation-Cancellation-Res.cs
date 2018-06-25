using System;
using System.ComponentModel;
using System.Xml.Serialization;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

namespace Travco.HIS.Model.Response.Reservation.Cancellation
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public class ReservationsCancellationRes
    {

        private EnvelopeHeader headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeHeader Header
        {
            get
            {
                return headerField;
            }
            set
            {
                headerField = value;
            }
        }

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return bodyField;
            }
            set
            {
                bodyField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class EnvelopeHeader
    {

        private Interface interfaceField;

        /// <remarks/>
        [XmlElement(Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
        public Interface Interface
        {
            get
            {
                return interfaceField;
            }
            set
            {
                interfaceField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
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
            get
            {
                return componentInfoField;
            }
            set
            {
                componentInfoField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ChannelIdentifierId
        {
            get
            {
                return channelIdentifierIdField;
            }
            set
            {
                channelIdentifierIdField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Version
        {
            get
            {
                return versionField;
            }
            set
            {
                versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute("Interface")]
        public string Interface1
        {
            get
            {
                return interface1Field;
            }
            set
            {
                interface1Field = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    public class InterfaceComponentInfo
    {

        private string userField;

        private string pwdField;

        private string componentTypeField;

        /// <remarks/>
        [XmlAttribute]
        public string User
        {
            get
            {
                return userField;
            }
            set
            {
                userField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Pwd
        {
            get
            {
                return pwdField;
            }
            set
            {
                pwdField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ComponentType
        {
            get
            {
                return componentTypeField;
            }
            set
            {
                componentTypeField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class EnvelopeBody
    {

        private OTA_CancelRS oTA_CancelRSField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_CancelRS OTA_CancelRS
        {
            get
            {
                return oTA_CancelRSField;
            }
            set
            {
                oTA_CancelRSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string RequestId
        {
            get
            {
                return requestIdField;
            }
            set
            {
                requestIdField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Transaction
        {
            get
            {
                return transactionField;
            }
            set
            {
                transactionField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
    public class OTA_CancelRS
    {

        private object successField;

        private OTA_Warning[] warningsField;

        private OTA_Error[] errorsField;

        private OTA_CancelRSUniqueID uniqueIDField;

        private OTA_CancelRSCancelInfoRS cancelInfoRSField;

        private string echoTokenField;

        private DateTime timeStampField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        private string statusField;

        /// <remarks/>
        public object Success
        {
            get
            {
                return successField;
            }
            set
            {
                successField = value;
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
        public OTA_CancelRSUniqueID UniqueID
        {
            get
            {
                return uniqueIDField;
            }
            set
            {
                uniqueIDField = value;
            }
        }

        /// <remarks/>
        public OTA_CancelRSCancelInfoRS CancelInfoRS
        {
            get
            {
                return cancelInfoRSField;
            }
            set
            {
                cancelInfoRSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string EchoToken
        {
            get
            {
                return echoTokenField;
            }
            set
            {
                echoTokenField = value;
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
        [XmlAttribute]
        public string Target
        {
            get
            {
                return targetField;
            }
            set
            {
                targetField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal Version
        {
            get
            {
                return versionField;
            }
            set
            {
                versionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string PrimaryLangID
        {
            get
            {
                return primaryLangIDField;
            }
            set
            {
                primaryLangIDField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Status
        {
            get
            {
                return statusField;
            }
            set
            {
                statusField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_CancelRSUniqueID
    {

        private byte typeField;

        private string idField;

        /// <remarks/>
        [XmlAttribute]
        public byte Type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ID
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_CancelRSCancelInfoRS
    {

        private OTA_CancelRSCancelInfoRSUniqueID uniqueIDField;

        /// <remarks/>
        public OTA_CancelRSCancelInfoRSUniqueID UniqueID
        {
            get
            {
                return uniqueIDField;
            }
            set
            {
                uniqueIDField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_CancelRSCancelInfoRSUniqueID
    {

        private byte typeField;

        private string idField;

        /// <remarks/>
        [XmlAttribute]
        public byte Type
        {
            get
            {
                return typeField;
            }
            set
            {
                typeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ID
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }
    }

}