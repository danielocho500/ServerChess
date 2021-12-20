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

            int status = LoginAccount.loginAccount(username, password);

            var connection = OperationContext.Current.GetCallbackChannel<ILoginClient>();
            
            if(status == 0)
            {
                int idUser = UserHelper.GetIdUser(username);
                connection.LoginStatus(status, idUser);
            }
            else
            {
                connection.LoginStatus(status, -1);
            }
        }
    }
}
