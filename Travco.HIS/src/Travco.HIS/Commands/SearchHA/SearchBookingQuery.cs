using System;
using log4net;
using Nest;
using System.Collections.Generic;
using Travco.Data.Common.NEST;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Commands.SearchHA
{
    public class SearchBookingXMLQuery : NestQuery<SearchBookingHARequest>
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SearchBookingXMLQuery));
        private QueryContainer _orQuery = null;
        private QueryContainer _andQuery = null;
        private readonly List<QueryContainer> _andContainer = new List<QueryContainer>();
        private readonly List<QueryContainer> _orContainer = new List<QueryContainer>();

        public SearchBookingXMLQuery(IElasticClient client, Data.Common.IRepository repository,
            ElasticsearchOptions options)
            : base(client, repository, options)
        {
        }

        public override ISearchResponse<QueryResponse<TEntity>> Execute<TEntity>(SearchBookingHARequest query)
        {
            ISearchResponse<QueryResponse<TEntity>> result = null;

            var searchQuery = BuildFilters(query);

            result = Client.Search<Data.Model.Search, QueryResponse<TEntity>>(s => s
                .Size(query.PageSize)
                .Type(Options.Type)
                .Index(Options.Index)
                .Source(w=>w.Include(FieldsToInclude))
                //.Filter(filter)
                //.Sort(sortBy => sortBy.Ascending(t=>t.Name))
                .Type("couchbaseDocument")
                .Query(q =>
                {
                    QueryContainer queryContainer = null;

                    queryContainer &= q.ConstantScore(f => f.Filter(ff => ff.Bool(b => b.Filter(searchQuery))));

                    return queryContainer;
                }));

            return result;
        }


        private QueryContainer BuildFilters(SearchBookingHARequest query)
        {
            // AND Query

            AndCheckFieldsExist();

            AndTermFilter("doc.draft.rates.hotel.name", query.Data.HotelName);
            AndTermFilter("doc.draft.rates.hotel.code", query.Data.EdiCode);

            //AndMultipleDateRangeFilter("doc.draft.rates.rateValidity.from", "doc.draft.rates.rateValidity.to", query.Data.CheckIn.CheckInTime, query.Data.CheckIn.CheckOutTime);
            AndMultipleDateRangeFilter("doc.draft.allotments.validFrom", "doc.draft.allotments.validTo", query.Data.CheckIn.CheckInTime, query.Data.CheckIn.CheckOutTime);

            AndTermFilter("doc.draft.rates.hotel.addresses.cityAreas.code", query.Data.CityAreaCode);

            GetCountryCityRegionCodeRequestData(query);

            _andContainer.Add(_andQuery);

            // OR Query
            OrNumericRangeFilter("doc.draft.allotments.allotment", 0, null);
            OrNumericRangeFilter("doc.draft.allotments.freesale", 0, null);

            _orContainer.Add(_orQuery);

            return BuildQuery(query);
        }

        private QueryContainer BuildQuery(SearchBookingHARequest query)
        {
            var boolQuery = new BoolQuery
            {
                Must = _andContainer,
                Filter = _orContainer,
                Should = new List<QueryContainer>
                {
                    GetMultiDataOR(query)
                }
            };

            return boolQuery;
        }

        private QueryContainer GetMultiDataOR(SearchBookingHARequest query)
        {
            var multiRooomsData = new BoolQuery
            {
                Should = GetAllRoomsData(query)
            };

            var multiStarsData = new BoolQuery
            {
                Should = GetMultiStarsRequestData(query)
            };

            var multiHotelsData = new BoolQuery
            {
                Should = GetMultiHotelRequestData(query)
            };

            return multiRooomsData || multiStarsData || multiHotelsData;
        }

        private IList<QueryContainer> GetAllRoomsData(SearchBookingHARequest query)
        {
            var filterContainer = new List<QueryContainer>();

            if (query.Data.RoomsRequired[0].Single > 0)
            {
                filterContainer.Add(SetTermFilter("doc.draft.rates.hotel.roomCategories.roomTypes.name", "Single"));
            }

            if (query.Data.RoomsRequired[0].Double > 0)
            {
                filterContainer.Add(SetTermFilter("doc.draft.rates.hotel.roomCategories.roomTypes.name", "Double"));
            }

            if (query.Data.RoomsRequired[0].Triple > 0)
            {
                filterContainer.Add(SetTermFilter("doc.draft.rates.hotel.roomCategories.roomTypes.name", "Triple"));
            }

            if (query.Data.RoomsRequired[0].Quad > 0)
            {
                filterContainer.Add(SetTermFilter("doc.draft.rates.hotel.roomCategories.roomTypes.name", "Quad"));
            }

            //filterContainer.Add(MissingTermFilter("doc.draft.hotel.roomCategories.roomTypes.name"));

            return filterContainer;
        }

        private IList<QueryContainer> GetMultiHotelRequestData(SearchBookingHARequest query)
        {
            var filterContainer = new List<QueryContainer>();

            foreach (var edicode in query.Data.MultiHotelsRequest)
            {
                filterContainer.Add(SetTermFilter("doc.draft.rates.hotel.code", edicode));
            }
            ;

            return filterContainer;
        }

        private IList<QueryContainer> GetMultiStarsRequestData(SearchBookingHARequest query)
        {
            var filterContainer = new List<QueryContainer>();

            foreach (var starRating in query.Data.MultiStarsRequest)
            {
                filterContainer.Add(SetTermFilter("doc.draft.rates.hotel.starRating.name", starRating));
            }
            ;

            return filterContainer;
        }

        private IList<QueryContainer> GetCountryCityRegionCodeRequestData(SearchBookingHARequest query)
        {
            var filterContainer = new List<QueryContainer>();

            AndTermFilter("doc.draft.rates.hotel.addresses.country.code", query.Data.CountryCode);
            AndTermFilter("doc.draft.rates.hotel.addresses.city.code", query.Data.CityCode);
            AndTermFilter("doc.draft.rates.hotel.addresses.countryRegion.code", query.Data.CountryRegionCode);

            return filterContainer;
        }

        private void AndCheckFieldsExist()
        {
            AndExistsTermFilter("doc.draft.rates.rateValidity");
            AndExistsTermFilter("doc.draft.allotments");
            AndExistsTermFilter("doc.draft.rates.rateValidity.roomCategories");
            AndNotMissingTermFilter("doc.draft.rates.hotel.addresses.country.code");
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
            _orQuery |= new TermQuery
            {
                Field = field,
                Value = value,
            };

            return _orQuery;
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

        private QueryContainer OrNumericRangeFilter(Field field, double? greaterThan, double? lessThan)
        {
            _orQuery |= new NumericRangeQuery
            {
                Field = field,
                GreaterThan = greaterThan,
                LessThan = lessThan
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

        private QueryContainer AndNumericRangeFilter(Field field, double? greaterThan, double? lessThan, bool gte)
        {
            QueryContainer numericQuery = null;
            numericQuery &= !gte
                ? new NumericRangeQuery()
                {
                    Field = field,
                    GreaterThan = greaterThan,
                    LessThan = lessThan
                }
                : new NumericRangeQuery()
                {
                    Field = field,
                    GreaterThanOrEqualTo = greaterThan,
                    LessThanOrEqualTo = lessThan
                };

            return numericQuery;
        }

        private QueryContainer AndMultipleDateRangeFilter(Field fromField, Field toField, DateMath greaterThanEqualTo,
            DateMath lessThanEqualTo)
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

        private QueryContainer OrMissingTermFilter(Field field)
        {
            _orQuery |= new MissingQuery()
            {
                Field = field
            };

            return _orQuery;
        }

        private QueryContainer AndNotMissingTermFilter(Field field)
        {
            _andQuery &= new BoolQuery
            {
                MustNot = new List<QueryContainer>
                {
                    new MissingQuery
                    {
                        Field = field
                    }
                }
            };

            return _andQuery;
        }

        private QueryContainer AndExistsTermFilter(Field field)
        {
            _andQuery &= new ExistsQuery()
            {
                Field = field
            };

            return _andQuery;
        }

        private IPromise<Fields> FieldsToInclude(FieldsDescriptor<Data.Model.Search> fieldsDescriptor)
        {
            var field = new FieldsDescriptor<Data.Model.Search>();

            field
                .Field("doc.draft.rates.code")
                .Field("doc.draft.rates.hotel.name")
                .Field("doc.draft.rates.hotel.code")
                .Field("doc.draft.rates.hotel.status")
                .Field("doc.draft.rates.hotel.addresses.country.name")
                .Field("doc.draft.rates.hotel.addresses.city.name")
                .Field("doc.draft.rates.hotel.addresses.city.Id")
                .Field("doc.draft.rates.hotel.addresses.primaryPhone")
                .Field("doc.draft.rates.hotel.addresses.primaryFax")
                .Field("doc.draft.rates.hotel.addresses.email")
                .Field("doc.draft.rates.hotel.addresses.streetLine")
                .Field("doc.draft.rates.hotel.starRating.name")
                .Field("doc.draft.rates.hotel.amenities")
                .Field("doc.draft.rates.hotel.location.geoLocation.latitude")
                .Field("doc.draft.rates.hotel.location.geoLocation.longitude")
                .Field("doc.draft.rates.currency.name")
                .Field("doc.draft.rates.rateValidity.from")
                .Field("doc.draft.rates.rateValidity.to")
                .Field("doc.draft.rates.rateValidity.roomCategories.roomTypes.name")
                .Field("doc.draft.rates.rateValidity.roomCategories.roomTypes.adultSellingRate.amount")
                .Field("doc.draft.rates.rateValidity.roomCategories.roomTypes.childSellingRate.amount")
                .Field("doc.draft.allotments");        

            return field;

        }
    }
}