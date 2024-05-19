using Microsoft.AspNetCore.Identity;
using Stocks.Core.Entites.identity;
using Stocks.Repository.Identity;

namespace StockExchange.Extensions
{
    public static class IdentityServiceExtensions
    {

        public static IServiceCollection AddIdentityServices (this IServiceCollection services)
        {
            services.AddAuthentication ();

            services.AddIdentity<AppUser, IdentityRole>()
                     .AddEntityFrameworkStores<AppIdentityDbContext>();

            return services;
        }
    }
}
