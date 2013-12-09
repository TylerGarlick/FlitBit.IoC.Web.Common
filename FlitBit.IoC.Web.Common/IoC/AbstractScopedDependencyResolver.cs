using System;
using System.Collections.Generic;

namespace FlitBit.IoC.Web.Common.IoC
{
    public abstract class AbstractScopedDependencyResolver
    {
        readonly IContainer _container;

        protected AbstractScopedDependencyResolver()
        {
            _container = ContainerHelpers.Current;
        }

        protected virtual object ResolveService(Type serviceType)
        {
            if (_container.CanConstruct(serviceType))
                return _container.NewUntyped(LifespanTracking.Automatic, serviceType);
            return default(Type);
        }

        protected virtual IEnumerable<object> ResolveServices(Type serviceType)
        {
            if (_container.CanConstruct(serviceType))
            {
                var enumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
                return (IEnumerable<object>)_container.NewUntyped(LifespanTracking.Automatic, enumerable);
            }
            return default(IEnumerable<object>);
        }
    }
}