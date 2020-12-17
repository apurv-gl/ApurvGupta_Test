using AutoMapper;
using ImportFeeds.AutoMapper;
using ImportFeeds.DI;
using ImportFeeds.Models;
using ImportFeeds.Services.Contracts;
using Newtonsoft.Json;
using StructureMap;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace ImportFeeds.Services.Implementations
{
    public class FeedYaml : IFeed
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }
        public List<Feed> Import(string filePath)
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            MapperConfiguration = autoMapperConfig.MapperConfigurationSettings();
            Mapper = MapperConfiguration.CreateMapper();

            var container = Container.For<SetupIoC>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string data = r.ReadToEnd();
                var items = new Deserializer().Deserialize<List<ImportYaml>>(data);
                return Mapper.Map<List<Feed>>(items);
            }
        }
    }
}
