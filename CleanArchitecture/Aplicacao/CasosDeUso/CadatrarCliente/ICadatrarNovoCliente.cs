using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.CadatrarCliente
{
    public interface ICadatrarNovoCliente<ObjetoDaRequisicao>
    {
        Task Executar(ObjetoDaRequisicao objetoDaRequisicao);
    }
}
