using CleanArchitecture.Infraestrutura.CQS;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId
{
    public struct ObterClientePorId : IConsulta
    {
        public int Id { get; }

        public ObterClientePorId(int id)
        {
            Id = id;
        }
    }
}