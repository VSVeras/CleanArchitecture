using CleanArchitecture.Infraestrutura.CQS;
using System;

namespace CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente
{
    public struct AtualizarClienteExistente : IComando
    {
        public int Id { get; }
        public string Nome { get; }
        public DateTime DataDeNacimento { get; }

        public AtualizarClienteExistente(int id, string nome, DateTime dataDeNacimento)
        {
            Id = id;
            Nome = nome;
            DataDeNacimento = dataDeNacimento;
        }
    }
}