using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.CadastrarCliente
{
    public interface ICadastrarNovoCliente<ObjetoDaRequisicao>
    {
        Task Executar(ObjetoDaRequisicao objetoDaRequisicao);
    }
}
