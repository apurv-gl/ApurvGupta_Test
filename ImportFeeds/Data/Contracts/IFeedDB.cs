using ImportFeeds.Models;

namespace ImportFeeds.Data.Contracts
{
    public interface IFeedDB
    {
        int InsertFeeds(Feed feed);
    }
}
