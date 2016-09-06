using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Aplicacao.Models.Agendamento
{
    public class AgendamentoHorarios
    {
        public List<Horario> Horarios { get; set; }

        public class Horario
        {
            public DateTime dataHora { get; set; }
        }
    }
}
