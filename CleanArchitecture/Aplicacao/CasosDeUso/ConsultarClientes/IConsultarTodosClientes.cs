using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarTodosClientes
{
    public interface IConsultarTodosClientes<ObjetoDaResposta>
    {
        Task<ObjetoDaResposta> Executar();
    }
}
