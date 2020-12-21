using CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.AtualizarCliente;
using CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.CadastrarCliente;
using CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.ConsultarClientePorId;
using CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.ConsultarClientes;
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
            services.AddTransient<IAtualizarClienteExistente<ClienteExistente>, AtualizarClienteExistente>();
            services.AddTransient<IConsultarTodosClientes<IEnumerable<TodosClientes>>, ConsultarTodosClientes>();
            services.AddTransient<IConsultaClientePorId<ConsultaPorId, ClientePorId>, ConsultarClientePorId>();
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
