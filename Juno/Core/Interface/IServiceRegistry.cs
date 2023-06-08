using Juno.Core.Interface;
using Juno.Core.Service;

namespace Juno.Core.Interface
{
    public interface IServiceRegistry
    {
        void RegisterService(string serviceName, IService service);
        void ConfigureService(string serviceName, IServiceConfiguration configuration);
        IService GetService(string serviceName);
        bool ContainsService(string serviceName);
    }
}

