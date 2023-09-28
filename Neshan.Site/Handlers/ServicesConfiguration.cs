using Neshan.Application.IServices;
using Neshan.Application.Services;
using Neshan.Domain.Contracts;
using Neshan.Infrastructure.Repository;

namespace Neshan.Site.Handlers
{
    public static class ServicesConfiguration
    {
        public static void AppServices(this IServiceCollection services)
        {
            //services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShortUrlService, ShortUrlService>();

            //reposotories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
        }
    }
}
