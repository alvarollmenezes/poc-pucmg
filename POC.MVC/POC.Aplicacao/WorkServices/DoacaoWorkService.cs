using POC.Infra.Dados;
using POC.Infra.Models;
using System;

namespace POC.Aplicacao.WorkServices
{
    public class DoacaoWorkService
    {
        public void RegistrarColeta(Models.Doacao.Coleta coleta)
        {
            using (var ctx = new POCContext())
            {
                var coletaDB = new Coleta
                {
                    Doador = ctx.Doadores.Find(coleta.IDDoador),
                    DataHora = coleta.DataHora,
                    LocalDoacao = ctx.LocaisDoacao.Find(coleta.IDLocalDoacao)
                };

                if (coleta.Exames != null)
                {
                    foreach (var exame in coleta.Exames)
                    {
                        var e = new Exame
                        {
                            Arquivo = Convert.FromBase64String(exame.Arquivo),
                            Descricao = "Exame",
                            FormatoArquivo = "pdf"
                        };

                        coletaDB.Exames.Add(e);
                    }
                }

                ctx.Coletas.Add(coletaDB);
                ctx.SaveChanges();
            }
        }
    }
}
