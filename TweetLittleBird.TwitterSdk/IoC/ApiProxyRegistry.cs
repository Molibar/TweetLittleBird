using AutoMapper;
using StructureMap.Configuration.DSL;
using TweetLittleBird.ApiProxy.IoC;
using TweetLittleBird.Framework.Configuration;
using TweetLittleBird.TwitterSdk.Settings;

namespace TweetLittleBird.TwitterSdk.IoC
{
    public class TwitterSdkRegistry : Registry
    {
        public TwitterSdkRegistry()
        {
            IncludeRegistry<ApiProxyRegistry>();

            For<ITwitterApiSettings>()
                .Singleton()
                .Use(TwitterApiSettingsFactory.Create);

            Scan(scan =>
                {
                    scan.AddAllTypesOf<Profile>();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
        }
    }
}