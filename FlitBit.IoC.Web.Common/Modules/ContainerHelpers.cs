using System.Web;

namespace FlitBit.IoC.Web.Common
{
    public static class ContainerHelpers
    {
        public static IContainer Current
        {
            get
            {
                var currentContainer = HttpContext.Current.Items[Constants.ContainerNamePerRequest];
                if (currentContainer == null)
                    HttpContext.Current.Items[Constants.ContainerNamePerRequest] = Container.Current.MakeChildContainer(CreationContextOptions.InstanceTracking);


                return (IContainer)HttpContext.Current.Items[Constants.ContainerNamePerRequest];
            }
            set
            {
                HttpContext.Current.Items[Constants.ContainerNamePerRequest] = value;
            }
        }
    }
}