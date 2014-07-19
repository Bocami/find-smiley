using System.Reflection;

namespace FindSmiley.API.DomainModel.Version
{
    public class VersionService : IVersionService
    {
        public Version GetVersion()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();

            return new Version
            {
                Build = assemblyName.Version.Build,
                Major = assemblyName.Version.Major,
                Revision = assemblyName.Version.Revision,
                Minor = assemblyName.Version.Minor,
            };
        }
    }
}