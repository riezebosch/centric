using Service.DataContract;
using Service.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Service.Implementation
{
    public class HelloService : IHello
    {
        public void GoodMorning()
        {
            //throw new NotImplementedException();
        }


        public void ThisMorningIsNotSoGoodHereIsYourException()
        {
            throw new FaultException<Verbose>(new Verbose());
        }
    }
}
