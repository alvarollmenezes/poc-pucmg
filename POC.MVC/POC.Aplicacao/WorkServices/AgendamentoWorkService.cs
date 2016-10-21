using POC.Aplicacao.Models.Agendamento;
using POC.Infra.Dados;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using POC.Infra.Models;

namespace POC.Aplicacao.WorkServices
{
    public class AgendamentoWorkService
    {
        public AgendamentoDoacao ObterTela()
        {
            Doador doador;
            using (var ctx = new POCContext())
            {
                //TODO: Deveria ser buscado do usuário autenticado
                doador = ctx.Doadores
                            .Where(d => d.ID == 1)
                            .Single();
            }

            return new AgendamentoDoacao
            {
                IDDoador = doador.ID,
                NomeDoador = doador.Nome,
                CPFDoador = doador.CPF,
                Estados = ObterEstados()
            };
        }

        public IList ObterEstados()
        {
            using (var context = new POCContext())
            {
                var estados = context.Municipios
                                     .Select(m => new
                                     {
                                         ID = m.SiglaEstado,
                                         Nome = m.SiglaEstado
                                     })
                                     .Distinct()
                                     .OrderBy(m => m)
                                     .ToList();

                return estados;
            }
        }

        public IList ObterMunicipiosPorEstado(string siglaEstado)
        {
            using (var context = new POCContext())
            {
                var municipios = context.Municipios
                                        .Where(m => m.SiglaEstado == siglaEstado)
                                        .OrderBy(m => m.Nome)
                                        .Select(m => new
                                        {
                                            ID = m.ID,
                                            Nome = m.Nome
                                        })
                                        .ToList();

                return municipios;
            }
        }

        public IList ObterLocais(int idMunicipio)
        {
            using (var context = new POCContext())
            {
                var locais = context.LocaisDoacao
                                    .Where(l => l.Municipio.ID == idMunicipio)
                                    .Select(l => new
                                    {
                                        ID = l.ID,
                                        Nome = l.Nome
                                    })
                                    .ToList();

                return locais;
            }
        }

        public List<DateTime> ObterDiasDisponiveis(int idLocalDoacao)
        {
            var now = DateTime.Now;
            //TODO: Deveria acessar o webservice do local de doação para buscar a lista de dias e horários disponíveis
            //Como não há webservices de verdade, faremos um mock com delay
            System.Threading.Thread.Sleep(1200);
            var horarios = new List<DateTime>();

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    horarios.Add(new DateTime(now.Year, now.Month, now.Day, j + 8, 0, 0).AddDays(1 + i));
                    horarios.Add(new DateTime(now.Year, now.Month, now.Day, j + 8, 30, 0).AddDays(1 + i));
                }
            }

            return horarios.OrderBy(h => h).ToList();
        }

        public List<DateTime> ObterHorariosDisponiveis(int idLocalDoacao, DateTime diaEscolhido)
        {
            var now = DateTime.Now;
            //TODO: Deveria acessar o webservice do local de doação para buscar a lista de dias e horários disponíveis
            //Como não há webservices de verdade, faremos um mock com delay
            System.Threading.Thread.Sleep(1200);
            var horarios = new List<DateTime>();

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    horarios.Add(new DateTime(now.Year, now.Month, now.Day, j + 8, 0, 0).AddDays(1 + i));
                    horarios.Add(new DateTime(now.Year, now.Month, now.Day, j + 8, 30, 0).AddDays(1 + i));
                }
            }

            return horarios.OrderBy(h => h).ToList();
        }

        public void RegistrarAgendamento(AgendamentoDoacao dados)
        {
            using (var ctx = new POCContext())
            {
                var agendamento = new Agendamento
                {
                    DataHora = dados.DataHora,
                    Doador = ctx.Doadores.Find(dados.IDDoador),
                    LocalDoacao = ctx.LocaisDoacao.Find(dados.IDLocalDoacao)
                };

                ctx.Agendamentos.Add(agendamento);
                ctx.SaveChanges();
            }
        }
    }
}
