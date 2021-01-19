using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Dominio.Padroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestrutura.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public ClienteRepository()
        {
            if (clientes.Count > 0)
            {
                return;
            }

            clientes.Add(new Cliente(1, "Cliente Qualquer", new DateTime(1970, 05, 27)));
        }

        public async Task<IEnumerable<Cliente>> Todos()
        {
            return await Task.Run(() => clientes.ToList());
        }

        public async Task<Talvez<Cliente>> ObterPor(int id)
        {
            try
            {
                var registro = await Task.Run(() => clientes.FirstOrDefault(onde => onde.Id == id));
                if (registro != null)
                    return Talvez<Cliente>.Algum(registro);

                return Talvez<Cliente>.Nenhum;
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
                pessoa.Id = (clientes.Count() + 1);
                clientes.Add(pessoa);
                return pessoa;
            });
        }

        public async Task Atualizar(Cliente pessoa)
        {
            try
            {
                await Task.Run(() =>
                {
                    var registro = clientes.FirstOrDefault(onde => onde.Id == pessoa.Id);
                    if (registro != null)
                    {
                        clientes.Remove(registro);
                        clientes.Add(pessoa);
                    }
                });
            }
            catch
            {
                throw new Exception("Não foi possível atualizar o cliente");
            }

        }

        public async Task Excluir(int id)
        {
            await Task.Run(() => clientes.Remove(clientes.FirstOrDefault(onde => onde.Id == id)));
        }

        public async Task<IEnumerable<Cliente>> ObterPor(string nome)
        {
            try
            {
                return await Task.Run(() => clientes.Where(onde => onde.Nome.Contains(nome)).ToList());
            }
            catch
            {
                throw new Exception("Não foi possível obter o cliente por id");
            }
        }
    }
}
