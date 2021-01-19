using CleanArchitecture.Infraestrutura.ComandosEConsultas;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientesPorNome
{
    public class ObterClientesPorNome : IConsulta<ResultadoDaMensagem>
    {
        public string Nome { get; }

        public ObterClientesPorNome(string nome)
        {
            this.Nome = nome;
        }
    }
}
