/******************************************************************/
/* Archivo: IGetStatsService.cs                                   */
/* Programador: Daniel Diaz Rossell                               */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  15/Nov/2021                               */
/* Descripción: Contratos para generacion consusltas de stats     */
/******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.getStats
{
    [ServiceContract(CallbackContract = typeof(IGetStatsClient))]

    interface IGetStatsService
    {
        [OperationContract(IsOneWay = true)]
        void GetStats(int id);
    }
}
