using System.Web;

namespace FlitBit.IoC.Web.Common
{
    public static class ContainerHelpers
    {
        const string ItemName = "HttpPerRequestHttpModule";
        public static IContainer Current
        {
            set
            {
                HttpContext.Current.Items[ItemName] = value;
            }
            get
            {
                return (IContainer)HttpContext.Current.Items[ItemName];
            }
        }
    }
}