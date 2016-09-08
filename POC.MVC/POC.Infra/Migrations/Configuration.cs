namespace POC.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<POC.Infra.Dados.POCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(POC.Infra.Dados.POCContext context)
        {
            //context.Municipios.AddOrUpdate(
            //    p => p.ID,
            //    new Models.Municipio { Nome = "Vitória", SiglaEstado = "ES" },
            //    new Models.Municipio { Nome = "Serra", SiglaEstado = "ES" },
            //    new Models.Municipio { Nome = "Vila Velha", SiglaEstado = "ES" },
            //    new Models.Municipio { Nome = "Colatina", SiglaEstado = "ES" },
            //    new Models.Municipio { Nome = "Rio de Janeiro", SiglaEstado = "RJ" },
            //    new Models.Municipio { Nome = "Niterói", SiglaEstado = "RJ" },
            //    new Models.Municipio { Nome = "São Paulo", SiglaEstado = "SP" },
            //    new Models.Municipio { Nome = "Santos", SiglaEstado = "SP" },
            //    new Models.Municipio { Nome = "Belo Horizonte", SiglaEstado = "MG" },
            //    new Models.Municipio { Nome = "Uberlândia", SiglaEstado = "MG" },
            //    new Models.Municipio { Nome = "Varginha", SiglaEstado = "MG" }
            //    );

            //context.LocaisDoacao.AddOrUpdate(
            //    p => p.ID,
            //    new Models.LocalDoacao { Nome = "UniHemo", URLEndpointHorarios = "https://ablab.com.br/api/horariosDisponiveis", Municipio = new Models.Municipio { ID = 1 } },
            //    new Models.LocalDoacao { Nome = "HemoES", URLEndpointHorarios = "https://hemoes.br/horarios", Municipio = new Models.Municipio { ID = 1 } },
            //    new Models.LocalDoacao { Nome = "Hemocentro Regional de Colatina", URLEndpointHorarios = "https://hemocolatina.com.br/horarios", Municipio = new Models.Municipio { ID = 4 } }
            //    );

        }
    }
}
