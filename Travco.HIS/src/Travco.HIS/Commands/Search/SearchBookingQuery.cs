using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Nest;
using log4net;
using Travco.Data.Common.NEST;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Commands.Search
{
    public class SearchBookingXMLQuery : NestQuery<SearchBookingRequest>
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof (SearchBookingXMLQuery));
        private QueryContainer _orQuery = null;
        private QueryContainer _andQuery = null;
        private readonly List<QueryContainer> _andContainer = new List<QueryContainer>();
        private readonly List<QueryContainer> _orContainer = new List<QueryContainer>();

        public SearchBookingXMLQuery(IElasticClient client, Data.Common.IRepository repository,
            ElasticsearchOptions options)
            : base(client, repository, options)
        {
        }

        public override ISearchResponse<QueryResponse<TEntity>> Execute<TEntity>(SearchBookingRequest query)
        {
            string queries = "";
            ISearchResponse<QueryResponse<TEntity>> result = null;

            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            var mustQuery = BuildFilters(query);

            result = Client.Search<Data.Model.Search, QueryResponse<TEntity>>(s => s
                .Size(query.PageSize)
                .Type(Options.Type)
                .Index(Options.Index)
                //.Filter(filter)
                //.SortAscending(sortBy => sortBy.Data)
                .Type("couchbaseDocument")
                .Query(q =>
                {
                    QueryContainer queryContainer = null;

                    queryContainer = q.ConstantScore(f => f.Filter(ff => ff.Bool(b => b.Must(mustQuery))));

                    return queryContainer;
                }));

            //stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            //TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            //string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            return result;
        }


        private QueryContainer BuildFilters(SearchBookingRequest query)
        {            

            foreach (var data in query.Data)
            {
                _andQuery = null;

                // AND Query
                AndMultipleDateRangeFilter("doc.draft.rates.rateValidity.from", "doc.draft.rates.rateValidity.to", data.CheckIn.CheckInTime, data.CheckIn.CheckOutTime);
                AndTermFilter("doc.draft.rates.hotel.code", data.HotelCode);
                AndTermFilter("doc.draft.rates.hotel.roomCategories.roomTypes.name", data.RoomType.Name);

                _andContainer.Add(_andQuery);

            }

            // OR Query            
            OrNumericRangeFilter("doc.draft.allotments.allotment", 0, null);
            OrNumericRangeFilter("doc.draft.allotments.freesale", 0, null);

            _orContainer.Add(_orQuery);

            var mustQuery = new BoolQuery
            {
                // will put a Should around the AND clause - May or may not match
                Should = _andContainer,

                // will put a Must around the or clause - must match at least one of the the clauses in the OR statement
                Must = _orContainer
            };

            return mustQuery;

        }

        private QueryContainer AndTermFilter(Field field, object value)
        {
            _andQuery &= new TermQuery
            {
                Field = field,
                Value = value,
            };

            return _andQuery;

        }

        private QueryContainer OrTermFilter(Field field, object value)
        {
            _orQuery &= new TermQuery
            {
                Field = field,
                Value = value,
            };

            return _orQuery;

        }

        private QueryContainer SetTermFilter(Field field, object value)
        {
            QueryContainer filter = new TermQuery
            {
                Field = field,
                Value = value,
            };

            return filter;

        }

        private QueryContainer SetDateRangeFilter(Field field, DateMath greaterThanEqualTo, DateMath lessThanEqualTo)
        {
            QueryContainer dateRange = new DateRangeQuery
            {
                Field = field,
                GreaterThanOrEqualTo = greaterThanEqualTo,
                LessThanOrEqualTo = lessThanEqualTo
            };

            return dateRange;
        }

        private QueryContainer SetMatchFilter(Field field, string value)
        {
            QueryContainer match = new MatchQuery()
            {
                Field = field,
                Query = value,
            };

            return match;
        }

        private QueryContainer OrDateRangeFilter(Field field, DateMath greaterThanEqualTo, DateMath lessThanEqualTo)
        {
            _orQuery |= new DateRangeQuery
            {
                Field = field,
                GreaterThanOrEqualTo = greaterThanEqualTo,
                LessThanOrEqualTo = lessThanEqualTo
            };

            return _orQuery;
        }

        private QueryContainer AndDateRangeFilter(Field field, DateMath greaterThanEqualTo, DateMath lessThanEqualTo)
        {
            _andQuery &= new DateRangeQuery
            {
                Field = field,
                GreaterThanOrEqualTo = greaterThanEqualTo,
                LessThanOrEqualTo = lessThanEqualTo
            };

            return _andQuery;
        }

        private QueryContainer AndMultipleDateRangeFilter(Field fromField, Field toField, DateMath greaterThanEqualTo, DateMath lessThanEqualTo)
        {
            _andQuery &= new DateRangeQuery
            {
                Field = fromField,
                GreaterThanOrEqualTo = greaterThanEqualTo,
                LessThanOrEqualTo = greaterThanEqualTo
            };
            _andQuery &= new DateRangeQuery
            {
                Field = toField,
                LessThanOrEqualTo = lessThanEqualTo,
                GreaterThanOrEqualTo = lessThanEqualTo
            };

            return _andQuery;
        }

        private QueryContainer MissingTermFilter(Field field)
        {
            _orQuery &= new MissingQuery()
            {
                Field = field
            };

            return _orQuery;
        }

        private QueryContainer OrNumericRangeFilter(Field field, double? greaterThan, double? lessThan)
        {
            //_orQuery = null;
            _orQuery |= new NumericRangeQuery
            {
                Field = field,
                GreaterThan = greaterThan,
                LessThan = lessThan
            };

            return _orQuery;
        }

    }

}
