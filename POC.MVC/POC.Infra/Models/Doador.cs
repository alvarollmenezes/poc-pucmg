using System;
using System.ComponentModel.DataAnnotations;

namespace POC.Infra.Models
{
    //TODO: As informações do doador devem ser o mais completo possível
    public class Doador
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
