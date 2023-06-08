using Juno.Core.Bootstrap.Interface;
using Juno.Core.Interface;
using Juno.Core.Service;

namespace Juno.Core.Bootstrap.Core;

public class Bootstrap : IBootstrap
{
    private readonly IServiceRegistry serviceRegistry;

    public Bootstrap(IServiceRegistry serviceRegistry)
    {
        this.serviceRegistry = serviceRegistry;
    }

    public void Run()
    {
        // Registrace služeb
        RegisterServices();

        // Konfigurace služeb
        ConfigureServices();
    }

    private void RegisterServices()
    {
        serviceRegistry.RegisterService("Service", new Service());

    }

    private void ConfigureServices()
    {
        var serviceConfiguration = new ServiceConfiguration();
        serviceRegistry.ConfigureService("Service", serviceConfiguration);

    }
}



