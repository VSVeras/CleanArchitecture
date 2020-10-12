using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestrutura.IndeversaoDeControle
{
    public static class DependenciasDaInfraestrutura
    {
        public static IServiceCollection AdicionarDependenciasDaInfraestrutura(this IServiceCollection services)

        {
            services.AddTransient<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
