namespace POC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Municipio", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Municipio", "SiglaEstado", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Municipio", "SiglaEstado", c => c.String());
            AlterColumn("dbo.Municipio", "Nome", c => c.String());
        }
    }
}
