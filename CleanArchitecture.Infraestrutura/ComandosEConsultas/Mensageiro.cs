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

        public async Task Executar(IComando comando)
        {
            Type type = typeof(IManipuladorDeComando<>);
            Type[] typeArgs = { comando.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _serviceProvider.GetService(handlerType);
            await handler.Executar((dynamic)comando);
        }
    }
}
