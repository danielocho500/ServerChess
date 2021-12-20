/******************************************************************/
/* Archivo: IRespondService.cs                                    */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 25/oct/2021                                */
/* Descripción: Definición de metodos del servidor para responder */
/*              responder a invitaciones                          */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RespondRequest
{
    [ServiceContract(CallbackContract = typeof(IRespondClient))]
    interface IRespondService
    {
        [OperationContract(IsOneWay = true)]
        void GetRequests(int idUser);
        [OperationContract(IsOneWay = true)]
        void ConfirmRequest(bool accept, int idUserSend, int idUserRecive);
    }
}
