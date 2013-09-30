using AutoMapper;
using StructureMap.Configuration.DSL;
using TweetLittleBird.Framework.IoC;
using TweetLittleBird.TwitterSdk.IoC;

namespace TweetLittleBird.Api.IoC
{
    public class ApiRegistry : Registry
    {
        public ApiRegistry()
        {
            IncludeRegistry<FrameworkRegistry>();
            IncludeRegistry<TwitterSdkRegistry>();

            Scan(scan =>
                {
                    scan.AddAllTypesOf<Profile>();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
        }
    }
}