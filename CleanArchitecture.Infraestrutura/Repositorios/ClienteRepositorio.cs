using CleanArchitecture.Dominio.Dominio.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private static Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();

        public ClienteRepository()
        {
            if (clientes.Count > 0)
            {
                return;
            }

            clientes.Add(1, new Cliente(1, "Cliente Qualquer", new DateTime(1970, 05, 27)));
        }

        public async Task<IEnumerable<Cliente>> Todos()
        {
            return await Task.Run(() => clientes.Values.ToList());
        }

        public async Task<Cliente> ObterPor(int id)
        {
            try
            {
                return await Task.Run(() => clientes.GetValueOrDefault(id));
            }
            catch
            {
                throw new Exception("Não foi possível obter o cliente por id");
            }
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
            try
            {
                await Task.Run(() =>
                {
                    clientes.Remove(pessoa.Id);
                    clientes.Add(pessoa.Id, pessoa);
                });
            }
            catch
            {
                throw new Exception("Não foi possível atualizar o cliente");
            }

        }

        public async Task Excluir(int id)
        {
            await Task.Run(() => clientes.Remove(id));
        }
    }
}
