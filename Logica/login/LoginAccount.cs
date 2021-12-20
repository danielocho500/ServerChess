using Data;
using Logica.helpers;
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

            string ps = Encrypt.GetSHA256(password);

            using (var context = new SuperChess())
            {
                var AccountExist = from Usuario in context.Usuarios
                                   where Usuario.username == username && Usuario.password == ps
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
