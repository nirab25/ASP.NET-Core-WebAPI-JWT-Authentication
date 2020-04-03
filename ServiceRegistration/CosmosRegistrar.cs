using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Documents.Client;
using DotNetCoreJWTAuth.Models;
using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;

namespace DotNetCoreJWTAuth.ServiceRegistration
{
    public class CosmosRegistrar : IServiceRegistrar
    {
        public void RegisterSevices(IServiceCollection services, IConfiguration configuration)
        {
            var cosmosStroeSetting = new CosmosStoreSettings(
                configuration["CosmosSettings:DatabaseName"],
                configuration["CosmosSettings:AccountUri"],
                configuration["CosmosSettings:AccountKey"],
                new ConnectionPolicy { ConnectionMode = ConnectionMode.Direct, ConnectionProtocol = Protocol.Tcp});
            services.AddCosmosStore<CosmosProduct>(cosmosStroeSetting); 
        }
    }
}
