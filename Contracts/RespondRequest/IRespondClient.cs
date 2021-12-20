/******************************************************************/
/* Archivo: IRespondClient.cs                                     */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 25/oct/2021                                */
/* Descripción: Definición de metodos callback al cliente para    */
/*              responder a invitaciones                          */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RespondRequest
{
    [ServiceContract]
    interface IRespondClient
    {
        [OperationContract(IsOneWay = true)]
        void ReciveRequest(Dictionary<int,string> users);


    }
}
