/******************************************************************/
/* Archivo: RequestService.cs                                     */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 28/oct/2021                                */
/* Descripción: Realizar solicitudes de amistad con el uso de un  */
/*              username                                          */
/******************************************************************/
using Contracts.friendsConnected;
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
            int request = Request.Send(username, idUser);     
            try
            {
                connection.SendRequestStatus(request);
            }
            catch (CommunicationObjectAbortedException)
            {
                if (Globals.UsersConnected.Keys.Contains(idUser))
                {
                    FriendService friendService = new FriendService();
                    friendService.Disconnected(idUser);
                }
            }
        }
    }
}
