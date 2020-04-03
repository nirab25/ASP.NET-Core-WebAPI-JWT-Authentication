using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreJWTAuth
{
    public interface IServiceRegistrar
    {
        void RegisterSevices(IServiceCollection services, IConfiguration configuration);
    }
}
