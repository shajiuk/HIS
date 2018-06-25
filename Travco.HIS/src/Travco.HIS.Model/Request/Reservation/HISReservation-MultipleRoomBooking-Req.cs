
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
using Travco.HIS.Model;
using Travco.HIS.Model.Request;
using Travco.HIS.Model.Request.Reservation;

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
[System.Xml.Serialization.XmlRootAttribute("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
public partial class ReservationsMultiRoomBooking
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
public partial class EnvelopeBody
{

    private OTA_HotelResRQ oTA_HotelResRQField;

    private string requestIdField;

    private string transactionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05")]
    public OTA_HotelResRQ OTA_HotelResRQ
    {
        get
        {
            return this.oTA_HotelResRQField;
        }
        set
        {
            this.oTA_HotelResRQField = value;
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.opentravel.org/OTA/2003/05")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.opentravel.org/OTA/2003/05", IsNullable = false)]
public partial class OTA_HotelResRQ
{

    private OTA_HotelResRQHotelReservations hotelReservationsField;

    private string echoTokenField;

    private System.DateTime timeStampField;

    private string targetField;

    private decimal versionField;

    private string primaryLangIDField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservations HotelReservations
    {
        get
        {
            return this.hotelReservationsField;
        }
        set
        {
            this.hotelReservationsField = value;
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
public partial class OTA_HotelResRQHotelReservations
{

    private OTA_HotelResRQHotelReservationsHotelReservation hotelReservationField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservation HotelReservation
    {
        get
        {
            return this.hotelReservationField;
        }
        set
        {
            this.hotelReservationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservation
{

    private OTA_HotelResRQHotelReservationsHotelReservationUniqueID uniqueIDField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStay[] roomStaysField;

    private OTA_HotelResRQHotelReservationsHotelReservationResGuest[] resGuestsField;

    private bool roomStayReservationField;

    private System.DateTime createDateTimeField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationUniqueID UniqueID
    {
        get
        {
            return this.uniqueIDField;
        }
        set
        {
            this.uniqueIDField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("RoomStay", IsNullable = false)]
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStay[] RoomStays
    {
        get
        {
            return this.roomStaysField;
        }
        set
        {
            this.roomStaysField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("ResGuest", IsNullable = false)]
    public OTA_HotelResRQHotelReservationsHotelReservationResGuest[] ResGuests
    {
        get
        {
            return this.resGuestsField;
        }
        set
        {
            this.resGuestsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool RoomStayReservation
    {
        get
        {
            return this.roomStayReservationField;
        }
        set
        {
            this.roomStayReservationField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime CreateDateTime
    {
        get
        {
            return this.createDateTimeField;
        }
        set
        {
            this.createDateTimeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationUniqueID
{

    private byte typeField;

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte Type
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
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStay
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomTypes roomTypesField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlans ratePlansField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRates roomRatesField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayGuestCountsGuestCount[] guestCountsField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayTimeSpan timeSpanField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPayments depositPaymentsField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayBasicPropertyInfo basicPropertyInfoField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayResGuestRPHs resGuestRPHsField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomTypes RoomTypes
    {
        get
        {
            return this.roomTypesField;
        }
        set
        {
            this.roomTypesField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlans RatePlans
    {
        get
        {
            return this.ratePlansField;
        }
        set
        {
            this.ratePlansField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRates RoomRates
    {
        get
        {
            return this.roomRatesField;
        }
        set
        {
            this.roomRatesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("GuestCount", IsNullable = false)]
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayGuestCountsGuestCount[] GuestCounts
    {
        get
        {
            return this.guestCountsField;
        }
        set
        {
            this.guestCountsField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayTimeSpan TimeSpan
    {
        get
        {
            return this.timeSpanField;
        }
        set
        {
            this.timeSpanField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPayments DepositPayments
    {
        get
        {
            return this.depositPaymentsField;
        }
        set
        {
            this.depositPaymentsField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayBasicPropertyInfo BasicPropertyInfo
    {
        get
        {
            return this.basicPropertyInfoField;
        }
        set
        {
            this.basicPropertyInfoField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayResGuestRPHs ResGuestRPHs
    {
        get
        {
            return this.resGuestRPHsField;
        }
        set
        {
            this.resGuestRPHsField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStaySpecialRequests SpecialRequests
    {
        get;
        set;
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomTypes
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomTypesRoomType roomTypeField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomTypesRoomType RoomType
    {
        get
        {
            return this.roomTypeField;
        }
        set
        {
            this.roomTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomTypesRoomType
{

    private string roomTypeCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RoomTypeCode
    {
        get
        {
            return this.roomTypeCodeField;
        }
        set
        {
            this.roomTypeCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlans
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlansRatePlan ratePlanField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlansRatePlan RatePlan
    {
        get
        {
            return this.ratePlanField;
        }
        set
        {
            this.ratePlanField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlansRatePlan
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlansRatePlanMealsIncluded mealsIncludedField;

    private string ratePlanCodeField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlansRatePlanMealsIncluded MealsIncluded
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RatePlanCode
    {
        get
        {
            return this.ratePlanCodeField;
        }
        set
        {
            this.ratePlanCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRatePlansRatePlanMealsIncluded
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRates
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRate roomRateField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRate RoomRate
    {
        get
        {
            return this.roomRateField;
        }
        set
        {
            this.roomRateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRate
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRate[] ratesField;

    private System.DateTime effectiveDateField;

    private System.DateTime expireDateField;

    private string roomTypeCodeField;

    private byte numberOfUnitsField;

    private uint ratePlanCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Rate", IsNullable = false)]
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRate[] Rates
    {
        get
        {
            return this.ratesField;
        }
        set
        {
            this.ratesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime EffectiveDate
    {
        get
        {
            return this.effectiveDateField;
        }
        set
        {
            this.effectiveDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime ExpireDate
    {
        get
        {
            return this.expireDateField;
        }
        set
        {
            this.expireDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RoomTypeCode
    {
        get
        {
            return this.roomTypeCodeField;
        }
        set
        {
            this.roomTypeCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte NumberOfUnits
    {
        get
        {
            return this.numberOfUnitsField;
        }
        set
        {
            this.numberOfUnitsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint RatePlanCode
    {
        get
        {
            return this.ratePlanCodeField;
        }
        set
        {
            this.ratePlanCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRate
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRateBase baseField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRateTotal totalField;

    private System.DateTime effectiveDateField;

    private System.DateTime expireDateField;

    private string rateTimeUnitField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRateBase Base
    {
        get
        {
            return this.baseField;
        }
        set
        {
            this.baseField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRateTotal Total
    {
        get
        {
            return this.totalField;
        }
        set
        {
            this.totalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime EffectiveDate
    {
        get
        {
            return this.effectiveDateField;
        }
        set
        {
            this.effectiveDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime ExpireDate
    {
        get
        {
            return this.expireDateField;
        }
        set
        {
            this.expireDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RateTimeUnit
    {
        get
        {
            return this.rateTimeUnitField;
        }
        set
        {
            this.rateTimeUnitField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRateBase
{

    private ushort amountBeforeTaxField;

    private ushort amountAfterTaxField;

    private string currencyCodeField;

    private byte decimalPlacesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort AmountBeforeTax
    {
        get
        {
            return this.amountBeforeTaxField;
        }
        set
        {
            this.amountBeforeTaxField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort AmountAfterTax
    {
        get
        {
            return this.amountAfterTaxField;
        }
        set
        {
            this.amountAfterTaxField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CurrencyCode
    {
        get
        {
            return this.currencyCodeField;
        }
        set
        {
            this.currencyCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte DecimalPlaces
    {
        get
        {
            return this.decimalPlacesField;
        }
        set
        {
            this.decimalPlacesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayRoomRatesRoomRateRateTotal
{

    private int amountBeforeTaxField;

    private int amountAfterTaxField;

    private string currencyCodeField;

    private byte decimalPlacesField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int AmountBeforeTax
    {
        get
        {
            return this.amountBeforeTaxField;
        }
        set
        {
            this.amountBeforeTaxField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int AmountAfterTax
    {
        get
        {
            return this.amountAfterTaxField;
        }
        set
        {
            this.amountAfterTaxField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CurrencyCode
    {
        get
        {
            return this.currencyCodeField;
        }
        set
        {
            this.currencyCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte DecimalPlaces
    {
        get
        {
            return this.decimalPlacesField;
        }
        set
        {
            this.decimalPlacesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayGuestCounts
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayGuestCountsGuestCount guestCountField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayGuestCountsGuestCount GuestCount
    {
        get
        {
            return this.guestCountField;
        }
        set
        {
            this.guestCountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayGuestCountsGuestCount
{

    private byte ageQualifyingCodeField;

    private byte countField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte AgeQualifyingCode
    {
        get
        {
            return this.ageQualifyingCodeField;
        }
        set
        {
            this.ageQualifyingCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte Count
    {
        get
        {
            return this.countField;
        }
        set
        {
            this.countField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayTimeSpan
{

    private System.DateTime startField;

    private System.DateTime endField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime Start
    {
        get
        {
            return this.startField;
        }
        set
        {
            this.startField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
    public System.DateTime End
    {
        get
        {
            return this.endField;
        }
        set
        {
            this.endField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPayments
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePayment guaranteePaymentField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePayment GuaranteePayment
    {
        get
        {
            return this.guaranteePaymentField;
        }
        set
        {
            this.guaranteePaymentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePayment
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPayments acceptedPaymentsField;

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAmountPercent amountPercentField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPayments AcceptedPayments
    {
        get
        {
            return this.acceptedPaymentsField;
        }
        set
        {
            this.acceptedPaymentsField = value;
        }
    }

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAmountPercent AmountPercent
    {
        get
        {
            return this.amountPercentField;
        }
        set
        {
            this.amountPercentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPayments
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPayment acceptedPaymentField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPayment AcceptedPayment
    {
        get
        {
            return this.acceptedPaymentField;
        }
        set
        {
            this.acceptedPaymentField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPayment
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPaymentPaymentCard paymentCardField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPaymentPaymentCard PaymentCard
    {
        get
        {
            return this.paymentCardField;
        }
        set
        {
            this.paymentCardField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAcceptedPaymentsAcceptedPaymentPaymentCard
{

    private byte cardTypeField;

    private string cardCodeField;

    private string cardNumberField;

    private ushort expireDateField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte CardType
    {
        get
        {
            return this.cardTypeField;
        }
        set
        {
            this.cardTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CardCode
    {
        get
        {
            return this.cardCodeField;
        }
        set
        {
            this.cardCodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CardNumber
    {
        get
        {
            return this.cardNumberField;
        }
        set
        {
            this.cardNumberField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public ushort ExpireDate
    {
        get
        {
            return this.expireDateField;
        }
        set
        {
            this.expireDateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayDepositPaymentsGuaranteePaymentAmountPercent
{

    private decimal amountField;

    private string currencyCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public decimal Amount
    {
        get
        {
            return this.amountField;
        }
        set
        {
            this.amountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string CurrencyCode
    {
        get
        {
            return this.currencyCodeField;
        }
        set
        {
            this.currencyCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayBasicPropertyInfo
{

    private string hotelCodeField;

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
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayResGuestRPHs
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStayResGuestRPHsResGuestRPH resGuestRPHField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStayResGuestRPHsResGuestRPH ResGuestRPH
    {
        get
        {
            return this.resGuestRPHField;
        }
        set
        {
            this.resGuestRPHField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStayResGuestRPHsResGuestRPH
{

    private byte rPHField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte RPH
    {
        get
        {
            return this.rPHField;
        }
        set
        {
            this.rPHField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaySpecialRequests
{

    private OTA_HotelResRQHotelReservationsHotelReservationRoomStaySpecialRequestsSpecialRequest specialRequestField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationRoomStaySpecialRequestsSpecialRequest SpecialRequest
    {
        get
        {
            return this.specialRequestField;
        }
        set
        {
            this.specialRequestField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationRoomStaySpecialRequestsSpecialRequest
{

    private string textField;

    private string languageField;

    private string requestCodeField;

    /// <remarks/>
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
    public string Language
    {
        get
        {
            return this.languageField;
        }
        set
        {
            this.languageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string RequestCode
    {
        get
        {
            return this.requestCodeField;
        }
        set
        {
            this.requestCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuest
{

    private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfiles profilesField;

    private byte resGuestRPHField;

    private byte ageQualifyingCodeField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfiles Profiles
    {
        get
        {
            return this.profilesField;
        }
        set
        {
            this.profilesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte ResGuestRPH
    {
        get
        {
            return this.resGuestRPHField;
        }
        set
        {
            this.resGuestRPHField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte AgeQualifyingCode
    {
        get
        {
            return this.ageQualifyingCodeField;
        }
        set
        {
            this.ageQualifyingCodeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfiles
{

    private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfo profileInfoField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfo ProfileInfo
    {
        get
        {
            return this.profileInfoField;
        }
        set
        {
            this.profileInfoField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfo
{

    private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfile profileField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfile Profile
    {
        get
        {
            return this.profileField;
        }
        set
        {
            this.profileField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfile
{

    private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumer consumerField;

    private byte profileTypeField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumer Consumer
    {
        get
        {
            return this.consumerField;
        }
        set
        {
            this.consumerField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte ProfileType
    {
        get
        {
            return this.profileTypeField;
        }
        set
        {
            this.profileTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumer
{

    private OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumerPersonName personNameField;

    /// <remarks/>
    public OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumerPersonName PersonName
    {
        get
        {
            return this.personNameField;
        }
        set
        {
            this.personNameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class OTA_HotelResRQHotelReservationsHotelReservationResGuestProfilesProfileInfoProfileConsumerPersonName
{

    private string givenNameField;

    private string surnameField;

    /// <remarks/>
    public string GivenName
    {
        get
        {
            return this.givenNameField;
        }
        set
        {
            this.givenNameField = value;
        }
    }

    /// <remarks/>
    public string Surname
    {
        get
        {
            return this.surnameField;
        }
        set
        {
            this.surnameField = value;
        }
    }
}

