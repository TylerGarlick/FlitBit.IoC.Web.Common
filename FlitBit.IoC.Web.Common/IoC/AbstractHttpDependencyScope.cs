using System;
using System.Collections.Generic;
using System.Linq;
using FlitBit.Core;

namespace FlitBit.IoC.Web.Common.IoC
{
    public abstract class AbstractHttpDependencyScope : IDisposable
    {
        IContainer _container;

        protected AbstractHttpDependencyScope(IContainer container)
        {
            _container = container;
        }

        public virtual object GetService(Type serviceType)
        {
            if (_container.CanConstruct(serviceType))
                return FactoryProvider.Factory.CreateInstance(serviceType);

            return default(Type);
        }

        public virtual IEnumerable<object> GetServices(Type serviceType)
        {
            if (_container.CanConstruct(serviceType))
            {
                var enumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
                return (IEnumerable<object>)_container.NewUntyped(LifespanTracking.Automatic, enumerable);
            }

            return Enumerable.Empty<object>();
        }

        public void Dispose()
        {
            Util.Dispose(ref _container);
        }
    }
}