using CleanArchitecture.Dominio.Dominio.Clientes;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.CadastrarCliente
{
    public class CadastrarNovoCliente : ICadastrarNovoCliente<NovoCliente>
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