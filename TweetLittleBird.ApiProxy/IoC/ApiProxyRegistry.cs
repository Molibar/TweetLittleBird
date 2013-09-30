using AutoMapper;
using StructureMap.Configuration.DSL;

namespace TweetLittleBird.ApiProxy.IoC
{
    public class ApiProxyRegistry : Registry
    {
        public ApiProxyRegistry()
        {

            Scan(scan =>
                {
                    scan.AddAllTypesOf<Profile>();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
        }
    }
}