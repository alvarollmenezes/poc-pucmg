using System;
using System.Collections.Generic;

namespace POC.Aplicacao.Models.SUS
{
    public class ServicosRealizados
    {
        public List<Coleta> Coletas { get; set; }
        public List<Exame> Exames { get; set; }

        public class Coleta
        {
            public DateTime DataHora { get; set; }
            public virtual Doador Doador { get; set; }
            public virtual LocalDoacao LocalDoacao { get; set; }
        }

        public class Doador
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
            public DateTime DataNascimento { get; set; }
        }

        public class LocalDoacao
        {
            public string Nome { get; set; }
            public virtual Municipio Municipio { get; set; }
        }

        public class Municipio
        {
            public string Nome { get; set; }
            public string SiglaEstado { get; set; }
        }

        public class Exame
        {
            public string Descricao { get; set; }
        }
    }
}
