using ImportFeeds.Data.Contracts;
using ImportFeeds.DI;
using ImportFeeds.Models;
using ImportFeeds.Services.Contracts;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ImportFeeds
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input file path : ");
            string filePath = Console.ReadLine();

            var splits = filePath.Split('.');
            var extension = splits[splits.Length - 1];

            var allowedExtensions = ConfigurationManager.AppSettings["AllowedExtensions"];
            var allExtensions = allowedExtensions.Split(',').ToList();
            if (allExtensions.Contains(extension))
            {
                using (var container = Container.For<SetupIoC>())
                {
                    List<Feed> feeds = feeds = container.GetInstance<IFeedConverter>(extension).Import(filePath);

                    var db = ConfigurationManager.AppSettings["Database"];
                    var dbObj = container.GetInstance<IFeedDB>(db);
                    if (feeds.Count > 0)
                    {
                        foreach (var f in feeds)
                        {
                            Console.WriteLine("importing: Name: \"" + f.name + "\";  Categories: " + String.Join(",", f.category) + "; Twitter: " + f.twitter + "");
                            dbObj.InsertFeeds(f);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File extension not supported!");
            }
            Console.ReadLine();
        }
    }
}
