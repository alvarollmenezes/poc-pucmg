using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Aplicacao.Models.Doacao
{
    public class Exame
    {
        public int IDColeta { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public string FormatoArquivo { get; set; }
    }
}
