using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Travco.Data.Common.Commands;
using Travco.Data.Common.NEST;
using Travco.Data.Model.Models.Search;
using Travco.HIS.Api.Requests;
using Travco.HIS.Api.Responses;

namespace Travco.HIS.Commands.SearchHA
{
    public class SearchBookingCommand : Command<SearchBookingHARequest, SearchBookingResponse>
    {
        private readonly NestQuery<SearchBookingHARequest> _searchQuery;
        private readonly IMapper _mapper;


        public SearchBookingCommand(NestQuery<SearchBookingHARequest> searchQuery,
            IMapper mapper)
           
        {
            _searchQuery = searchQuery;
            _mapper = mapper;
        }

        public override Task<SearchBookingResponse> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task<SearchBookingResponse>.Factory.StartNew(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                var search = _searchQuery.Query<Published<Inventory>>(Request);

                if (search.Count > 0)
                {
                    search[0].BookingHARequest = Request;
                    search[0].Draft.Rates.Adults = Request.Data.RoomsRequired[0].TotalAdults;
                }

                return new SearchBookingResponse
                {
                    DATA = _mapper.Map<IList<SearchDataResponse>>(search.Select(s => s.Draft.Rates).ToList()),
                    RequestHAData = Request, //_mapper.Map<IList<SearchBookingHARequest>>(search.Select(s => s.BookingHARequest).ToList()),
                    SearchType = Request.SearchType,
                    Language = Request.Language
                };

            }, cancellationToken);
        }

    }
}