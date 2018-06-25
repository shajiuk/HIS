
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Travco.HIS.Model.Request.HotelAvail
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public class HotelAvail
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

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,
        Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class EnvelopeHeader
    {

        private Interface interfaceField;

        /// <remarks/>
        [XmlElement(Namespace =
            "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
        public Interface Interface
        {
            get { return interfaceField; }
            set { interfaceField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,
        Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    [XmlRoot(
        Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/", IsNullable = false)]
    public class Interface
    {

        private InterfaceComponentInfo componentInfoField;

        private string channelIdentifierIdField;

        private string versionField;

        private string interface1Field;

        /// <remarks/>
        public InterfaceComponentInfo ComponentInfo
        {
            get { return componentInfoField; }
            set { componentInfoField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ChannelIdentifierId
        {
            get { return channelIdentifierIdField; }
            set { channelIdentifierIdField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Version
        {
            get { return versionField; }
            set { versionField = value; }
        }

        /// <remarks/>
        [XmlAttribute("Interface")]
        public string Interface1
        {
            get { return interface1Field; }
            set { interface1Field = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,
        Namespace = "http://api.hotels-vacation.com/Documentation/XML/OTA/4/2011B/")]
    public class InterfaceComponentInfo
    {

        private string userField;

        private string pwdField;

        private string componentTypeField;

        /// <remarks/>
        [XmlAttribute]
        public string User
        {
            get { return userField; }
            set { userField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Pwd
        {
            get { return pwdField; }
            set { pwdField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string ComponentType
        {
            get { return componentTypeField; }
            set { componentTypeField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true,
        Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class EnvelopeBody
    {

        private OTA_HotelAvailRQ oTA_HotelAvailRQField;

        private string requestIdField;

        private string transactionField;

        [XmlAttribute(Namespace = "")]
        public int Debug { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelAvailRQ OTA_HotelAvailRQ
        {
            get { return oTA_HotelAvailRQField; }
            set { oTA_HotelAvailRQField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string RequestId
        {
            get { return requestIdField; }
            set { requestIdField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Transaction
        {
            get { return transactionField; }
            set { transactionField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class OTA_HotelAvailRQ
    {

        private OTA_HotelAvailRQAvailRequestSegments availRequestSegmentsField;

        private string echoTokenField;

        private DateTime timeStampField;

        private string targetField;

        private decimal versionField;

        private string primaryLangIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
        public OTA_HotelAvailRQAvailRequestSegments AvailRequestSegments
        {
            get { return availRequestSegmentsField; }
            set { availRequestSegmentsField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "integer")]
        public string EchoToken
        {
            get { return echoTokenField; }
            set { echoTokenField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public DateTime TimeStamp
        {
            get { return timeStampField; }
            set { timeStampField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Target
        {
            get { return targetField; }
            set { targetField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public decimal Version
        {
            get { return versionField; }
            set { versionField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string PrimaryLangID
        {
            get { return primaryLangIDField; }
            set { primaryLangIDField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRQAvailRequestSegments
    {

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegment availRequestSegmentField;

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegment AvailRequestSegment
        {
            get { return availRequestSegmentField; }
            set { availRequestSegmentField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegment
    {

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentStayDateRange stayDateRangeField;

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidates ratePlanCandidatesField;

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate[] roomStayCandidatesField;

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentStayDateRange StayDateRange
        {
            get { return stayDateRangeField; }
            set { stayDateRangeField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidates RatePlanCandidates
        {
            get { return ratePlanCandidatesField; }
            set { ratePlanCandidatesField = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("RoomStayCandidate", IsNullable = false)]
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate[] RoomStayCandidates
        {
            get { return roomStayCandidatesField; }
            set { roomStayCandidatesField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentStayDateRange
    {

        private DateTime startField;

        private string durationField;

        private DateTime endField;

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime Start
        {
            get { return startField; }
            set { startField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string Duration
        {
            get { return durationField; }
            set { durationField = value; }
        }

        /// <remarks/>
        [XmlAttribute(DataType = "date")]
        public DateTime End
        {
            get { return endField; }
            set { endField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidates
    {

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidate
            ratePlanCandidateField;

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidate
            RatePlanCandidate
        {
            get { return ratePlanCandidateField; }
            set { ratePlanCandidateField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidate
    {

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefs
            hotelRefsField;

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateMealsIncluded mealsIncludedField;


        private byte ratePlanTypeField;

        private string ratePlanCodeField;

        private string RPHField;

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefs
            HotelRefs
        {
            get { return hotelRefsField; }
            set { hotelRefsField = value; }
        }

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateMealsIncluded MealsIncluded
        {
            get
            {
                return this.mealsIncludedField;
            }
            set
            {
                this.mealsIncludedField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte RatePlanType
        {
            get { return ratePlanTypeField; }
            set { ratePlanTypeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RatePlanCode
        {
            get { return ratePlanCodeField; }
            set { ratePlanCodeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RPH
        {
            get { return RPHField; }
            set { RPHField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class
        OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefs
    {

        private
            OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefsHotelRef
            hotelRefField;

        /// <remarks/>
        public
            OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefsHotelRef
            HotelRef
        {
            get { return hotelRefField; }
            set { hotelRefField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class
        OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateHotelRefsHotelRef
    {

        private string hotelCodeField;

        /// <remarks/>
        [XmlAttribute]
        public string HotelCode
        {
            get { return hotelCodeField; }
            set { hotelCodeField = value; }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRatePlanCandidatesRatePlanCandidateMealsIncluded
    {

        private string mealPlanCodesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MealPlanCodes
        {
            get
            {
                return this.mealPlanCodesField;
            }
            set
            {
                this.mealPlanCodesField = value;
            }
        }
    }


    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidates
    {

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate
            roomStayCandidateField;

        /// <remarks/>
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate
            RoomStayCandidate
        {
            get { return roomStayCandidateField; }
            set { roomStayCandidateField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidate
    {

        private OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCountsGuestCount[] guestCountsField;

        private string roomTypeCodeField;

        private byte quantityField;

        private byte ratePlanCandidateRPHField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("GuestCount", IsNullable = false)]
        public OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCountsGuestCount[] GuestCounts
        {
            get { return guestCountsField; }
            set { guestCountsField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public string RoomTypeCode
        {
            get { return roomTypeCodeField; }
            set { roomTypeCodeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte Quantity
        {
            get { return quantityField; }
            set { quantityField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte RatePlanCandidateRPH
        {
            get { return ratePlanCandidateRPHField; }
            set { ratePlanCandidateRPHField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class
        OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCounts
    {

        private
            OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCountsGuestCount
            guestCountField;

        /// <remarks/>
        public
            OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCountsGuestCount
            GuestCount
        {
            get { return guestCountField; }
            set { guestCountField = value; }
        }
    }

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class
        OTA_HotelAvailRQAvailRequestSegmentsAvailRequestSegmentRoomStayCandidatesRoomStayCandidateGuestCountsGuestCount
    {

        private byte ageQualifyingCodeField;

        private byte countField;

        /// <remarks/>
        [XmlAttribute]
        public byte AgeQualifyingCode
        {
            get { return ageQualifyingCodeField; }
            set { ageQualifyingCodeField = value; }
        }

        /// <remarks/>
        [XmlAttribute]
        public byte Count
        {
            get { return countField; }
            set { countField = value; }
        }
    }

}