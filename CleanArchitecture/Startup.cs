using CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente;
using CleanArchitecture.Aplicacao.CasosDeUso.CadastrarCliente;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientes;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientesPorNome;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using CleanArchitecture.Infraestrutura.IndeversaoDeControle;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace CleanArchitecture
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AdicionarDependenciasDaInfraestrutura();

            services.AddTransient<ICadastrarNovoCliente<NovoCliente>, CadastrarNovoCliente>();
            services.AddTransient<IConsultarTodosClientes<IEnumerable<TodosClientes>>, ConsultarTodosClientes>();

            services.AddTransient<IManipuladorDeComando<EditarClienteExistente>, AtualizarClienteExistente>();
            services.AddTransient<IManipuladorDeConsulta<ObterClientePorId>, ConsultarClientePorId>();
            services.AddTransient<IManipuladorDeConsulta<ObterClientesPorNome, List<ClientesPorNome>>, ConsultarClientesPorNome>();

            services.AddSingleton<Mensageiro>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
