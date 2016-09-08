namespace POC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coleta",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataHora = c.DateTime(nullable: false),
                        Doador_ID = c.Int(nullable: false),
                        LocalDoacao_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doador", t => t.Doador_ID, cascadeDelete: true)
                .ForeignKey("dbo.LocalDoacao", t => t.LocalDoacao_ID, cascadeDelete: true)
                .Index(t => t.Doador_ID)
                .Index(t => t.LocalDoacao_ID);
            
            CreateTable(
                "dbo.Exame",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Arquivo = c.Binary(nullable: false),
                        FormatoArquivo = c.String(nullable: false),
                        Coleta_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Coleta", t => t.Coleta_ID, cascadeDelete: true)
                .Index(t => t.Coleta_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coleta", "LocalDoacao_ID", "dbo.LocalDoacao");
            DropForeignKey("dbo.Exame", "Coleta_ID", "dbo.Coleta");
            DropForeignKey("dbo.Coleta", "Doador_ID", "dbo.Doador");
            DropIndex("dbo.Exame", new[] { "Coleta_ID" });
            DropIndex("dbo.Coleta", new[] { "LocalDoacao_ID" });
            DropIndex("dbo.Coleta", new[] { "Doador_ID" });
            DropTable("dbo.Exame");
            DropTable("dbo.Coleta");
        }
    }
}
