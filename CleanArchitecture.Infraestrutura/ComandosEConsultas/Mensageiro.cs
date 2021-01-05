using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.ComandosEConsultas
{
    public class Mensageiro
    {
        private readonly IServiceProvider _serviceProvider;

        public Mensageiro(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<ResultadoDaMensagem> Executar(IComando comando)
        {
            Type tipo = typeof(IManipuladorDeComando<>);
            Type[] argumentosDoTipo = { comando.GetType() };
            Type tipoDeManipulador = tipo.MakeGenericType(argumentosDoTipo);

            dynamic handler = _serviceProvider.GetService(tipoDeManipulador);

            return await handler.Executar((dynamic)comando);
        }
    }
}
