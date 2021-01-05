using CleanArchitecture.Dominio.Dominio.Clientes;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.ConsultarClientePorId
{
    public class ConsultarClientePorId : IConsultaClientePorId<ConsultaPorId, ClientePorId>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultarClientePorId(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        public async Task<ClientePorId> Executar(ConsultaPorId objetoDaRequisicao)
        {
            var cliente = await _clienteRepository.ObterPor(objetoDaRequisicao.Id);

            if (cliente == null)
            {
                return null;
            }

            return new ClientePorId() { Id = cliente.Id, DataDeNacimento = cliente.DataDeNascimento, Nome = cliente.Nome };
        }
    }
}
