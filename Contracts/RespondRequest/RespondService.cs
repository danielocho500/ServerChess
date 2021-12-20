/******************************************************************/
/* Archivo: IRespondService.cs                                    */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 23/oct/2021                                             */
/* Fecha modificación: 25/oct/2021                                */
/* Descripción: Aceptar o rechazar una solicitud de amistad       */
/******************************************************************/
using Contracts.friendsConnected;
using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RespondRequest
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class RespondService : IRespondService
    {
        public void ConfirmRequest(bool accept, int idUserSend, int idUserRecive)
        {
            ContactsHelper.ConfirmRequest(accept,idUserSend,idUserRecive);
            

            if(accept)
                FriendService.NewFriend(idUserSend, idUserRecive);

        }
        public void GetRequests(int idUser)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRespondClient>();
            Dictionary<int,string> users = ContactsHelper.GetRequest(idUser);
            try
            {
                connection.ReciveRequest(users);
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
