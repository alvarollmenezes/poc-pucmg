using POC.Infra.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Migrations;

namespace POC.Infra.Dados
{
    public  class POCContext : DbContext
    {
        public POCContext() : base("POCContext")
        {
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<LocalDoacao> LocaisDoacao { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
