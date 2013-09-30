using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TweetLittleBird.Framework.IoC.StructureMap.WcfServices
{
    public class StructureMapServiceBehavior : IServiceBehavior
    {
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcherBase cdb in serviceHostBase.ChannelDispatchers)
            {
                var cd = cdb as ChannelDispatcher;
                if (cd == null) continue;
                foreach (var ed in cd.Endpoints)
                {
                    ed.DispatchRuntime
                        .InstanceContextInitializers
                        .Add(new InstanceContextCacheInitializer());
                    ed.DispatchRuntime.InstanceProvider =
                        new StructureMapInstanceProvider(serviceDescription.ServiceType);
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
                                         Collection<ServiceEndpoint> endpoints,
                                         BindingParameterCollection bindingParameters)
        {
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }
}