using Application.Users;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Ioc
{
    public static class ServicesExtensions
    {
        public static void RegisterPostgresDbContext(this IServiceCollection services, 
                                                     string connectionString)
        {
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
        }

        public static void RegisterQueries(this IServiceCollection services)
        {
            services.AddScoped<IUsersQuery, UsersQuery>();
        }

        public static void RegisterRepositores(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void RegisterCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<IUsersCommandHandler, UsersCommandHandler>();
        }
    }
}
