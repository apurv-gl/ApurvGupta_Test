using ImportFeeds.Data.Contracts;
using ImportFeeds.Data.Implementations;
using ImportFeeds.Models;
using ImportFeeds.Services.Contracts;
using ImportFeeds.Services.Implementations;
using StructureMap;

namespace ImportFeeds.DI
{
    public class SetupIoC : Registry
    {
        public SetupIoC()
        {
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
            For<IFeed<ImportJson>>().Use<FeedJson>();
            For<IFeed<ImportYaml>>().Use<FeedYaml>();
            For<IFeedDB>().Use<FeedMySqlDB>();

            //This code will be uncommented when company switches to MongoDB
            //For<IFeedDB>().Use<FeedMongoDB>();
        }
    }
}
