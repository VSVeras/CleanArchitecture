using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.ComandosEConsultas
{
    public interface IManipuladorDeComando<TComando> where TComando : IComando
    {
        Task<ResultadoDaMensagem> Executar(TComando comando);
    }
}