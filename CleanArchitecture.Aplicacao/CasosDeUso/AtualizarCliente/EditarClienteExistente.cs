using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System;

namespace CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente
{

    public class EditarClienteExistente : IComando
    {
        public int Id { get; }
        public string Nome { get; }
        public DateTime DataDeNacimento { get; }

        public EditarClienteExistente(int id, string nome, DateTime dataDeNacimento)
        {
            Id = id;
            Nome = nome;
            DataDeNacimento = dataDeNacimento;
        }
    }
}
