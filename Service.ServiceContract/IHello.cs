using Service.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Service.ServiceContract
{
    [ServiceContract]
    public interface IHello
    {
        [OperationContract]
        void GoodMorning();

        [OperationContract]
        [FaultContract(typeof(Verbose))]
        void ThisMorningIsNotSoGoodHereIsYourException();
    }
}
