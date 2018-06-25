using System;
using System.Collections.Generic;
using System.Text;

namespace Travco.HIS.Model.Response.HotelDescriptiveInfo
{


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRS
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRS[] oTA_HotelDescriptiveInfoRSField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("OTA_HotelDescriptiveInfoRS")]
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRS[] OTA_HotelDescriptiveInfoRS
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRS
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContents hotelDescriptiveContentsField;

        private System.DateTime timeStampField;

        private string echoTokenField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContents HotelDescriptiveContents
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContents
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent hotelDescriptiveContentField;

        /// <remarks/>
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent HotelDescriptiveContent
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContent
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions tPA_ExtensionsField;

        private string hotelCodeField;

        /// <remarks/>
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions TPA_Extensions
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_Extensions
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension tPA_ExtensionField;

        /// <remarks/>
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension TPA_Extension
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_Extension
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension[] extensionField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Extension")]
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension[] Extension
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtension
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem[] itemField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item")]
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem[] Item
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItem
    {

        private ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail[] detailField;

        private string[] textField;

        private string keyField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Detail")]
        public ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail[] Detail
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
        public string[] Text
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ArrayOfOTA_HotelDescriptiveInfoRSOTA_HotelDescriptiveInfoRSHotelDescriptiveContentsHotelDescriptiveContentTPA_ExtensionsTPA_ExtensionExtensionItemDetail
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