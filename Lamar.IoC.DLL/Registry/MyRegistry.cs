using Lamar.IoC.DLL.Services.Interfaces;
using Lamar.IoC.DLL.Services;

namespace Lamar.IoC.DLL.Registry
{
    public class MyRegistry : ServiceRegistry
    {
        public MyRegistry()
        {
            // Register ScopedService as scoped
            For<IScopedService>().Use<ScopedService>().Scoped();
        }
    }
}
