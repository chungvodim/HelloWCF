using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorClient proxy = new CalculatorClient();
            Console.WriteLine("Client is running at " + DateTime.Now.ToString());
            Console.WriteLine("Sum of two numbers... 5+5 =" + proxy.Add(5, 5));
            Console.ReadLine();
        }
    }
}
