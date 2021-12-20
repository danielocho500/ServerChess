/******************************************************************/
/* Archivo: IRankingService.cs                                    */
/* Programador: Raul Arturo Peredo Estudillo                      */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  15/Nov/2021                               */
/* Descripción: Interfaz donde se definen metodos del servidor    */
/*               pora el servicio ranking                         */
/******************************************************************/

using Contracts.getStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ranking
{
    [ServiceContract(CallbackContract = typeof(IRankingClient))]
    interface IRankingService
    {
        [OperationContract(IsOneWay = true)]
        void GetRanking(int idUser);
    }
}
