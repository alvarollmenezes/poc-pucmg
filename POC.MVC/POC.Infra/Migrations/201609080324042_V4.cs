namespace POC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataHora = c.DateTime(nullable: false),
                        Doador_ID = c.Int(),
                        LocalDoacao_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doador", t => t.Doador_ID)
                .ForeignKey("dbo.LocalDoacao", t => t.LocalDoacao_ID)
                .Index(t => t.Doador_ID)
                .Index(t => t.LocalDoacao_ID);
            
            CreateTable(
                "dbo.Doador",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamento", "LocalDoacao_ID", "dbo.LocalDoacao");
            DropForeignKey("dbo.Agendamento", "Doador_ID", "dbo.Doador");
            DropIndex("dbo.Agendamento", new[] { "LocalDoacao_ID" });
            DropIndex("dbo.Agendamento", new[] { "Doador_ID" });
            DropTable("dbo.Doador");
            DropTable("dbo.Agendamento");
        }
    }
}
