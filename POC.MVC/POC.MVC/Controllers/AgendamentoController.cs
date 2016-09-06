using POC.Aplicacao.Models.Agendamento;
using POC.Aplicacao.WorkServices;
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
        public ActionResult Horarios(int idLocalDoacao)
        {
            var ws = new AgendamentoWorkService();

            return View(ws.ObterHorariosDisponiveis(idLocalDoacao));
        }

        [HttpPost]
        public ActionResult Horarios(AgendamentoHorarios dados)
        {
            return null;
        }
    }
}
