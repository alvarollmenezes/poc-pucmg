using POC.Aplicacao.Models.Agendamento;
using POC.Infra.Dados;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace POC.Aplicacao.WorkServices
{
    public class AgendamentoWorkService
    {
        public AgendamentoLocais ObterTela()
        {
            return new AgendamentoLocais
            {
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

        public List<DateTime> ObterHorariosDisponiveis(int idLocalDoacao)
        {
            var now = DateTime.Now;
            //TODO: Deveria acessar o webservice do local de doação para buscar a lista de horários disponíveis
            var horarios = new List<DateTime>();

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    horarios.Add(new DateTime(now.Year, now.Month, now.Day - 7 + i, new Random().Next(8, 16), 0, 0));
                }
            }

            return horarios.OrderBy(h => h).ToList();
        }
    }
}
