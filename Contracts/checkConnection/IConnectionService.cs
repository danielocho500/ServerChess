/******************************************************************/
/* Archivo: IConnectionService.cs                                 */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 23/oct/2021                                */
/* Descripción: Interfaz las definiciones de los metodos del      */
/*              servidor                                          */
/******************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contracts.checkConnection
{
    [ServiceContract(CallbackContract = typeof(IConnectionClient))]
    interface IConnectionService
    {
        [OperationContract(IsOneWay = true)]
        void Check();
    }
}
