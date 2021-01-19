using CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente;
using CleanArchitecture.Aplicacao.CasosDeUso.CadastrarCliente;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientePorId;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientes;
using CleanArchitecture.Aplicacao.CasosDeUso.ConsultarClientesPorNome;
using CleanArchitecture.Infraestrutura.ComandosEConsultas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CleanArchitecture.Controllers
{
    [Route("api/v1/[Controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClienteController : Controller
    {
        private readonly Mensageiro _mensageiro;

        public ClienteController(Mensageiro mensageiro)
        {
            _mensageiro = mensageiro;
        }

        /*
            http://localhost:5000/api/v1/cliente
            {
                "Nome" : "VSVeras",
                "DataDeNascimento" : "1970-05-27T00:00:00"
            }
        */
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Novo([FromBody] NovoCliente novoCliente, [FromServices] ICadastrarNovoCliente<NovoCliente> cadastrarNovoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await cadastrarNovoCliente.Executar(novoCliente);

            return Ok();
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarTodos([FromServices] IConsultarTodosClientes<IEnumerable<TodosClientes>> consultarTodosCliente)
        {
            var clientes = await consultarTodosCliente.Executar();

            if (clientes.ToList().Count == 0)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        //http://localhost:5000/api/v1/cliente/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contrato = new ObterClientePorId(id);
            var resultado = await _mensageiro.Executar(contrato);
            var mensagens = resultado.Mensagens.Select(itens => itens);
            if (!resultado.Status)
            {
                return BadRequest(new { erros = mensagens });
            }

            return Ok(new { informacao = mensagens, dados = resultado.Dados });
        }

        /*
            http://localhost:5000/api/v1/cliente/1
            {
                "Nome" : "VSVeras",
                "DataDeNascimento" : "1970-05-27T00:00:00"
            }
         */
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Atualizar(int id, [FromBody] EditarInformacoesDoCliente contrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Command's, Query's e DTO's são termos sobrecarregados e fazem coisas diferentes, lidam com problemas diferentes. 
            //Commands: Chamadas de método serializáveis
            //DTOs: Contratos de dados e compatibilidade com versões anteriores
            //É dessa forma que mantemos a compatibilidade retroativa, se você não precisar dessa compatibilidade pode usar comandos no lugar de dto's.
            var comando = new EditarClienteExistente(id, contrato.Nome, contrato.DataDeNascimento);
            var resultado = await _mensageiro.Executar(comando);
            var mensagens = resultado.Mensagens.Select(itens => itens);
            if (!resultado.Status)
            {
                return BadRequest(new { erros = mensagens });
            }

            return Ok(new { informacao = mensagens, dados = resultado.Dados });
        }

        //http://localhost:5000/api/v1/Cliente/Nome/Cliente
        [HttpGet("Nome/{nome}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ConsultarPorNome(string nome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contrato = new ObterClientesPorNome(nome);
            var resultado = await _mensageiro.Executar(contrato);
            var mensagens = resultado.Mensagens.Select(itens => itens);
            if (!resultado.Status)
            {
                return BadRequest(new { erros = mensagens });
            }

            return Ok(new { informacao = mensagens, dados = resultado.Dados });
        }
    }
}