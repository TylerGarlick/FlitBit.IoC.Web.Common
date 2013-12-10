using System.Web;
using FlitBit.IoC.Meta;

namespace FlitBit.IoC.Web.Common
{
    public interface IPerHttpRequestContainer
    {
        IContainer Current { get; set; }
    }

    [ContainerRegister(typeof(IPerHttpRequestContainer), RegistrationBehaviors.Default)]
    public class DefaultPerHttpRequestContainer : IPerHttpRequestContainer
    {
        public IContainer Current
        {
            set
            {
                HttpContext.Current.Items[Constants.ContainerNamePerRequest] = value;
            }
            get
            {
                return (IContainer)HttpContext.Current.Items[Constants.ContainerNamePerRequest];
            }
        }
    }
}