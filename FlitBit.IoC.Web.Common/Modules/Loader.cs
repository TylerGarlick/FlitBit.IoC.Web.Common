using System.Web;
using FlitBit.IoC.Web.Common.Modules;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: PreApplicationStartMethod(typeof(Loader), "LoadModule")]
namespace FlitBit.IoC.Web.Common.Modules
{
    public class Loader
    {
        public static void LoadModule()
        {
            DynamicModuleUtility.RegisterModule(typeof(HttpPerRequestScopeHttpModule));
        }
    }
}