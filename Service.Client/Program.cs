using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            var task = DoWork(client);
            Console.WriteLine("het uitvoeren is momenteel bezig");

            while (task.Status != TaskStatus.RanToCompletion)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
        }

        private static async Task DoWork(ServiceReference1.HelloClient client)
        {
            await client.SlowAsync(5);

            Console.WriteLine("First call ready");
            client.Slow(4);

            Console.WriteLine("Second call ready");
        }
    }
}
