using AutoMapper;
using StructureMap.Configuration.DSL;
using TweetLittleBird.Framework.Mapper.AutoMapper;

namespace TweetLittleBird.Framework.IoC
{
    public class FrameworkRegistry : Registry
    {
        public FrameworkRegistry()
        {
            IncludeRegistry<AutoMapperRegistry>();

            Scan(scan =>
                {
                    scan.AddAllTypesOf<Profile>();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
        }
    }
}