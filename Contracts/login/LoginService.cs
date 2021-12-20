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
                int idUser = UserHelper.getIdUser(username);
                connection.LoginStatus(true, "Logged",idUser);
            }
            else if (status == LoginStatus.notExist)
                connection.LoginStatus(false, "the accound dosen't exist", -1);
            else
                connection.LoginStatus(false, "Error trying to log", -1);
        }
    }
}
