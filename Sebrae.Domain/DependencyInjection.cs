using Microsoft.Extensions.DependencyInjection;
using Sebrae.Domain.Interfaces.Repository;
using Sebrae.Domain.Interfaces.Service;
using Sebrae.Domain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.Domain
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IContaService, ContaService>();

            return services;

        }
    }
}
