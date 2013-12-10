using FlitBit.Wireup;
using FlitBit.Wireup.Meta;
using AssemblyWireup = TestWebApplication.AssemblyWireup;

[assembly: WireupDependency(typeof(FlitBit.IoC.Web.Common.AssemblyWireup))]
[assembly: Wireup(typeof(AssemblyWireup))]
namespace TestWebApplication
{
    public class AssemblyWireup : IWireupCommand
    {
        public void Execute(IWireupCoordinator coordinator)
        {
            
        }
    }
}
