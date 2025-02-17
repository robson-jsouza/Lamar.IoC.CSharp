using Lamar.IoC.DLL.Services.Interfaces;

namespace Lamar.IoC.DLL.Services
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _operationId = Guid.NewGuid();

        public Guid GetOperationId() => _operationId;
    }
}
