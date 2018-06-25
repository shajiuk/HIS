using System.Xml.Serialization;

namespace Travco.HIS.Api.Requests
{
    //[XmlRoot(ElementName = "HEADER")]
    public class SearchHeaderRequest
    {
        public string InternalCode1 { get; set; }
        public string InternalCode2 { get; set; }
        public string InternalCode3 { get; set; }
        public string NeedReductionAmount { get; set; }
        public string NeedHotelMessages { get; set; }
        public string NeedFreeNightDetails { get; set; }
    }
}
