using Juno.Core.Interface;

namespace Juno.Core.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly IServiceRegistry serviceRegistry;

        public ServiceManager(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        public T GetService<T>(string serviceName) where T : IService
        {
            if (!serviceRegistry.ContainsService(serviceName))
            {
                throw new KeyNotFoundException($"Service '{serviceName}' is not registered.");
            }

            var service = serviceRegistry.GetService(serviceName);

            if (service is not T typedService)
            {
                throw new InvalidCastException($"Service '{serviceName}' cannot be cast to type '{typeof(T).Name}'.");
            }

            return typedService;
        }
    }
}
