using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId
{
    public sealed class ConsultarClientePorId : IManipuladorDeConsulta<ObterClientePorId>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultarClientePorId(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ResultadoDaMensagem> Executar(ObterClientePorId consulta)
        {
            var resultado = new ResultadoDaMensagem
            {
                Status = true
            };

            try
            {
                var cliente = await _clienteRepository.ObterPor(consulta.Id);
                if (cliente == null)
                {
                    resultado.Mensagens.Add("O cliente não foi localizado");
                    return resultado;
                }

                resultado.Dados = new ObterInformacoesDoClientePorId(cliente.Id, cliente.Nome, cliente.DataDeNascimento);
                resultado.Mensagens.Add("O cliente foi localizado");
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
