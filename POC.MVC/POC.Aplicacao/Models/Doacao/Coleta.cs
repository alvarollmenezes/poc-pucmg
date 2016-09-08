using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Aplicacao.Models.Doacao
{
    public class Coleta
    {
        public DateTime DataHora { get; set; }
        public int IDDoador { get; set; }
        public int IDLocalDoacao { get; set; }

        public List<Exame> Exames { get; set; }
    }
}
