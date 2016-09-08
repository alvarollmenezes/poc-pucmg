﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Infra.Models
{
    public class Municipio
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string SiglaEstado { get; set; }
    }
}
