using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientes;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System.Collections.Generic;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientesPorNome
{
    public class ObterClientesPorNome : IConsulta<List<ClientesPorNome>>
    {
        public string Nome { get; }

        public ObterClientesPorNome(string nome)
        {
            this.Nome = nome;
        }
    }
}