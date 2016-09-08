using System;
using System.Collections;

namespace POC.Aplicacao.Models.Agendamento
{
    public class AgendamentoDoacao
    {
        public IList Estados { get; set; }

        public int IDLocalDoacao { get; set; }
        public DateTime DataHora { get; set; }

        public int IDDoador { get; set; }
        public string NomeDoador { get; set; }
        public string CPFDoador { get; set; }
    }
}
