using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POC.Infra.Models
{
    public class Coleta
    {
        public int ID { get; set; }
        public DateTime DataHora { get; set; }

        [Required]
        public virtual Doador Doador { get; set; }
        [Required]
        public virtual LocalDoacao LocalDoacao { get; set; }
        public virtual ICollection<Exame> Exames { get; set; }
    }
}
