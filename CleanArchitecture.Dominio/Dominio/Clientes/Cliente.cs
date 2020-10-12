using System;

namespace CleanArchitecture.Dominio.Dominio.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public DateTime DataDeNacimento { get; private set; }

        public Cliente(string nome, DateTime dataDeNacimento)
        {
            Nome = nome;
            DataDeNacimento = dataDeNacimento;
        }

        public void MudouDe(string nome)
        {
            Nome = nome;
        }

        public void NascimentoEm(DateTime data)
        {
            DataDeNacimento = data;
        }
    }
}
