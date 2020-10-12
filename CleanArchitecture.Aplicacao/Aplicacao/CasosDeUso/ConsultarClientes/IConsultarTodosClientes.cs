using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.ConsultarClientes
{
    public interface IConsultarTodosClientes<ObjetoDaResposta>
    {
        Task<ObjetoDaResposta> Executar();
    }
}
