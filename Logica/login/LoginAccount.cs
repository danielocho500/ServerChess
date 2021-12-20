using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.login
{
    public class LoginAccount
    {
        public LoginAccount()
        {
 
        }

        public static LoginStatus loginAccount(string username, string password)
        {
            LoginStatus status = LoginStatus.failed;

            using (var context = new ChessModel())
            {
                var AccountExist = from Usuario in context.Usuarios
                                   where Usuario.username == username && Usuario.password == password
                                   select Usuario;

                if (AccountExist.Count() > 0)
                    status = LoginStatus.Success;
                else
                    status = LoginStatus.notExist;
            }

            return status;
        }
    }

    public enum LoginStatus
    {
        Success = 0,
        failed,
        notExist
    }
}
