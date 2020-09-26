using CleanArchitecture.Dominio.Clientes;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente
{
    public class AtualizarClienteExistente : IAtualizarClienteExistente<ClienteExistente>
    {
        private readonly IClienteRepository _clienteRepository;

        public AtualizarClienteExistente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Executar(ClienteExistente objetoDaRequisicao)
        {
            var cliente = await _clienteRepository.ObterPor(objetoDaRequisicao.Id);
            cliente.MudouDe(objetoDaRequisicao.Nome);
            cliente.NascimentoEm(objetoDaRequisicao.DataDeNacimento);

            await _clienteRepository.Atualizar(cliente);
        }
    }
}
