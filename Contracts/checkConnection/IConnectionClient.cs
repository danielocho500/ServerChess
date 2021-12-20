/******************************************************************/
/* Archivo: IConnectionClient.cs                                  */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 23/oct/2021                                */
/* Descripción: Interfaz las definiciones de los metodos del      */
/*              cliente                                           */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Contracts.checkConnection
{
    [ServiceContract]
    interface IConnectionClient
    {
        [OperationContract(IsOneWay = true)]
        void IsConnected(bool status);
    }
}
