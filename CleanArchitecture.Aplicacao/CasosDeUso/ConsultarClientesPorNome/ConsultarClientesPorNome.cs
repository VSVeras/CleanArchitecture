using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientes;
using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientesPorNome
{
    public sealed class ConsultarClientesPorNome : IManipuladorDeConsulta<ObterClientesPorNome, ResultadoDaMensagem>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultarClientesPorNome(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ResultadoDaMensagem> Executar(ObterClientesPorNome consulta)
        {
            var resultado = new ResultadoDaMensagem
            {
                Status = true
            };

            try
            {
                var clientes = await _clienteRepository.ObterPor(consulta.Nome);
                if (!clientes?.Any() ?? true)
                {
                    resultado.Mensagens.Add("Os clientes não foram localizados");
                    return resultado;
                }

                resultado.Dados = from registro in clientes
                                  select new ClientesPorNome() { Id = registro.Id, Nome = registro.Nome, DataDeNascimento = registro.DataDeNascimento };
                resultado.Mensagens.Add("Os clientes foram localizados");
            }
            catch (Exception ex)
            {
                resultado.Status = false;
                resultado.Mensagens.Add($"Ocorreu um erro : {ex.Message}");
            }

            return resultado;
        }
    }
}
