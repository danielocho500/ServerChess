/******************************************************************/
/* Archivo: IRegisterClient.cs                                    */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 18/oct/2021                                             */
/* Fecha modificación: 22/oct/2021                                */
/* Descripción: Interfaz donde se definen metodos callback del    */
/*               del cliente para el servicio de login            */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.register
{
    [ServiceContract]
    interface IRegisterClient
    {
        [OperationContract(IsOneWay = true)]
        void ValidateCode(bool codeStatus, int message);
    }
}
