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

namespace Contracts.login
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class LoginService : ILoginService
    {
        public void Login(string username, string password)
        {


            LoginStatus status = LoginAccount.loginAccount(username, password);
            var connection = OperationContext.Current.GetCallbackChannel<ILoginClient>();

            if (status == LoginStatus.Success)
            {
                int idUser = UserHelper.GetIdUser(username);
                //Aqui por ejemplo usa el globals para ver si alguien ya esta
                if (Globals.UsersConnected.Keys.Contains(idUser))
                {
                    connection.LoginStatus(false, "Account is already logged", -1);
                    return;
                }
                connection.LoginStatus(true, "Logged",idUser);
            }
            else if (status == LoginStatus.notExist)
                connection.LoginStatus(false, "the accound dosen't exist", -1);
            else
                connection.LoginStatus(false, "Error trying to log", -1);
        }
    }
}
