using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Travco.HIS.Model.Request.DMG.Reservation.Cancellation
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("BOOKING", Namespace = "", IsNullable = false)]
    public partial class BookingEnquiry
    {

        private BookingEnquiryHeader hEADERField;

        private BookingEnquiryData dATAField;

        private string typeField;

        private string langField;

        private string needDTDField;

        private string returnURLNeedField;

        private string returnURLField;

        private string aGENTCODEField;

        private string aGENTPASSWORDField;

        [XmlIgnore]
        public HISHeaderInfoResCanx HishHeaderInfo { get; set; }
        /// <remarks/>
        public BookingEnquiryHeader HEADER
        {
            get
            {
                return this.hEADERField;
            }
            set
            {
                this.hEADERField = value;
            }
        }

        /// <remarks/>
        public BookingEnquiryData DATA
        {
            get
            {
                return this.dATAField;
            }
            set
            {
                this.dATAField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string lang
        {
            get
            {
                return this.langField;
            }
            set
            {
                this.langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string NeedDTD
        {
            get
            {
                return this.needDTDField;
            }
            set
            {
                this.needDTDField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string returnURLNeed
        {
            get
            {
                return this.returnURLNeedField;
            }
            set
            {
                this.returnURLNeedField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string returnURL
        {
            get
            {
                return this.returnURLField;
            }
            set
            {
                this.returnURLField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string AGENTCODE
        {
            get
            {
                return this.aGENTCODEField;
            }
            set
            {
                this.aGENTCODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string AGENTPASSWORD
        {
            get
            {
                return this.aGENTPASSWORDField;
            }
            set
            {
                this.aGENTPASSWORDField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType("BOOKINGHEADER",AnonymousType = true)]
    public partial class BookingEnquiryHeader
    {

        private string iNTERNAL_CODE1Field;

        private string iNTERNAL_CODE2Field;

        private string iNTERNAL_CODE3Field;

        /// <remarks/>
        public string INTERNAL_CODE1
        {
            get
            {
                return this.iNTERNAL_CODE1Field;
            }
            set
            {
                this.iNTERNAL_CODE1Field = value;
            }
        }

        /// <remarks/>
        public string INTERNAL_CODE2
        {
            get
            {
                return this.iNTERNAL_CODE2Field;
            }
            set
            {
                this.iNTERNAL_CODE2Field = value;
            }
        }

        /// <remarks/>
        public string INTERNAL_CODE3
        {
            get
            {
                return this.iNTERNAL_CODE3Field;
            }
            set
            {
                this.iNTERNAL_CODE3Field = value;
            }
        }

        public string INTERNAL_CODE4 { get; set; }
        public string INTERNAL_CODE7 { get; set; }
        public string INTERNAL_CODE8 { get; set; }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType("BOOKINGDATA", AnonymousType = true)]
    public partial class BookingEnquiryData
    {
        /// <remarks/>
        [XmlAttribute()]
        public string REF_NO { get; set; }

        public string OUR_REF_NO { get; set; }

    }


}
