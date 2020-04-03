using DotNetCoreJWTAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DotNetCoreJWTAuth.ServiceRegistration
{
    public static class SeviceRegitrarExtensions
    {
        public static void RegistrarServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            //Getting all registrar classes that implementing IServiceRegistrar, Create Instance and Cast
            var serviceRegistrars = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IServiceRegistrar).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IServiceRegistrar>().ToList();
            serviceRegistrars.ForEach(sRegistrar => sRegistrar.RegisterSevices(services, configuration));
        }
    }
}
