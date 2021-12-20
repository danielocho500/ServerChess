/******************************************************************/
/* Archivo: ILoginService.cs                                      */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 18/oct/2021                                             */
/* Fecha modificación: 30/oct/2021                                */
/* Descripción: Interfaz donde se definen metodos del servidor    */
/*               pora el servicio de login                        */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.login
{
    [ServiceContract(CallbackContract = typeof(ILoginClient))]
    interface ILoginService
    {
        [OperationContract(IsOneWay = true)]
        void Login(string username, string password);
    }
}
