using ImportFeeds.Models;
using System.Collections.Generic;

namespace ImportFeeds.Services.Contracts
{
    public interface IFeed<T> where T : ImportType
    {
        List<Feed> Import(string filePath);
    }
}
