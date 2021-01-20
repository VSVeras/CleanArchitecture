﻿using CleanArchitecture.Dominio.Dominio.Clientes;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente
{
    public sealed class AtualizarClienteExistente : IManipuladorDeComando<EditarClienteExistente>
    {
        private readonly IClienteRepository _clienteRepository;

        public AtualizarClienteExistente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ResultadoDaMensagem> Executar(EditarClienteExistente comando)
        {
            var resultado = new ResultadoDaMensagem
            {
                Status = true
            };

            try
            {
                var cliente = await _clienteRepository.ObterPor(comando.Id);
                if (!cliente.Achou)
                {
                    resultado.Mensagens.Add("O cliente não foi localizado");
                    return resultado;
                }

                cliente.Valor.MudouDe(comando.Nome);
                cliente.Valor.NascimentoEm(comando.DataDeNacimento);

                await _clienteRepository.Atualizar(cliente.Valor);

                resultado.Mensagens.Add("O cliente foi atualizado");
            }
            catch (Exception ex)
            {
                resultado.Status = false;
                resultado.Mensagens.Add($"Ocorreu um erro : {ex.Message}");
            }

            return resultado;
        }
    }
}