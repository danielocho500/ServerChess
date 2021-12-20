/******************************************************************/
/* Archivo: ILoginClient.cs                                       */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 18/oct/2021                                             */
/* Fecha modificación: 30/oct/2021                                */
/* Descripción: Interfaz donde se definen metodos del cliente para*/
/*               el servicio de login                             */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.login
{
    [ServiceContract]
    interface ILoginClient
    {
        [OperationContract(IsOneWay = true)]
        void LoginStatus(int status, int idUser);
    }
}
