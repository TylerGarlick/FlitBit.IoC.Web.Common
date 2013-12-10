using System.Web;
using FlitBit.Core;

namespace FlitBit.IoC.Web.Common.Modules
{
    public class HttpPerRequestScopeHttpModule : IHttpModule
    {
        IContainer _container;

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, args) =>
                                    {
                                        _container = Container.Current.MakeChildContainer(CreationContextOptions.InstanceTracking);
                                        ContainerHelpers.Current = _container;
                                    };
        }

        public void Dispose()
        {
            Util.Dispose(ref _container);
        }
    }
}
