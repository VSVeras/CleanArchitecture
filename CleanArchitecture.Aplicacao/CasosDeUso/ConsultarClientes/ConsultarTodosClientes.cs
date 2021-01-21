using CleanArchitecture.Dominio.Dominio.Clientes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientes
{
    public class ConsultarTodosClientes : IConsultarTodosClientes<IEnumerable<ObterTodosClientes>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultarTodosClientes(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ObterTodosClientes>> Executar()
        {
            var clientes = await _clienteRepository.Todos();

            return from cliente in clientes
                   select new ObterTodosClientes() { Id = cliente.Id, Nome = cliente.Nome, DataDeNascimento = cliente.DataDeNascimento };
        }
    }
}