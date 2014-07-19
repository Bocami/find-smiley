using Bocami.Practices.Query;
using FindSmiley.API.DomainModel.Version;

namespace FindSmiley.API.Queries
{
    public class VersionQuery : IQuery
    {
    }

    public class VersionQueryResult : IQueryResult
    {
        public Version Version { get; set; }
    }

    public class Version
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Revision { get; set; }
        public int Build { get; set; }
    }

    public class VersionQueryHandler : IQueryHandler<VersionQuery, VersionQueryResult>
    {
        private readonly IVersionService versionService;

        public VersionQueryHandler(IVersionService versionService)
        {
            this.versionService = versionService;
        }

        public VersionQueryResult Handle(VersionQuery query)
        {
            var version = versionService.GetVersion();

            return new VersionQueryResult
            {
                Version = new Version
                {
                    Build = version.Build,
                    Major = version.Major,
                    Minor = version.Minor,
                    Revision = version.Revision
                }
            };
        }
    }
}