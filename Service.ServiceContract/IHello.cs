using Service.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Service.ServiceContract
{
    [ServiceContract(Namespace = "urn:www-infosupport-com:wcfdev:demo-service")]
    public interface IHello
    {
        [OperationContract]
        void GoodMorning();

        [OperationContract]
        [FaultContract(typeof(Verbose))]
        void ThisMorningIsNotSoGoodHereIsYourException();

        [OperationContract]
        Antwoord Send(Boodschap boodschap);
    }
}
