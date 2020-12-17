using System.Collections.Generic;
using System.Linq;

namespace ImportFeeds.Models
{
    public class ImportYaml : ImportType
    {
        public override string FileType => "yaml";
        public List<string> allTags
        {
            get
            {
                return tags.Split(',').ToList();
            }
        }
        public string tags { get; set; }
        public string name { get; set; }
        public string twitter { get; set; }
    }
}
