using POC.Aplicacao.Models.SUS;
using POC.Infra.Dados;
using System;
using System.Linq;

namespace POC.Aplicacao.WorkServices
{
    public class SUSWorkService
    {
        public ServicosRealizados ObterServicosRealizados(DateTime aPartirDe)
        {
            using (var ctx = new POCContext())
            {
                var coletas = ctx.Coletas
                                 .Where(c => c.DataHora > aPartirDe)
                                 .Select(c => new ServicosRealizados.Coleta
                                 {
                                     DataHora = c.DataHora,
                                     Doador = new ServicosRealizados.Doador
                                     {
                                         CPF = c.Doador.CPF,
                                         DataNascimento = c.Doador.DataNascimento,
                                         Nome = c.Doador.Nome
                                     },
                                     LocalDoacao = new ServicosRealizados.LocalDoacao
                                     {
                                         Nome = c.LocalDoacao.Nome,
                                         Municipio = new ServicosRealizados.Municipio
                                         {
                                             Nome = c.LocalDoacao.Municipio.Nome,
                                             SiglaEstado = c.LocalDoacao.Municipio.SiglaEstado
                                         }
                                     }
                                 })
                                 .ToList();

                var exames = ctx.Coletas
                                 .Where(c => c.DataHora > aPartirDe)
                                 .SelectMany(c => c.Exames)
                                 .Select(e => new ServicosRealizados.Exame
                                 {
                                     Descricao = e.Descricao
                                 })
                                 .ToList();

                return new ServicosRealizados
                {
                    Coletas = coletas,
                    Exames = exames
                };
            }
        }
    }
}
