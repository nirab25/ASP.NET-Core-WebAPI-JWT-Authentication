using DotNetCoreJWTAuth.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DotNetCoreJWTAuth.Services;

namespace DotNetCoreJWTAuth.ServiceRegistration
{
    public class DbRegistrar : IServiceRegistrar
    {
        public void RegisterSevices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MSSQLDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<MSSQLDBContext>();

            services.AddScoped<IProductService, ProductService>();
            //services.AddSingleton<IProductService, CosmosProductService>();
        }
    }
}
