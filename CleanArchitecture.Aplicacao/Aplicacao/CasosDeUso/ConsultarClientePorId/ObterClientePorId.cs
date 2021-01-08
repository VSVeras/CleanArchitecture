﻿using CleanArchitecture.Infraestrutura.ComandosEConsultas;

namespace CleanArchitecture.Aplicacao.Aplicacao.CasosDeUso.ConsultarClientePorId
{
    public class ObterClientePorId : IConsulta
    {
        public int Id { get; }

        public ObterClientePorId(int id)
        {
            Id = id;
        }
    }
}