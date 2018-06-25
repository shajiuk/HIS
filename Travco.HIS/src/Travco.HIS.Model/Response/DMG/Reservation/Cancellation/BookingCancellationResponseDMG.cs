using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Travco.HIS.Model.Response.DMG.Reservation.Cancellation
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("RETURNDATA", Namespace = "", IsNullable = false)]
    public class RETURNDATABE
    {

        private RETURNDATABEDATA_HOTEL dATA_HOTELField;

        private string langField;

        private string typeField;

        /// <remarks/>
        public RETURNDATABEDATA_HOTEL DATA_HOTEL
        {
            get
            {
                return dATA_HOTELField;
            }
            set
            {
                dATA_HOTELField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string lang
        {
            get
            {
                return langField;
            }
            set
            {
                langField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string type
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
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RETURNDATABEDATA_HOTEL
    {

        private string hOTEL_NAMEField;

        private string rOOM_NAMEField;

        private string lEAD_PAX_NAMEField;

        private string aGENTS_REF_NOField;

        private string cURRENCY_NAMEField;

        private RETURNDATADATA_HOTELFULL_CANCELLATION_DETAILS fULL_CANCELLATION_DETAILSField;

        private RETURNDATADATA_HOTELRatePlanDetails ratePlanDetailsField;

        private string mainHotelNameField;

        private byte aDULTSField;

        private decimal aDULT_PRICEField;

        private string aRR_DATEField;

        private decimal cHILD_PRICEField;

        private string cLERK_CODEField;

        private string cURR_CODEField;

        private byte dURATIONField;

        private string hOTEL_CODEField;

        private byte iNTERNAL_CODE1Field;

        private byte iNTERNAL_CODE2Field;

        private string mainHotelCodeField;

        private byte nO_OF_ROOMSField;

        private string pRICE_CODEField;

        private string rOOM_CODEField;

        private string sTATUSField;

        private decimal tOTAL_PRICEField;

        private string tRAVCO_REF_NOField;

        /// <remarks/>
        public string HOTEL_NAME
        {
            get
            {
                return hOTEL_NAMEField;
            }
            set
            {
                hOTEL_NAMEField = value;
            }
        }

        /// <remarks/>
        public string ROOM_NAME
        {
            get
            {
                return rOOM_NAMEField;
            }
            set
            {
                rOOM_NAMEField = value;
            }
        }

        /// <remarks/>
        public string LEAD_PAX_NAME
        {
            get
            {
                return lEAD_PAX_NAMEField;
            }
            set
            {
                lEAD_PAX_NAMEField = value;
            }
        }

        /// <remarks/>
        public string AGENTS_REF_NO
        {
            get
            {
                return aGENTS_REF_NOField;
            }
            set
            {
                aGENTS_REF_NOField = value;
            }
        }

        /// <remarks/>
        public string CURRENCY_NAME
        {
            get
            {
                return cURRENCY_NAMEField;
            }
            set
            {
                cURRENCY_NAMEField = value;
            }
        }

        /// <remarks/>
        public RETURNDATADATA_HOTELFULL_CANCELLATION_DETAILS FULL_CANCELLATION_DETAILS
        {
            get
            {
                return fULL_CANCELLATION_DETAILSField;
            }
            set
            {
                fULL_CANCELLATION_DETAILSField = value;
            }
        }

        /// <remarks/>
        public RETURNDATADATA_HOTELRatePlanDetails RatePlanDetails
        {
            get
            {
                return ratePlanDetailsField;
            }
            set
            {
                ratePlanDetailsField = value;
            }
        }

        /// <remarks/>
        public string MainHotelName
        {
            get
            {
                return mainHotelNameField;
            }
            set
            {
                mainHotelNameField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte ADULTS
        {
            get
            {
                return aDULTSField;
            }
            set
            {
                aDULTSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal ADULT_PRICE
        {
            get
            {
                return aDULT_PRICEField;
            }
            set
            {
                aDULT_PRICEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ARR_DATE
        {
            get
            {
                return aRR_DATEField;
            }
            set
            {
                aRR_DATEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal CHILD_PRICE
        {
            get
            {
                return cHILD_PRICEField;
            }
            set
            {
                cHILD_PRICEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string CLERK_CODE
        {
            get
            {
                return cLERK_CODEField;
            }
            set
            {
                cLERK_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string CURR_CODE
        {
            get
            {
                return cURR_CODEField;
            }
            set
            {
                cURR_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte DURATION
        {
            get
            {
                return dURATIONField;
            }
            set
            {
                dURATIONField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string HOTEL_CODE
        {
            get
            {
                return hOTEL_CODEField;
            }
            set
            {
                hOTEL_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte INTERNAL_CODE1
        {
            get
            {
                return iNTERNAL_CODE1Field;
            }
            set
            {
                iNTERNAL_CODE1Field = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte INTERNAL_CODE2
        {
            get
            {
                return iNTERNAL_CODE2Field;
            }
            set
            {
                iNTERNAL_CODE2Field = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string MainHotelCode
        {
            get
            {
                return mainHotelCodeField;
            }
            set
            {
                mainHotelCodeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte NO_OF_ROOMS
        {
            get
            {
                return nO_OF_ROOMSField;
            }
            set
            {
                nO_OF_ROOMSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string PRICE_CODE
        {
            get
            {
                return pRICE_CODEField;
            }
            set
            {
                pRICE_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ROOM_CODE
        {
            get
            {
                return rOOM_CODEField;
            }
            set
            {
                rOOM_CODEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string STATUS
        {
            get
            {
                return sTATUSField;
            }
            set
            {
                sTATUSField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal TOTAL_PRICE
        {
            get
            {
                return tOTAL_PRICEField;
            }
            set
            {
                tOTAL_PRICEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string TRAVCO_REF_NO
        {
            get
            {
                return tRAVCO_REF_NOField;
            }
            set
            {
                tRAVCO_REF_NOField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RETURNDATADATA_HOTELFULL_CANCELLATION_DETAILS
    {

        private RETURNDATADATA_HOTELFULL_CANCELLATION_DETAILSCANCELLATION_DETAILS cANCELLATION_DETAILSField;

        /// <remarks/>
        public RETURNDATADATA_HOTELFULL_CANCELLATION_DETAILSCANCELLATION_DETAILS CANCELLATION_DETAILS
        {
            get
            {
                return cANCELLATION_DETAILSField;
            }
            set
            {
                cANCELLATION_DETAILSField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RETURNDATADATA_HOTELFULL_CANCELLATION_DETAILSCANCELLATION_DETAILS
    {

        private string cANCELLATION_CHARGEField;

        private string lAST_POSSIBLE_CANCELLATION_DATEField;

        private string tIME_BEFOREField;

        /// <remarks/>
        public string CANCELLATION_CHARGE
        {
            get
            {
                return cANCELLATION_CHARGEField;
            }
            set
            {
                cANCELLATION_CHARGEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string LAST_POSSIBLE_CANCELLATION_DATE
        {
            get
            {
                return lAST_POSSIBLE_CANCELLATION_DATEField;
            }
            set
            {
                lAST_POSSIBLE_CANCELLATION_DATEField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public string TIME_BEFORE
        {
            get
            {
                return tIME_BEFOREField;
            }
            set
            {
                tIME_BEFOREField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class RETURNDATADATA_HOTELRatePlanDetails
    {

        private string ratePlanDescriptionField;

        private byte ratePlanCodeField;

        /// <remarks/>
        public string RatePlanDescription
        {
            get
            {
                return ratePlanDescriptionField;
            }
            set
            {
                ratePlanDescriptionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte RatePlanCode
        {
            get
            {
                return ratePlanCodeField;
            }
            set
            {
                ratePlanCodeField = value;
            }
        }
    }


}

