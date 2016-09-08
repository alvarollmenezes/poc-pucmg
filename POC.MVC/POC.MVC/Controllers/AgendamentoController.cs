using POC.Aplicacao.Models.Agendamento;
using POC.Aplicacao.WorkServices;
using System;
using System.Linq;
using System.Web.Mvc;

namespace POC.MVC.Controllers
{
    public class AgendamentoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ws = new AgendamentoWorkService();

            return View(ws.ObterTela());
        }

        [HttpGet]
        public ActionResult Sucesso()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObterMunicipios(string siglaEstado)
        {
            var ws = new AgendamentoWorkService();

            return Json(ws.ObterMunicipiosPorEstado(siglaEstado), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ObterLocaisDoacao(int idMunicipio)
        {
            var ws = new AgendamentoWorkService();

            return Json(ws.ObterLocais(idMunicipio), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ObterDias(int idLocalDoacao)
        {
            var ws = new AgendamentoWorkService();
            var dias = ws.ObterDiasDisponiveis(idLocalDoacao)
                         .Select(h => h.Date)
                         .Distinct()
                         .OrderBy(h => h)
                         .Select(h => new
                         {
                             Valor = h.ToString("yyyy-MM-dd"),
                             Data = h.ToString("dd/MM/yyyy")
                         });

            return Json(dias, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ObterHorarios(DateTime diaEscolhido)
        {
            var ws = new AgendamentoWorkService();
            var horarios = ws.ObterHorariosDisponiveis(0, diaEscolhido)
                         .Where(h => h.Date == diaEscolhido)
                         .Distinct()
                         .OrderBy(h => h)
                         .Select(h => new
                         {
                             Valor = h.ToString("yyyy-MM-ddTHH:mm"),
                             Hora = h.ToString("HH:mm")
                         });

            return Json(horarios, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(AgendamentoDoacao dados)
        {
            var ws = new AgendamentoWorkService();

            if (!ModelState.IsValid)
            {
                return View(ws.ObterTela());
            }

            ws.RegistrarAgendamento(dados);

            return RedirectToAction("Sucesso");
        }
    }
}
