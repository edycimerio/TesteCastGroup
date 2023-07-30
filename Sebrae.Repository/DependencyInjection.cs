using Microsoft.Extensions.DependencyInjection;
using Sebrae.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Repository
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddRespositorys(this IServiceCollection services)
        {
            services.AddTransient<IContaRepository, ContaRepository>();

            return services;

        }
    }
}
