/******************************************************************/
/* Archivo: RequestService.cs                                     */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 28/oct/2021                                */
/* Descripción: Realizar solicitudes de amistad con el uso de un  */
/*              username                                          */
/******************************************************************/
using Logica.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ContactRequest
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class RequestService : IRequestService
    {
        public void SendRequest(string username, int idUser)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRequestClient>();

            RequestStatus request = Request.send(username, idUser);

            if (request == RequestStatus.success)
                connection.SendRequestStatus(true, "request send");
            else if (request == RequestStatus.UserNotFound)
                connection.SendRequestStatus(false, "user missing");
            else if (request == RequestStatus.friendsAlready)
                connection.SendRequestStatus(false, "You are friends already");
            else if (request == RequestStatus.rejected)
                connection.SendRequestStatus(false, "You were Rejected before");
            else if (request == RequestStatus.AutoRequest)
                connection.SendRequestStatus(false, "You cannot send a friend request to yourself");
            else if (request == RequestStatus.Failed)
                connection.SendRequestStatus(false, "An error ocurred trying to send the request");


                
        }
    }
}
