using POC.Aplicacao.Models.Doacao;
using POC.Aplicacao.WorkServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POC.API.Controllers
{
    public class ColetaController : ApiController
    {
        // POST api/coleta
        public void Post(Coleta coleta)
        {
            var ws = new DoacaoWorkService();
            ws.RegistrarColeta(coleta);
        }
    }
}
