﻿using RealNorthwindClientTcp.ProductServiceRef;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RealNorthwindClientTcp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ProductServiceClient client = new ProductServiceClient();
                Product product = client.GetProduct(23);
                Console.WriteLine("product name is " + product.ProductName);
                Console.WriteLine("product price is " + product.UnitPrice.ToString());
                product.UnitPrice = 20.0m;
                string message = "";
                bool result = client.UpdateProduct(product, ref message);
                Console.WriteLine("Update result is " + result.ToString());
                Console.WriteLine("Update message is " + message);
                sw.Stop();
                Console.WriteLine("TCP Elapsed: " + sw.Elapsed);
            }
            catch (FaultException<ProductFault> ex)
            {
                Console.WriteLine("ProductFault. ");
                Console.WriteLine("\tFault reason:" + ex.Reason);
                Console.WriteLine("\tFault message:" + ex.Detail.FaultMessage);
            }
            catch (FaultException ex)
            {
                Console.WriteLine("Unknown Fault");
                Console.WriteLine(ex.Message);
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("Communication exception");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown exception");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
