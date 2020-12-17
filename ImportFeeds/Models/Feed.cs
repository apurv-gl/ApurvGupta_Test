using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFeeds.Models
{
    public class Feed
    {
        public List<string> category { get; set; }
        public string name { get; set; }
        public string twitter { get; set; }
    }
}
