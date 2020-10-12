using CleanArchitecture.Dominio.Dominio.Clientes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private static Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();

        public async Task<IEnumerable<Cliente>> Todos()
        {
            return await Task.Run(() => clientes.Values.ToList());
        }

        public async Task<Cliente> ObterPor(int id)
        {
            return await Task.Run(() => clientes.GetValueOrDefault(id));
        }

        public async Task<Cliente> Incluir(Cliente pessoa)
        {
            return await Task.Run(() =>
            {
                var id = clientes.Count() + 1;
                pessoa.Id = id;
                clientes.Add(id, pessoa);
                return pessoa;
            });
        }

        public async Task Atualizar(Cliente pessoa)
        {
            await Task.Run(() =>
            {
                clientes.Remove(pessoa.Id);
                clientes.Add(pessoa.Id, pessoa);
            });
        }

        public async Task Excluir(int id)
        {
            await Task.Run(() => clientes.Remove(id));
        }
    }
}
