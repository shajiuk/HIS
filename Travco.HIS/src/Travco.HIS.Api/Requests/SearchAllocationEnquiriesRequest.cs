using Travco.Data.Dto;
using Travco.HIS.Api.Dto;

namespace Travco.HIS.Api.Requests
{
    public class SearchAllocationEnquiriesRequest
    {

        // Allocation Enquires (AE)
        public string EnquiryNo { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Nights { get; set; }
        public string Duration { get; set; }
        public CheckInDto CheckIn { get; set; }
        public string HotelCode { get; set; }
        public RoomTypeDto RoomType { get; set; }
    }
}
