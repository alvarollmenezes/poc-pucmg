using POC.Aplicacao.Models.SUS;
using System;
using System.ServiceModel;

namespace POC.WCF
{
    [ServiceContract]
    public interface ISUS
    {
        [OperationContract]
        ServicosRealizados GetServicosRealizados(DateTime aPartirDe);
    }
}
