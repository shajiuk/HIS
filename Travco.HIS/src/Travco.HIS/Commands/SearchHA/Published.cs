using System;
using Newtonsoft.Json;
using Travco.Data.Common;
using Travco.Data.Common.Specifications;
using Travco.HIS.Api.Requests;

namespace Travco.HIS.Commands.SearchHA
{
    public class Published<TModel> : IEntity where TModel : IEntity
    {
        private ISpecification<TModel> _specification;

        public string Id
        {
            get { return this.Draft.Id; }
        }

        public Status Status
        {
            get { return Status.Active; }
        }

        [JsonProperty]
        public TModel Draft { get;  set; }

        [JsonProperty]
        public TModel Live { get; protected set; }

        [JsonProperty]
        public DateTime Created { get; protected set; }

        [JsonProperty]
        public DateTime? PublishedOn { get; protected set; }

        [JsonProperty]
        public DateTime? UnPublishedOn { get; protected set; }

        [JsonProperty]
        public DateTime Modified { get; protected set; }

        [JsonProperty]
        public SearchBookingRequest BookingRequest { get;  set; }

        [JsonProperty]
        public SearchBookingHARequest BookingHARequest { get; set; }

        public string Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Version
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //[JsonProperty]
        //public string SearchType { get; set; }

        //[JsonProperty]
        //public string Language { get;  set; }

        //[JsonProperty]
        //public bool ReturnURLRequired { get; set; }

        //[JsonProperty]
        //public string ReturnURL { get;  set; }

        //[JsonProperty]
        //public string AgentCode { get;  set; }

        //public string AgentPassword { get;  set; }

        //[JsonProperty]
        //public bool AvailableHotelsOnly { get;  set; }

        public Published()
        {
        }

        public Published(TModel draft)
        {
            this.Draft = draft;
            this.Created = DateTime.UtcNow;
        }

        public bool Publish()
        {
            if (!this._specification.IsSatisfiedBy(this.Draft))
                return false;
            this.Live = ObjectExtensions.CloneJson<TModel>(this.Draft);
            this.Modified = DateTime.UtcNow;
            this.PublishedOn = new DateTime?(this.Modified);
            return true;
        }

        public void Unpublish()
        {
            this.Draft = ObjectExtensions.CloneJson<TModel>(this.Live);
            this.Modified = DateTime.UtcNow;
            this.UnPublishedOn = new DateTime?(this.Modified);
        }

        public void Update(TModel newDraft)
        {
            this.Draft = newDraft;
        }

        public void SetSpecification(ISpecification<TModel> specification)
        {
            this._specification = specification;
        }
    }
}

