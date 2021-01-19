using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientes;
using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientesPorNome
{
    public sealed class ConsultarClientesPorNome : IManipuladorDeConsulta<ObterClientesPorNome, List<ClientesPorNome>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultarClientesPorNome(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClientesPorNome>> Executar(ObterClientesPorNome consulta)
        {
            var clientes = await _clienteRepository.ObterPor(consulta.Nome);

            var resultado = (from registro in clientes
                             select new ClientesPorNome()
                             {
                                 Id = registro.Id,
                                 Nome = registro.Nome,
                                 DataDeNascimento = registro.DataDeNascimento
                             });

            return resultado.ToList();
        }
    }
}
