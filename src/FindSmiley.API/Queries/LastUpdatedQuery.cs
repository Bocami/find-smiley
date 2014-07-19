using Bocami.Practices.Query;
using System;
using FindSmiley.API.DomainModel.LastUpdated;

namespace FindSmiley.API.Queries
{
    public class LastUpdatedQuery : IQuery
    {
    }

    public class LastUpdatedQueryResult : IQueryResult
    {
        public LastUpdated LastUpdated { get; set; }
    }

    public class LastUpdated
    {
        public DateTime LastUpdatedOn { get; set; }
    }

    public class LastUpdatedQueryHandler : IQueryHandler<LastUpdatedQuery, LastUpdatedQueryResult>
    {
        private readonly ILastUpdatedService lastUpdatedService;

        public LastUpdatedQueryHandler(ILastUpdatedService lastUpdatedService)
        {
            this.lastUpdatedService = lastUpdatedService;
        }

        public LastUpdatedQueryResult Handle(LastUpdatedQuery query)
        {
            var lastUpdated = lastUpdatedService.GetLastUpdated();

            return new LastUpdatedQueryResult
            {
                LastUpdated = new LastUpdated
                {
                     LastUpdatedOn = lastUpdated.LastUpdatedOn
                }
            };
        }
    }
}