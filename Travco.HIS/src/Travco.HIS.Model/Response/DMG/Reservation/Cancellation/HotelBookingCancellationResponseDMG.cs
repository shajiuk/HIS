using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Travco.HIS.Model.Response.DMG.Reservation.Cancellation
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("RETURNDATA",Namespace = "", IsNullable = false)]
    public partial class RETURNDATAHB
    {

        private RETURNDATADATA_HOTEL dATA_HOTELField;

        private string langField;

        private string typeField;

        /// <remarks/>
        public RETURNDATADATA_HOTEL DATA_HOTEL
        {
            get
            {
                return this.dATA_HOTELField;
            }
            set
            {
                this.dATA_HOTELField = value;
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
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class RETURNDATADATA_HOTEL
    {

        private RETURNDATADATA_HOTELMESSAGE mESSAGEField;

        private string pAX_NAMEField;

        private string aGENTS_REF_NOField;

        private string rOOM_NAMEField;

        private string pRICE_DISPField;

        private string cURRENCY_NAMEField;

        private string hotelNameField;

        private byte aDULTSField;

        private decimal aDULT_PRICEField;

        private string aRR_DATEField;

        private decimal cHILD_PRICEField;

        private string cURR_CODEField;

        private byte dURATIONField;

        private string hOTEL_CODEField;

        private byte nO_OF_ROOMSField;

        private string pRICE_CODEField;

        private string rOOM_CODEField;

        private string sTATUSField;

        private string tRAVCO_REF_NOField;

        /// <remarks/>
        public RETURNDATADATA_HOTELMESSAGE MESSAGE
        {
            get
            {
                return this.mESSAGEField;
            }
            set
            {
                this.mESSAGEField = value;
            }
        }

        /// <remarks/>
        public string PAX_NAME
        {
            get
            {
                return this.pAX_NAMEField;
            }
            set
            {
                this.pAX_NAMEField = value;
            }
        }

        /// <remarks/>
        public string AGENTS_REF_NO
        {
            get
            {
                return this.aGENTS_REF_NOField;
            }
            set
            {
                this.aGENTS_REF_NOField = value;
            }
        }

        /// <remarks/>
        public string ROOM_NAME
        {
            get
            {
                return this.rOOM_NAMEField;
            }
            set
            {
                this.rOOM_NAMEField = value;
            }
        }

        /// <remarks/>
        public string PRICE_DISP
        {
            get
            {
                return this.pRICE_DISPField;
            }
            set
            {
                this.pRICE_DISPField = value;
            }
        }

        /// <remarks/>
        public string CURRENCY_NAME
        {
            get
            {
                return this.cURRENCY_NAMEField;
            }
            set
            {
                this.cURRENCY_NAMEField = value;
            }
        }

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

        /// <remarks/>
        [XmlAttribute()]
        public byte ADULTS
        {
            get
            {
                return this.aDULTSField;
            }
            set
            {
                this.aDULTSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public decimal ADULT_PRICE
        {
            get
            {
                return this.aDULT_PRICEField;
            }
            set
            {
                this.aDULT_PRICEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ARR_DATE
        {
            get
            {
                return this.aRR_DATEField;
            }
            set
            {
                this.aRR_DATEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public decimal CHILD_PRICE
        {
            get
            {
                return this.cHILD_PRICEField;
            }
            set
            {
                this.cHILD_PRICEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string CURR_CODE
        {
            get
            {
                return this.cURR_CODEField;
            }
            set
            {
                this.cURR_CODEField = value;
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
        public byte NO_OF_ROOMS
        {
            get
            {
                return this.nO_OF_ROOMSField;
            }
            set
            {
                this.nO_OF_ROOMSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string PRICE_CODE
        {
            get
            {
                return this.pRICE_CODEField;
            }
            set
            {
                this.pRICE_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ROOM_CODE
        {
            get
            {
                return this.rOOM_CODEField;
            }
            set
            {
                this.rOOM_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string STATUS
        {
            get
            {
                return this.sTATUSField;
            }
            set
            {
                this.sTATUSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string TRAVCO_REF_NO
        {
            get
            {
                return this.tRAVCO_REF_NOField;
            }
            set
            {
                this.tRAVCO_REF_NOField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    public partial class RETURNDATADATA_HOTELMESSAGE
    {

        private string eRROR_DESCRIPTIONField;

        private string eRROR_CODEField;

        /// <remarks/>
        public string ERROR_DESCRIPTION
        {
            get
            {
                return this.eRROR_DESCRIPTIONField;
            }
            set
            {
                this.eRROR_DESCRIPTIONField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string ERROR_CODE
        {
            get
            {
                return this.eRROR_CODEField;
            }
            set
            {
                this.eRROR_CODEField = value;
            }
        }
    }


}
