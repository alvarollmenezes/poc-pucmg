using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POC.Infra.Models
{
    public class LocalDoacao
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string URLEndpointHorarios { get; set; }

        [Required]
        public virtual Municipio Municipio { get; set; }
    }
}
