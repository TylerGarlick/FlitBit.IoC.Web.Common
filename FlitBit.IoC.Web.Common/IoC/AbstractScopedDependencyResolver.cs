using System;
using System.Collections.Generic;
using FlitBit.Core;

namespace FlitBit.IoC.Web.Common.IoC
{
    public abstract class AbstractScopedDependencyResolver : IDisposable
    {
        IContainer _container;

        IScopedDependencyResolverManager DependencyResolver { get; set; }

        protected AbstractScopedDependencyResolver(IContainer container)
        {
            _container = container;
            DependencyResolver = Create.New<IScopedDependencyResolverManager>();
        }

        public virtual object GetService(Type serviceType)
        {
            return DependencyResolver.GetService(_container, serviceType);
        }

        public virtual IEnumerable<object> GetServices(Type serviceType)
        {
            return DependencyResolver.GetServices(_container, serviceType);
        }

        public void Dispose()
        {
            Util.Dispose(ref _container);
        }
    }
}