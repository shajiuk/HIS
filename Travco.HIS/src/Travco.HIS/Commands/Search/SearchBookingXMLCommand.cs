using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Travco.Data.Common.Commands;
using Travco.Data.Common.NEST;
using Travco.Data.Common.PagedList;
using Travco.Data.Model;
using Travco.HIS.Api.Dto;
using Travco.HIS.Api.Requests;
using Travco.HIS.Api.Responses;

namespace Travco.HIS.Commands.Search
{
    public class SearchBookingXMLCommand : Command<SearchBookingRequest, SearchBookingXMLResponse>
    {
        private readonly NestQuery<SearchBookingRequest> _searchQuery;
        private readonly IMapper _mapper;


        public SearchBookingXMLCommand(NestQuery<SearchBookingRequest> searchQuery,
            IMapper mapper)
           
        {
            _searchQuery = searchQuery;
            _mapper = mapper;
        }

        public override Task<SearchBookingXMLResponse> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task<SearchBookingXMLResponse>.Factory.StartNew(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();

                IPagedList<Published<Rates>> search = _searchQuery.Query<Published<Rates>>(Request);

                if (search.Count > 0)
                {
                    search[0].BookingRequest = Request;
                }

                return new SearchBookingXMLResponse
                {
                    DATA = _mapper.Map<IList<SearchDataXMLResponse>>(search.Select(s => s.Draft).ToList()),
                    RequestData = Request//_mapper.Map<IList<SearchBookingRequest>>(search.Select(s => s.BookingRequest).ToList())
                };

            }, cancellationToken);
        }

    }
}