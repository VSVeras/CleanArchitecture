using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId
{
    public interface IConsultaClientePorId<ObjetoDaRequisicao, ObjetoDaResposta>
    {
        Task<ObjetoDaResposta> Executar(ObjetoDaRequisicao objetoDaRequisicao);
    }
}
