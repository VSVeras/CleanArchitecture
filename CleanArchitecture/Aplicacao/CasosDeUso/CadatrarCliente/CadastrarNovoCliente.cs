using CleanArchitecture.Dominio.Clientes;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.CadatrarCliente
{
    public class CadastrarNovoCliente : ICadatrarNovoCliente<NovoCliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public CadastrarNovoCliente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Executar(NovoCliente objetoDaRequisicao)
        {
            var cliente = new Cliente(objetoDaRequisicao.Nome, objetoDaRequisicao.DataDeNacimento);

            await _clienteRepository.Incluir(cliente);
        }
    }
}
