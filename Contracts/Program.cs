using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ChessService));
            host.Open();
            /* Para pruebas
            ChessService chess = new ChessService();
            */
            Console.WriteLine("Server running, put enter to close it");
            Console.ReadLine();
            host.Close();
        }
    }
}

