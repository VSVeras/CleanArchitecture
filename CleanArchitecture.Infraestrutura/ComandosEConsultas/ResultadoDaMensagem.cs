using System.Collections.Generic;

namespace CleanArchitecture.Infraestrutura.ComandosEConsultas
{
    public class ResultadoDaMensagem
    {
        public bool Status { get; set; }
        public List<string> Mensagens { get; set; }
        public object Dados { get; set; }

        public ResultadoDaMensagem()
        {
            Mensagens = new List<string>();
        }
    }
}
