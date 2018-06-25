using System;
using System.ComponentModel;
using System.Xml.Serialization;

// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

namespace Travco.HIS.Model.Response.HotelAvail
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,
        Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/",
        IsNullable = false)]
    public class HotelAvailabilityRateplanRoomType
    {

        private EnvelopeHeader headerField;

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeHeader Header
        {
            get { return headerField; }
            set { headerField = value; }
        }

        /// <remarks/>
        public EnvelopeBody Body
        {
            get { return bodyField; }
            set { bodyField = value; }
        }
    }


    public class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidate
    {

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateMealsIncluded
            mealsIncludedField;

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateMealsIncluded
            MealsIncluded
        {
            get { return mealsIncludedField; }
            set { mealsIncludedField = value; }
        }

    }


    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class
        OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateMealsIncluded
    {

        private string mealPlanCodesField;

        /// <remarks/>
        [XmlAttribute]
        public string MealPlanCodes
        {
            get { return mealPlanCodesField; }
            set { mealPlanCodesField = value; }
        }
    }

}
