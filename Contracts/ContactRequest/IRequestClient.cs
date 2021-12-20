/******************************************************************/
/* Archivo: IRequestClient.cs                                     */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 28/oct/2021                                */
/* Descripción: Interfaz para las definiciones de los metodos     */
/*              del cliente para hacer inivtaciones               */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ContactRequest
{
    [ServiceContract]
    interface IRequestClient
    {
        [OperationContract(IsOneWay = true)]
        void SendRequestStatus(bool status,string msg);
    }
}
