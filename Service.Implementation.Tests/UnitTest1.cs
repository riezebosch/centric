using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using Service.Implementation;
using Service.ServiceContract;
using Service.DataContract;

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
            }
            catch (FaultException<Verbose>)
            {
            }
        }
    }
}
