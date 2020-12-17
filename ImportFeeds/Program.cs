using ImportFeeds.Data.Contracts;
using ImportFeeds.DI;
using ImportFeeds.Models;
using ImportFeeds.Services.Contracts;
using StructureMap;
using System;
using System.Collections.Generic;

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

            using (var container = Container.For<SetupIoC>())
            {
                List<Feed> feeds = new List<Feed>();
                if (extension == "json")
                    feeds = container.GetInstance<IFeed<ImportJson>>().Import(filePath);
                else if (extension == "yaml")
                    feeds = container.GetInstance<IFeed<ImportYaml>>().Import(filePath);
                else
                    Console.WriteLine("File extension not supported!");

                if (feeds.Count > 0)
                {
                    var db = container.GetInstance<IFeedDB>();
                    foreach (var f in feeds)
                    {
                        Console.WriteLine("importing: Name: \"" + f.name + "\";  Categories: " + String.Join(",", f.category) + "; Twitter: " + f.twitter + "");
                        db.InsertFeeds(f);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
