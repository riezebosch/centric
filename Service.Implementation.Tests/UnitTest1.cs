using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using Service.Implementation;
using Service.ServiceContract;
using Service.DataContract;
using System.Diagnostics;

namespace Service.Implementation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        ServiceHost host;
        IHello client;

        [TestInitialize]
        public void InitializeHostAndClient()
        {
            host = new ServiceHost(typeof(HelloService));

            host.AddServiceEndpoint(typeof(IHello),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/hello");
            host.Open();

            client = ChannelFactory<IHello>.CreateChannel(new NetNamedPipeBinding(),
                new EndpointAddress("net.pipe://localhost/hello"));
        }

        [TestCleanup]
        public void CleanUpClientAndHost()
        {
            if (((ICommunicationObject)client).State != CommunicationState.Faulted)
            {
                ((IDisposable)client).Dispose();
            }
            else
            {
                ((ICommunicationObject)client).Abort();
            }

            host.Close();
        }

        [TestMethod]
        public void TestServiceMethodGoodMorning()
        {
            client.GoodMorning();
        }

        [TestMethod]
        public void WanneerMijnServiceEenExceptionGooitMoetMijnClientDaaropKunnenAnticiperen()
        {
            try
            {
                client.ThisMorningIsNotSoGoodHereIsYourException();
                Assert.Fail("dit punt had niet bereikt mogen worden aangezien op de regel hierboven een exception op had moeten treden.");
            }
            catch (FaultException<Verbose> ex)
            {
                Assert.AreEqual("voorbeeld van een mooie foutmelding", ex.Detail.FoutOmschrijving);
            }
        }

        [TestMethod]
        public void DeMeesteServiceMethodsAccepterenInputOfGevenOutputTerug()
        {
            Antwoord result = client.Send(new Boodschap { Tekst = "Hello World!" });
            Assert.AreEqual("Hello to U2", result.Tekst);
        }

        [TestMethod]
        public void AlleenDeVeldenDieIkZelfSelecteerMoetenMeeWordenGestuurd()
        {
            Antwoord result = client.Send(new Boodschap 
            { 
                Tekst = "Hello World!",
                DezeIsLokaal = "NIET MEESTUREN AUB"
            });

            Assert.AreEqual("Hello to U2", result.Tekst);
            Assert.AreEqual(null, result.DezeIsOokLokaal);
        }

        [TestMethod]
        public void DemoVanAsynchroonProgrammeren()
        {
            // Om te meten
            var sw = Stopwatch.StartNew();

            var x = ClientSlow();

            // Hoeveel seconden heeft dat geduurd
            var elapsed = sw.Elapsed.TotalSeconds;

            // In elk geval meer dan 0
            // en ook meer dan x
            Assert.AreNotEqual(0, elapsed);
            Assert.IsTrue(elapsed >= x);
        }

        private int ClientSlow()
        {
            // Random getal tussen 1 en 10
            var random = new Random();
            var x = random.Next(1, 10);

            client.Slow(x);
            return x;
        }

        [TestMethod]
        public void DemoVanAsynchroonProgrammeren2()
        {
            // Om te meten
            var sw = Stopwatch.StartNew();

            var x1 = ClientSlow();
            var x2 = ClientSlow();

            // Hoeveel seconden heeft dat geduurd
            var elapsed = sw.Elapsed.TotalSeconds;

            Assert.IsTrue(elapsed <= x1 + x2, "elapsed zou kleiner moeten zijn dan de som van beide aanroepen.");
            Assert.IsTrue(elapsed > x1, "elapsed is niet groter dan x1");
            Assert.IsTrue(elapsed > x2, "elapsed is niet groter dan x2");
        }
    }
}
