using System.Collections.Generic;
using Travco.Data.Common;

namespace Travco.HIS.Api.Requests
{
    public class SearchRequest : QueryRequest
    {
        public SearchBookingRequest Booking { get; set; }

        public SearchAllocationEnquiriesRequest AllocationEnquires { get; set; }
       
    }
}