using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.HelloClient();
            client.GoodMorning();

            var result = client.Send(new ServiceReference1.Boodschap { Tekst = "Hello from the console" });
            Console.WriteLine(result.Tekst);

            DoWork(client);
            Console.WriteLine("het uitvoeren is momenteel bezig");

            Console.ReadKey();
        }

        private static void DoWork(ServiceReference1.HelloClient client)
        {
            var t1 = client.SlowAsync(5).ContinueWith(t => Console.WriteLine("First call ready"));
            var t2 = client.SlowAsync(4).ContinueWith(t => Console.WriteLine("Second call ready"));

            Task.WhenAll(t1, t2).ContinueWith(t => Console.WriteLine("beide tasks zijn klaar"));
        }
    }
}
