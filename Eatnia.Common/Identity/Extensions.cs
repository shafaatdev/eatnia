using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Eatnia.Common.Identity
{
    public static class Extensions
    {
        public static AuthenticationBuilder AddJwtBearerAuthentication(this IServiceCollection services)
        {
            return services.ConfigureOptions<ConfigureJwtBearerOptions>()
                    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer();
        }
    }
}
