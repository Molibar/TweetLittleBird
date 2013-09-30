using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;
using StructureMap.Configuration.DSL;

namespace TweetLittleBird.Framework.Mapper.AutoMapper
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            For<ConfigurationStore>().Singleton().Use<ConfigurationStore>()
                .Ctor<IEnumerable<IObjectMapper>>().Is(MapperRegistry.AllMappers());
            For<IConfigurationProvider>().Use(ctx => ctx.GetInstance<ConfigurationStore>());
            For<IConfiguration>().Use(ctx => ctx.GetInstance<ConfigurationStore>());
            For<ITypeMapFactory>().Use<TypeMapFactory>();
            For<IMappingEngine>().Use<MappingEngine>();

            For<IEntityMapper>().Use<EntityMapper>();
        }
    }
}
