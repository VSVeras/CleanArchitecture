using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
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

        public async Task Executar(ClienteExistente comando)
        {
            var cliente = await _clienteRepository.ObterPor(comando.Id);
            cliente.MudouDe(comando.Nome);
            cliente.NascimentoEm(comando.DataDeNacimento);

            await _clienteRepository.Atualizar(cliente);
        }
    }
}
