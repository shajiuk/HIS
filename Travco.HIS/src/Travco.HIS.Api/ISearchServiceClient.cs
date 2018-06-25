using System.Threading.Tasks;
using Travco.HIS.Api.Requests;
using Travco.HIS.Api.Responses;
using HotelSearch = Travco.Data.Model.SearchXML.Xml.Request.HotelAvailability;
using AllocationSearch = Travco.Data.Model.SearchXML.Xml.Request.AllocationEnquiry;

namespace Travco.HIS.Api
{
    public interface ISearchServiceClient
    {
        Task<SearchResponse> SearchAllocations(SearchBookingRequest request);
        Task<SearchResponse> SearchAllocations(AllocationSearch.BOOKING request);
        Task<SearchResponse> SearchAllocationsXml(SearchBookingRequest request);
        Task<SearchResponse> SearchAllocationsXml(AllocationSearch.BOOKING request);
        Task<SearchBookingHAResponse> SearchHotels(SearchBookingRequest request);
        Task<SearchBookingHAResponse> SearchHotels(HotelSearch.BOOKING request);
        Task<SearchBookingHAResponse> SearchHotelsXml(SearchBookingRequest request);
        Task<SearchBookingHAResponse> SearchHotelsXml(HotelSearch.BOOKING request);
    }
}
