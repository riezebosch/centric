using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using Service.Implementation;
using Service.ServiceContract;

namespace Service.Implementation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var host = new ServiceHost(typeof(HelloService)))
            {
                host.AddServiceEndpoint(typeof(IHello),
                    new NetNamedPipeBinding(),
                    "net.pipe://localhost/hello");
                host.Open();

                var client = ChannelFactory<IHello>.CreateChannel(new NetNamedPipeBinding(),
                    new EndpointAddress("net.pipe://localhost/hello"));

                client.GoodMorning(); 
            }
        }

        [TestMethod]
        public void TestMethodZonderUsing()
        {
            var host = new ServiceHost(typeof(HelloService));

            try
            {
                host.AddServiceEndpoint(typeof(IHello),
                    new NetNamedPipeBinding(),
                    "net.pipe://localhost/hello");
                host.Open();

                var client = ChannelFactory<IHello>.CreateChannel(new NetNamedPipeBinding(),
                    new EndpointAddress("net.pipe://localhost/hello"));

                try
                {
                    client.GoodMorning();
                }
                finally
                {
                    ((IDisposable)client).Dispose();
                }
            }
            finally
            {
                ((IDisposable)host).Dispose();
            }
        }
    }
}
