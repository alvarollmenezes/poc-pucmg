using POC.Infra.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace POC.Infra.Dados
{
    public  class POCContext : DbContext
    {
        public POCContext() : base("POCContext")
        {
        }

        public DbSet<LocalDoacao> LocaisDoacao { get; set; }
        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
