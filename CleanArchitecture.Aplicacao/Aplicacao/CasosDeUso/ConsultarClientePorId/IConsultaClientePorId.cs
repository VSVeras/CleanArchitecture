using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.ConsultarClientePorId
{
    public interface IConsultaClientePorId<ObjetoDaRequisicao, ObjetoDaResposta>
    {
        Task<ObjetoDaResposta> Executar(ObjetoDaRequisicao objetoDaRequisicao);
    }
}
