using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace TweetLittleBird.Framework.IoC.StructureMap.Web
{
    /// <summary>
    /// Add the following into Global.asax
    /// 
    /// For Mvc
    /// DependencyResolver.SetResolver(new WebSiteStructureMapDependencyResolver(container));
    ///
    /// For WebApi
    /// GlobalConfiguration.Configuration.DependencyResolver = new WebSiteStructureMapDependencyResolver(container);
    /// 
    /// </summary>
    public class WebSiteStructureMapDependencyResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IContainer _container;

        public WebSiteStructureMapDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return _container.TryGetInstance(serviceType);
            }
            return _container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances<object>().Where(s => s.GetType() == serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {

        }
    }
}