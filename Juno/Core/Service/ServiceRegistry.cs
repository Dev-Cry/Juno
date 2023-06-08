using Juno.Core.Interface;
using System;
using System.Collections.Generic;

namespace Juno.Core.Service
{
    public class ServiceRegistry : IServiceRegistry
    {
        private readonly Dictionary<string, IService> services;

        public ServiceRegistry()
        {
            services = new Dictionary<string, IService>();
        }

        public void RegisterService(string serviceName, IService service)
        {
            if (services.ContainsKey(serviceName))
            {
                throw new InvalidOperationException("Service with the same name already exists.");
            }

            services.Add(serviceName, service);
        }

        public void ConfigureService(string serviceName, IServiceConfiguration configuration)
        {
            if (!services.ContainsKey(serviceName))
            {
                throw new InvalidOperationException("Service does not exist.");
            }

            IService service = services[serviceName];
            service.Configure(configuration);
        }
        public IService GetService(string serviceName)
        {
            if (!services.ContainsKey(serviceName))
            {
                throw new InvalidOperationException("Service does not exist.");
            }

            return services[serviceName];
        }

        public bool ContainsService(string serviceName)
        {
            throw new NotImplementedException();
        }
    }
}

