using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System;

namespace CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.AtualizarCliente
{

    public class ClienteExistente : IComando
    {
        public int Id { get; }
        public string Nome { get; }
        public DateTime DataDeNacimento { get; }

        public ClienteExistente(int id, string nome, DateTime dataDeNacimento)
        {
            Id = id;
            Nome = nome;
            DataDeNacimento = dataDeNacimento;
        }
    }
}
