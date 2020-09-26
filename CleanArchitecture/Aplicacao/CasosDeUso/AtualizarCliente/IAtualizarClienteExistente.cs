﻿using System.Threading.Tasks;

namespace CleanArchitecture.Aplicacao.CasosDeUso.AtualizarCliente
{
    public interface IAtualizarClienteExistente<ObjetoDaRequisicao>
    {
        Task Executar(ObjetoDaRequisicao objetoDaRequisicao);
    }
}
