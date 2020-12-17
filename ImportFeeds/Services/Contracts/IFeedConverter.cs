using ImportFeeds.Models;
using System.Collections.Generic;

namespace ImportFeeds.Services.Contracts
{
    public interface IFeedConverter
    {
        List<Feed> Import(string filePath);
    }
}
