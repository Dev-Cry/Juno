using Autofac;
using Juno.Core.Bootstrap.Core;
using Juno.Core.Bootstrap.Interface;
using Juno.Core.Interface;
using Juno.Core.Service;

namespace Juno
{
    public class Program
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();

            // Registrace služeb
            builder.RegisterType<Service>().As<IService>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceManager>().As<IServiceManager>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceRegistry>().As<IServiceRegistry>().SingleInstance();
            builder.RegisterType<Bootstrap>().As<IBootstrap>().SingleInstance();

            var container = builder.Build();

            using var scope = container.BeginLifetimeScope();
            var bootstrap = scope.Resolve<IBootstrap>();
            bootstrap.Run();
        }
    }
}
