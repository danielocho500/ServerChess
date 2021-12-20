/******************************************************************/
/* Archivo: IRankingClient.cs                                       */
/* Programador: Raul Arturo Peredo Estudillo                      */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  15/Nov/2021                               */
/* Descripción: Interfaz donde se definen metodos del servidor    */
/*               pora el servicio ranking                         */
/******************************************************************/

using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ranking
{
    [ServiceContract]
    interface IRankingClient
    {
        [OperationContract(IsOneWay = true)]
        void ShowRanking(List<Tuple<string, int>> rank);
    }
}

