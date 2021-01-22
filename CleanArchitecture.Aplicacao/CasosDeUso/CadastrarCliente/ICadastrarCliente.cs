using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.CadastrarCliente
{
    public interface ICadastrarCliente<ObjetoDaRequisicao>
    {
        Task Executar(ObjetoDaRequisicao objetoDaRequisicao);
    }
}