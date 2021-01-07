using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.ComandosEConsultas
{
    public class Mensageiro
    {
        private readonly IServiceProvider _provedorDeServico;

        public Mensageiro(IServiceProvider provedorDeServico)
        {
            _provedorDeServico = provedorDeServico;
        }

        public async Task<ResultadoDaMensagem> Executar(IComando comando)
        {
            Type tipo = typeof(IManipuladorDeComando<>);
            Type[] argumentosDoTipo = { comando.GetType() };
            Type tipoDeManipulador = tipo.MakeGenericType(argumentosDoTipo);

            dynamic manipulador = _provedorDeServico.GetService(tipoDeManipulador);

            return await manipulador.Executar((dynamic)comando);
        }
    }
}
