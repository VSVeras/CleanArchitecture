using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Dominio.Dominio.Clientes
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Todos();

        Task<Cliente> ObterPor(int id);

        Task<Cliente> Incluir(Cliente item);

        Task Atualizar(Cliente item);

        Task Excluir(int id);
    }
}
