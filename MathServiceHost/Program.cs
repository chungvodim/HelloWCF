using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MathServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost MathServiceHost = null;
            try
            {
                //Base Address for MathService
                Uri httpBaseAddress = new Uri("http://localhost:8090/MathService/Calculator");
                Uri tcpBaseAddress = new Uri("net.tcp://localhost:8081/MathService/Calculator");
                
                //Instantiate ServiceHost
                MathServiceHost = new ServiceHost(typeof(MathService.Calculator), httpBaseAddress);
 
                //Add Endpoint to Host
                MathServiceHost.AddServiceEndpoint(typeof(MathService.ICalculator), new WSHttpBinding(), "");            
 
                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                MathServiceHost.Description.Behaviors.Add(serviceBehavior);

                //Open
                MathServiceHost.Open();
                Console.WriteLine("Service is live now at : {0}", httpBaseAddress);
                Console.ReadKey();                
            }

            catch (Exception ex)
            {
                MathServiceHost = null;
                Console.WriteLine("There is an issue with MathService" + ex.Message);
            }
        }
    }
}
