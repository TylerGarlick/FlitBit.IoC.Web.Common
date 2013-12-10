using FlitBit.Wireup;
using FlitBit.Wireup.Meta;

[assembly: Wireup(typeof(FlitBit.IoC.Web.Common.AssemblyWireup))]
namespace FlitBit.IoC.Web.Common
{
    public class AssemblyWireup : IWireupCommand
    {
        public void Execute(IWireupCoordinator coordinator)
        {

        }
    }
}
