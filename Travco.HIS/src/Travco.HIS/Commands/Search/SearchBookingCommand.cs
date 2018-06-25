using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Travco.Data.Common.Commands;
using Travco.Data.Common.NEST;
using Travco.Data.Common.PagedList;
using Travco.Data.Model.Models.Search;
using Travco.HIS.Api.Dto;
using Travco.HIS.Api.Requests;
using Travco.HIS.Api.Responses;

namespace Travco.HIS.Commands.Search
{
    public class SearchBookingCommand : Command<SearchBookingRequest, SearchBookingResponse>
    {
        private readonly NestQuery<SearchBookingRequest> _searchQuery;
        private readonly IMapper _mapper;


        public SearchBookingCommand(NestQuery<SearchBookingRequest> searchQuery,
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

                IPagedList<Published<Inventory>> search = _searchQuery.Query<Published<Inventory>>(Request);

                return new SearchBookingResponse
                {
                    DATA = _mapper.Map<IList<SearchDataResponse>>(search.Select(s => s.Draft.Rates).ToList()),
                    RequestData = Request, //_mapper.Map<IList<SearchBookingRequest>>(search.Select(s => s.BookingRequest).ToList()),
                    SearchType = Request.SearchType,
                    Language = Request.Language
                };

            }, cancellationToken);
        }

    }
}