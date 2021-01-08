using System;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId
{
    public class ObterInformacoesDoClientePorId
    {
        public int Id { get; }
        public string Nome { get; }
        public DateTime DataDeNascimento { get; }

        public ObterInformacoesDoClientePorId(int id, string nome, DateTime dataDeNascimento)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }
    }
}
