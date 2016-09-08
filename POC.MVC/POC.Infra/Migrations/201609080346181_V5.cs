namespace POC.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agendamento", "Doador_ID", "dbo.Doador");
            DropForeignKey("dbo.Agendamento", "LocalDoacao_ID", "dbo.LocalDoacao");
            DropIndex("dbo.Agendamento", new[] { "Doador_ID" });
            DropIndex("dbo.Agendamento", new[] { "LocalDoacao_ID" });
            AlterColumn("dbo.Agendamento", "Doador_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Agendamento", "LocalDoacao_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Agendamento", "Doador_ID");
            CreateIndex("dbo.Agendamento", "LocalDoacao_ID");
            AddForeignKey("dbo.Agendamento", "Doador_ID", "dbo.Doador", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Agendamento", "LocalDoacao_ID", "dbo.LocalDoacao", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamento", "LocalDoacao_ID", "dbo.LocalDoacao");
            DropForeignKey("dbo.Agendamento", "Doador_ID", "dbo.Doador");
            DropIndex("dbo.Agendamento", new[] { "LocalDoacao_ID" });
            DropIndex("dbo.Agendamento", new[] { "Doador_ID" });
            AlterColumn("dbo.Agendamento", "LocalDoacao_ID", c => c.Int());
            AlterColumn("dbo.Agendamento", "Doador_ID", c => c.Int());
            CreateIndex("dbo.Agendamento", "LocalDoacao_ID");
            CreateIndex("dbo.Agendamento", "Doador_ID");
            AddForeignKey("dbo.Agendamento", "LocalDoacao_ID", "dbo.LocalDoacao", "ID");
            AddForeignKey("dbo.Agendamento", "Doador_ID", "dbo.Doador", "ID");
        }
    }
}
