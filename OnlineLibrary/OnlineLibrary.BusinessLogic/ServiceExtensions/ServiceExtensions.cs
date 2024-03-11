using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineLibrary.DataAccess.DbConnection;

namespace OnlineLibrary.BusinessLogic.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc();

            services.AddScoped<OnlineLibraryDbContext>();
        }
    }
}
