using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var servicehost = new ServiceHost(typeof(CalculatorLibService)))
            {
                // Create HTTP End Points
                ServiceEndpoint BasicHttpEndPoint1 = servicehost.AddServiceEndpoint(
                    typeof(ICalculatorLibService),
                    new BasicHttpBinding(),
                    "http://localhost:4444/CalculatorLibService"
                    );

                ServiceEndpoint BasicHttpEndPoint2 = servicehost.AddServiceEndpoint(
                    typeof(ICalculatorLibService),
                    new BasicHttpBinding(),
                    "http://localhost:5555/CalculatorLibService"
                    );

                //Create Net TCP End Points
                ServiceEndpoint NetTCPEndPoint = servicehost.AddServiceEndpoint(
                   typeof(ICalculatorLibService),
                   new NetTcpBinding(),
                   "net.tcp://localhost:6666/ICalculatorLibService"
                   );

                // Open service
                //servicehost.Open();

                Console.WriteLine("Your WCF Service is Running and Listening From Below End Points");
                Console.WriteLine("{0} /n {1}", BasicHttpEndPoint1.Address.ToString(), BasicHttpEndPoint2.Address.ToString());

                foreach (ServiceEndpoint endpoint in servicehost.Description.Endpoints)
                {
                    Console.WriteLine("Address ={0} /t Binding Name={1}",endpoint.Address.ToString(), endpoint.Binding.Name);
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to stop WCF service");
                Console.ReadKey();

                // Close Service
                //servicehost.Close();
                
            }
        }
    }
}
