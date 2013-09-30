using AutoMapper;
using StructureMap;

namespace TweetLittleBird.Api.IoC
{
    public class IoCForWebApi
    {
        public static IContainer Initialize()
        {
            ObjectFactory.Configure(cfg => cfg.AddRegistry<ApiRegistry>());

            var configuration = ObjectFactory.GetInstance<IConfiguration>();
            foreach (var profile in ObjectFactory.GetAllInstances<Profile>())
            {
                configuration.AddProfile(profile);
            }

            return ObjectFactory.Container;
        }
    }
}