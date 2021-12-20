/******************************************************************/
/* Archivo: ChessService.cs                                       */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 17/oct/2021                                             */
/* Fecha modificación: 19/oct/2021                                */
/* Descripción: Arrancar el host                                  */
/******************************************************************/
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
        static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(ChessService));
            host.Open();
            Console.WriteLine("Server running, put enter to close it");
            Console.ReadLine();
            host.Close();
        }
    }
}

