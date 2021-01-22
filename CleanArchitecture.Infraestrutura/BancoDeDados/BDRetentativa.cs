using CleanArchitecture.Infraestrutura.CQS;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.BancoDeDados
{
    public class BDRetentativa<TComando> : IManipuladorDeComando<TComando> where TComando : IComando
    {
        private const int _numeroDeTentativas = 3;
        private readonly IManipuladorDeComando<TComando> _manipuladorDeComando;

        public BDRetentativa(IManipuladorDeComando<TComando> manipuladorDeComando)
        {
            _manipuladorDeComando = manipuladorDeComando;
        }

        public async Task<ResultadoDaMensagem> Executar(TComando comando)
        {
            for (int i = 0; ; i++)
            {
                try
                {
                    return await _manipuladorDeComando.Executar(comando);
                }
                catch (Exception)
                {
                    if (i >= _numeroDeTentativas)
                        throw;
                }
            }
        }
    }
}
