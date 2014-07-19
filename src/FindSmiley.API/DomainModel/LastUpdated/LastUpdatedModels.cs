using System;
using System.Web.Hosting;

namespace FindSmiley.API.DomainModel.LastUpdated
{
    public class LastUpdated
    {
        public DateTime LastUpdatedOn { get; set; }
    }

    public interface ILastUpdatedService
    {
        LastUpdated GetLastUpdated();
    }

    public class LastUpdatedService : ILastUpdatedService
    {
        private readonly string virtualPath;

        public LastUpdatedService(string virtualPath)
        {
            this.virtualPath = virtualPath;
        }

        public LastUpdated GetLastUpdated()
        {
            var physicalPath = HostingEnvironment.MapPath(virtualPath);

            if (physicalPath == null)
                throw new InvalidOperationException("File not found");

            var lastUpdatedOn = System.IO.File.GetLastWriteTime(physicalPath);

            return new LastUpdated
            {
                LastUpdatedOn = lastUpdatedOn
            };
        }
    }
}