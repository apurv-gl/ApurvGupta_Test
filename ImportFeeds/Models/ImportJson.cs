using ImportFeeds.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ImportFeeds.Models
{
    public class ImportJson : ImportType
    {
        public override string FileType => "json";

        [JsonProperty("products")]
        public List<Products> Products { get; set; }
    }

    public class Products
    {
        [JsonProperty("categories")]
        public List<string> Category { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
