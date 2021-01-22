using CleanArchitecture.Dominio.Dominio.Clientes;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.CadastrarCliente
{
    public class CadastrarCliente : ICadastrarCliente<CadatrarNovoCliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public CadastrarCliente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Executar(CadatrarNovoCliente objetoDaRequisicao)
        {
            var cliente = new Cliente(objetoDaRequisicao.Nome, objetoDaRequisicao.DataDeNacimento);

            await _clienteRepository.Incluir(cliente);
        }
    }
}