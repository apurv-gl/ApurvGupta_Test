using ImportFeeds.Models;
using System.Collections.Generic;

namespace ImportFeeds.Services.Contracts
{
    public interface IFeed
    {
        List<Feed> Import(string filePath);
    }
}
