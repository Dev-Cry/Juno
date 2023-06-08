using Juno.Core.Service;

namespace Juno.Core.Interface
{
    public interface IServiceManager
    {
        T GetService<T>(string serviceName) where T : IService;
    }
}

