using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Sisense.SingleSignOn
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddSisenseSsoProviders(IServiceCollection services)
        {
            services.TryAddSingleton<ISisenseJwtProvider, SisenseJwtProvider>();
            return services;
        }
    }
}
