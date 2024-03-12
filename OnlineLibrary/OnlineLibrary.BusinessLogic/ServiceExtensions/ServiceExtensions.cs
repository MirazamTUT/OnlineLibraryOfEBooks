using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineLibrary.BusinessLogic.Service.IServices;
using OnlineLibrary.BusinessLogic.Service.Services;
using OnlineLibrary.DataAccess.DbConnection;
using OnlineLibrary.DataAccess.Repository.IRepositories;
using OnlineLibrary.DataAccess.Repository.Repositories;

namespace OnlineLibrary.BusinessLogic.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc();

            services.AddScoped<OnlineLibraryDbContext>();

            services.AddScoped<IEBookRepository, EBookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUsersLibraryRepository, UsersLibraryRepository>();

            services.AddScoped<IEBookService, EBookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUsersLibraryService, UsersLibraryService>();
        }
    }
}
