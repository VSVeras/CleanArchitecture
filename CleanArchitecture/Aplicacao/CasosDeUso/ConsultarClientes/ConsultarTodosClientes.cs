﻿using CleanArchitecture.Dominio.Clientes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.ConsultarTodosClientes
{
    public class ConsultarTodosClientes : IConsultarTodosClientes<IEnumerable<TodosClientes>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ConsultarTodosClientes(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<TodosClientes>> Executar()
        {
            var clientes = await _clienteRepository.Todos();

            return from cliente in clientes
                   select new TodosClientes() { Id = cliente.Id, Nome = cliente.Nome, DataDeNacimento = cliente.DataDeNacimento };
        }
    }
}
