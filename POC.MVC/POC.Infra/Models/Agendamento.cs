using System;

namespace POC.Infra.Models
{
    public class Agendamento
    {
        public int ID { get; set; }
        public DateTime DataHora { get; set; }
        public int IDUsuario { get; set; }

        public virtual LocalDoacao LocalDoacao { get; set; }
    }
}
