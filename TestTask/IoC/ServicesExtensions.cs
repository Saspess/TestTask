using TestTask.Data;
using TestTask.Repositories.Implementation;
using TestTask.Repositories.Interfaces;
using TestTask.Services.Implementation;
using TestTask.Services.Interfaces;

namespace TestTask.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.ConfigureDbContext()
                .ConfigureRepositories()
                .ConfigureServices();

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
