using System.Linq;
using System.Web.Http;
using System.Web.Http.Filters;
using TweetLittleBird.Framework.IoC.StructureMap.Web;
using TweetLittleBird.Framework.IoC.StructureMap.Web.WebApi;

namespace TweetLittleBird.Api.App_Start
{
    public class IoCConfig
    {
        public static void InitializeContainer()
        {
            var container = IoC.IoCForWebApi.Initialize();

            GlobalConfiguration.Configuration.DependencyResolver = new WebSiteStructureMapDependencyResolver(container);

            var defaultActionDescriptorFilterProvider = GlobalConfiguration.Configuration.Services.GetFilterProviders().Single(i => i is ActionDescriptorFilterProvider);
            GlobalConfiguration.Configuration.Services.Remove(typeof(IFilterProvider), defaultActionDescriptorFilterProvider);
            GlobalConfiguration.Configuration.Services.Add(typeof(IFilterProvider),
                                                           new InjectableActionDescriptorFilterProvider
                                                               (container));
        }
    }
}