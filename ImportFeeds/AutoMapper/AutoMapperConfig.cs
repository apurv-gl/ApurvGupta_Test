using AutoMapper;
using ImportFeeds.Models;

namespace ImportFeeds.AutoMapper
{
    public class AutoMapperConfig
    {
        public MapperConfiguration MapperConfigurationSettings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Products, Feed>()
                .ForMember(a => a.category, b => b.MapFrom(c => c.Category))
                .ForMember(a => a.name, b => b.MapFrom(c => c.Title))
                .ForMember(a => a.twitter, b => b.MapFrom(c => c.Twitter)).ReverseMap();

                cfg.CreateMap<ImportYaml, Feed>()
                 .ForMember(a => a.category, b => b.MapFrom(c => c.allTags))
                 .ForMember(a => a.name, b => b.MapFrom(c => c.name))
                 .ForMember(a => a.twitter, b => b.MapFrom(c => c.twitter)).ReverseMap();
            });
            return MapperConfiguration;
        }
        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
}
