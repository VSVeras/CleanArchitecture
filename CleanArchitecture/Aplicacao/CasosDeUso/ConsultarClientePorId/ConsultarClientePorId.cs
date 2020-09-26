using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId;
using CleanArchitecture.Dominio.Clientes;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarCliente
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

            if(cliente == null)
            {
                return null;
            }

            return new ClientePorId() { Id = cliente.Id, DataDeNacimento = cliente.DataDeNacimento, Nome = cliente.Nome };
        }
    }
}
