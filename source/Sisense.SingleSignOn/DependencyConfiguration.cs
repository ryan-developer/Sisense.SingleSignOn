using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Sisense.SingleSignOn
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection UseSisenseSsoProviders(IServiceCollection services)
        {
            services.TryAddSingleton<ISisenseJwtProvider, SisenseJwtProvider>();
            return services;
        }
    }
}
