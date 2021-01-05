using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.ComandosEConsultas
{
    public interface IManipuladorDeComando<TComando> where TComando : IComando
    {
        Task Executar(TComando comando);
    }

}
