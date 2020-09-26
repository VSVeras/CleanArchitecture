using CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente;
using CleanArchitecture.Aplicacao.CasosDeUso.CadatrarCliente;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarCliente;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarTodosClientes;
using CleanArchitecture.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.Repositorios;
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

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ICadatrarNovoCliente<NovoCliente>, CadastrarNovoCliente>();
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
