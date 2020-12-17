using AutoMapper;
using ImportFeeds.AutoMapper;
using ImportFeeds.Models;
using ImportFeeds.Services.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ImportFeeds.Services.Implementations
{
    public class JsonConverter : IFeedConverter
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }
        public List<Feed> Import(string filePath)
        {
            AutoMapperConfig autoMapperConfig = new AutoMapperConfig();
            MapperConfiguration = autoMapperConfig.MapperConfigurationSettings();
            Mapper = MapperConfiguration.CreateMapper();

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<ImportJson>(json);
                return Mapper.Map<List<Feed>>(items.Products);
            }
        }
    }
}
