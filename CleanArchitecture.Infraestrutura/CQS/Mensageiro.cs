using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.CQS
{
    public sealed class Mensageiro
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

        public async Task<ResultadoDaMensagem> Executar(IConsulta consulta)
        {
            Type tipo = typeof(IManipuladorDeConsulta<>);
            Type[] argumentosDoTipo = { consulta.GetType() };
            Type tipoDeManipulador = tipo.MakeGenericType(argumentosDoTipo);

            dynamic manipulador = _provedorDeServico.GetService(tipoDeManipulador);

            return await manipulador.Executar((dynamic)consulta);
        }

        public async Task<T> Executar<T>(IConsulta<T> consulta)
        {
            Type tipo = typeof(IManipuladorDeConsulta<,>);
            Type[] argumentosDoTipo = { consulta.GetType(), typeof(T) };
            Type tipoDeManipulador = tipo.MakeGenericType(argumentosDoTipo);

            dynamic manipulador = _provedorDeServico.GetService(tipoDeManipulador);

            return await manipulador.Executar((dynamic)consulta);
        }
    }
}