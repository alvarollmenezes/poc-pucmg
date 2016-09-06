namespace POC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        SiglaEstado = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.LocalDoacao", "IDMunicipio", c => c.Int(nullable: false));
            AddColumn("dbo.LocalDoacao", "Municipio_ID", c => c.Int());
            CreateIndex("dbo.LocalDoacao", "Municipio_ID");
            AddForeignKey("dbo.LocalDoacao", "Municipio_ID", "dbo.Municipio", "ID");
            DropColumn("dbo.LocalDoacao", "Latitude");
            DropColumn("dbo.LocalDoacao", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocalDoacao", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.LocalDoacao", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.LocalDoacao", "Municipio_ID", "dbo.Municipio");
            DropIndex("dbo.LocalDoacao", new[] { "Municipio_ID" });
            DropColumn("dbo.LocalDoacao", "Municipio_ID");
            DropColumn("dbo.LocalDoacao", "IDMunicipio");
            DropTable("dbo.Municipio");
        }
    }
}
