using Service.DataContract;
using Service.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            throw new FaultException<Verbose>(new Verbose
                {
                    FoutOmschrijving = "voorbeeld van een mooie foutmelding"
                });
        }


        public Antwoord Send(Boodschap boodschap)
        {
            if (boodschap.DezeIsLokaal != null)
            {
                throw new ArgumentException("De lokale parameter bevatte stiekem toch een waarde!!!", "boodschap");
            }
            return new Antwoord 
            { 
                Tekst = "Hello to U2" ,
                DezeIsOokLokaal = "DEZE HAD NIET MEEGESTUURD MOGEN WORDEN!!!"
            };
        }

        public void Slow(int x)
        {
            // Even wachten
            Thread.Sleep(x * 1000);
            //await Task.Delay(x * 1000);
        }
    }
}
