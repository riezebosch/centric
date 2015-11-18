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
        }
    }
}
