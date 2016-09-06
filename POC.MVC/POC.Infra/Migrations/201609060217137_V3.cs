namespace POC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LocalDoacao", "Municipio_ID", "dbo.Municipio");
            DropIndex("dbo.LocalDoacao", new[] { "Municipio_ID" });
            AlterColumn("dbo.LocalDoacao", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.LocalDoacao", "URLEndpointHorarios", c => c.String(nullable: false));
            AlterColumn("dbo.LocalDoacao", "Municipio_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.LocalDoacao", "Municipio_ID");
            AddForeignKey("dbo.LocalDoacao", "Municipio_ID", "dbo.Municipio", "ID", cascadeDelete: true);
            DropColumn("dbo.LocalDoacao", "IDMunicipio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocalDoacao", "IDMunicipio", c => c.Int(nullable: false));
            DropForeignKey("dbo.LocalDoacao", "Municipio_ID", "dbo.Municipio");
            DropIndex("dbo.LocalDoacao", new[] { "Municipio_ID" });
            AlterColumn("dbo.LocalDoacao", "Municipio_ID", c => c.Int());
            AlterColumn("dbo.LocalDoacao", "URLEndpointHorarios", c => c.String());
            AlterColumn("dbo.LocalDoacao", "Nome", c => c.String());
            CreateIndex("dbo.LocalDoacao", "Municipio_ID");
            AddForeignKey("dbo.LocalDoacao", "Municipio_ID", "dbo.Municipio", "ID");
        }
    }
}
