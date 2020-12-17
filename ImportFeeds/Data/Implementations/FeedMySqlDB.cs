using ImportFeeds.Data.Contracts;
using ImportFeeds.Models;

namespace ImportFeeds.Data.Implementations
{
    public class FeedMySqlDB : IFeedDB
    {
        public FeedMySqlDB()
        {
            //Make MySql connection
        }

        public int InsertFeeds(Feed feed)
        {
            //Insert feeds in db and return number of row
            return 0;
        }
    }
}
