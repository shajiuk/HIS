using System.Xml.Serialization;
using Travco.HIS.Model.Request.DMG.HotelAvail;

namespace Travco.HIS.Model.Request.DMG.Reservation.Cancellation
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class BOOKING
    {

        private BOOKINGHEADER hEADERField;

        private BOOKINGDATA dATAField;

        private string typeField;

        private string langField;

        private string needDTDField;

        private BOOKINGReturnURLNeed returnURLNeedField;

        private string returnURLField;

        private string aGENTCODEField;

        private string aGENTPASSWORDField;

        [XmlIgnore]
        public HISHeaderInfoResCanx HishHeaderInfo { get; set; }

        /// <remarks/>
        public BOOKINGHEADER HEADER
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
        public BOOKINGDATA DATA
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
        public BOOKINGReturnURLNeed returnURLNeed
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

    public class HISHeaderInfo : IHISHeaderInfo
    {
        [XmlIgnore]
        public EnvelopeHeader Header { get; set; }

        [XmlIgnore]
        public string RequestId { get; set; }

        [XmlIgnore]
        public string Transaction { get; set; }

        [XmlIgnore]
        public string EchoToken { get; set; }

        [XmlIgnore]
        public string Target { get; set; }

        [XmlIgnore]
        public string PrimaryLangID { get; set; }

    }

    public class HISHeaderInfoResCanx : HISHeaderInfo
    {
        [XmlIgnore]
        public EnvelopeHeader Header { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class BOOKINGHEADER
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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class BOOKINGDATA
    {

        private string hOTEL_CODEField;

        private string cHECK_IN_DATEField;

        private byte dURATIONField;

        private string cCHARGES_CODEField;

        /// <remarks/>
        [XmlAttribute()]
        public string HOTEL_CODE
        {
            get
            {
                return this.hOTEL_CODEField;
            }
            set
            {
                this.hOTEL_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CHECK_IN_DATE
        {
            get
            {
                return this.cHECK_IN_DATEField;
            }
            set
            {
                this.cHECK_IN_DATEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public byte DURATION
        {
            get
            {
                return this.dURATIONField;
            }
            set
            {
                this.dURATIONField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CCHARGES_CODE
        {
            get
            {
                return this.cCHARGES_CODEField;
            }
            set
            {
                this.cCHARGES_CODEField = value;
            }
        }
    }


}
