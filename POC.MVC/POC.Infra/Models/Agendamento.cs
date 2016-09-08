using System;
using System.ComponentModel.DataAnnotations;

namespace POC.Infra.Models
{
    public class Agendamento
    {
        public int ID { get; set; }
        public DateTime DataHora { get; set; }

        [Required]
        public virtual LocalDoacao LocalDoacao { get; set; }
        [Required]
        public virtual Doador Doador { get; set; }
    }
}
