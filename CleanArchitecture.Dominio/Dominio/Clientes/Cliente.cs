using System;

namespace CleanArchitecture.Dominio.Dominio.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public DateTime DataDeNascimento { get; private set; }

        public Cliente(int id, string nome, DateTime dataDeNascimento)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }

        public Cliente(string nome, DateTime dataDeNascimento)
        {
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }

        public void MudouDe(string nome)
        {
            Nome = nome;
        }

        public void NascimentoEm(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
        }
    }
}