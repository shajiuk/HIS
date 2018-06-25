using System.Collections.Generic;
using Travco.Data.Common;

namespace Travco.HIS.Api.Requests
{
    public class SearchBookingHARequest : QueryRequest
    {
        // Booking Header
        public SearchHeaderRequest Header { get; set; }

        public string SearchType { get; set; }
        public string Language { get; set; }
        public string ElapsedTimeToDeserializeXML2JSON { get; set; }
        public bool ReturnURLRequired { get; set; }
        public string ReturnURL { get; set; }
        public string AgentCode { get; set; }
        public string AgentPassword { get; set; }
        public bool AvailableHotelsOnly { get; set; }

        public SearchDataHARequest Data { get; set; }

    }
}
