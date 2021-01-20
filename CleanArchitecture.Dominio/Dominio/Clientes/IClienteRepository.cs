using CleanArchitecture.Dominio.Comum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Dominio.Dominio.Clientes
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Todos();

        Task<Talvez<Cliente>> ObterPor(int id);

        Task<IEnumerable<Cliente>> ObterPor(string nome);

        Task<Cliente> Incluir(Cliente item);

        Task Atualizar(Cliente item);

        Task Excluir(int id);
    }
}
