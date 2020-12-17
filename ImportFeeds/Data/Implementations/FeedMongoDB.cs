using ImportFeeds.Data.Contracts;
using ImportFeeds.Models;

namespace ImportFeeds.Data.Implementations
{
    public class FeedMongoDB : IFeedDB
    {
        public FeedMongoDB()
        {
            //Make mongo connection
        }

        public int InsertFeeds(Feed feed)
        {
            //Insert feeds in db and return number of row
            return 0;
        }
    }
}
