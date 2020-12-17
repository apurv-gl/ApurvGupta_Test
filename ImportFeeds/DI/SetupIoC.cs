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
            For<IFeed>().Use<FeedJson>().Named("json");
            For<IFeed>().Use<FeedYaml>().Named("yaml");

            //For future extensions when csv will be in use
            //For<IFeed>().Use<FeedYaml>().Named("csv");

            For<IFeedDB>().Use<FeedMySqlDB>().Named("mysql");
            For<IFeedDB>().Use<FeedMongoDB>().Named("mongo");
        }
    }
}
