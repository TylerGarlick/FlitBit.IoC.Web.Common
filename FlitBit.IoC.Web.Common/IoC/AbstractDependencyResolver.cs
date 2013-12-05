namespace FlitBit.IoC.Web.Common.IoC
{
    public abstract class AbstractDependencyResolver
    {
        readonly IContainer _container;

        protected AbstractDependencyResolver(IContainer container)
        {
            _container = container;
        }

        protected IContainer CreateChildContainer()
        {
            return _container.MakeChildContainer(CreationContextOptions.InstanceTracking);
        }
    }
}
