using System;
using System.ComponentModel;
using System.Xml.Serialization;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
namespace Travco.HIS.Model.Response.Error.HotelDescriptiveInfo
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot("Envelope",Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public class ErrorResponse
    {

        private object headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public object Header
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
    public class EnvelopeBody
    {

        private OTA_HotelAvailRS oTA_HotelAvailRSField;

        private string requestIdField;

        private string transactionField;

        /// <remarks/>
        [XmlElement(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelAvailRS OTA_HotelAvailRS
        {
            get
            {
                return oTA_HotelAvailRSField;
            }
            set
            {
                oTA_HotelAvailRSField = value;
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
    [XmlType(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    [XmlRoot(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
    public class OTA_HotelAvailRS
    {

        private OTA_HotelAvailRSErrors errorsField;

        private DateTime timeStampField;

        private string echoTokenField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        public OTA_HotelAvailRSErrors Errors
        {
            get
            {
                return errorsField;
            }
            set
            {
                errorsField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public DateTime TimeStamp
        {
            get
            {
                return timeStampField;
            }
            set
            {
                timeStampField = value;
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
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public class OTA_HotelAvailRSErrors
    {

        private OTA_HotelAvailRSErrorsError errorField;

        /// <remarks/>
        public OTA_HotelAvailRSErrorsError Error
        {
            get
            {
                return errorField;
            }
            set
            {
                errorField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public class OTA_HotelAvailRSErrorsError
    {

        private byte typeField;

        private string shortTextField;

        private string codeField;

        private string valueField;

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
        public string ShortText
        {
            get
            {
                return shortTextField;
            }
            set
            {
                shortTextField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Code
        {
            get
            {
                return codeField;
            }
            set
            {
                codeField = value;
            }
        }

        /// <remarks/>
        [XmlText]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }




}