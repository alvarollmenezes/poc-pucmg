using POC.Aplicacao.Models.SUS;
using POC.Aplicacao.WorkServices;
using System;

namespace POC.WCF
{
    public class SUS : ISUS
    {
        public ServicosRealizados GetServicosRealizados(DateTime aPartirDe)
        {
            var ws = new SUSWorkService();

            return ws.ObterServicosRealizados(aPartirDe);
        }
    }
}
