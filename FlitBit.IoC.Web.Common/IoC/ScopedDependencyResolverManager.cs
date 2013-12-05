using System;
using System.Collections.Generic;
using System.Linq;
using FlitBit.IoC.Meta;

namespace FlitBit.IoC.Web.Common.IoC
{
    public interface IScopedDependencyResolverManager
    {
        object GetService(IContainer container, Type serviceType);
        IEnumerable<object> GetServices(IContainer currentContainer, Type serviceType);
        IContainer CreateChildContainer(IContainer container);
    }

    [ContainerRegister(typeof(IScopedDependencyResolverManager), RegistrationBehaviors.Default)]
    public class ScopedDependencyResolverManager : IScopedDependencyResolverManager
    {
        public object GetService(IContainer container, Type serviceType)
        {
            if (container.CanConstruct(serviceType))
                return container.NewUntyped(LifespanTracking.Automatic, serviceType);
            return default(Type);
        }

        public IEnumerable<object> GetServices(IContainer container, Type serviceType)
        {
            if (container.CanConstruct(serviceType))
            {
                var enumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
                return (IEnumerable<object>)container.NewUntyped(LifespanTracking.Automatic, enumerable);
            }

            return Enumerable.Empty<object>();
        }

        public IContainer CreateChildContainer(IContainer container)
        {
            return container.MakeChildContainer(CreationContextOptions.InstanceTracking);
        }
    }
}
