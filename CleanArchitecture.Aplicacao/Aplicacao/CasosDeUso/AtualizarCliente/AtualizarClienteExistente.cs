using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.AtualizarCliente
{
    public class AtualizarClienteExistente : IManipuladorDeComando<ClienteExistente>
    {
        private readonly IClienteRepository _clienteRepository;

        public AtualizarClienteExistente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ResultadoDaMensagem> Executar(ClienteExistente comando)
        {
            var resultado = new ResultadoDaMensagem();
            resultado.Status = false;

            try
            {
                var cliente = await _clienteRepository.ObterPor(comando.Id);
                if (cliente == null)
                {
                    resultado.Mensagens.Add("O cliente não foi localizado");
                    return resultado;
                }

                cliente.MudouDe(comando.Nome);
                cliente.NascimentoEm(comando.DataDeNacimento);

                await _clienteRepository.Atualizar(cliente);

                resultado.Status = true;
                resultado.Mensagens.Add("O cliente foi atualizado");
            }
            catch (Exception ex)
            {
                resultado.Mensagens.Add($"Ocorreu um erro : {ex.Message}");
            }

            return resultado;
        }
    }
}
