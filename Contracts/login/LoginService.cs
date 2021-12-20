/******************************************************************/
/* Archivo: LoginService.cs                                       */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 18/oct/2021                                             */
/* Fecha modificación: 30/oct/2021                                */
/* Descripción: Hacer el logueo de un usuario                     */
/******************************************************************/
using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Logica.login;
using Contracts.friendsConnected;

namespace Contracts.login
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class LoginService : ILoginService
    {
        public void Login(string username, string password)
        {

            int status = LoginAccount.Login(username, password);

            var connection = OperationContext.Current.GetCallbackChannel<ILoginClient>();

            int idUser = UserHelper.GetIdUser(username);

            try
            {
                if (FriendService.StillConnected(idUser))
                {
                    connection.LoginStatus(3, -1);
                    return;
                }


                if (status == 0)
                {
                    connection.LoginStatus(status, idUser);
                }
                else
                {
                    connection.LoginStatus(status, -1);
                }
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
