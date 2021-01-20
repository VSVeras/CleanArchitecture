using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.CQS
{
    public interface IManipuladorDeConsulta<TConsulta> where TConsulta : IConsulta
    {
        Task<ResultadoDaMensagem> Executar(TConsulta consulta);
    }

    public interface IManipuladorDeConsulta<TConsulta, TResultado> where TConsulta : IConsulta<TResultado>
    {
        Task<TResultado> Executar(TConsulta consulta);
    }
}