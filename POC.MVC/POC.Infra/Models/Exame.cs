using System.ComponentModel.DataAnnotations;

namespace POC.Infra.Models
{
    public class Exame
    {
        public int ID { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public byte[] Arquivo { get; set; }
        [Required]
        public string FormatoArquivo { get; set; }

        [Required]
        public virtual Coleta Coleta { get; set; }
    }
}
