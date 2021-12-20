/******************************************************************/
/* Archivo: LoginAccount.cs                                       */
/* Programador: Raul Arturo Peredo Estudillo                      */
/* Fecha: 15/oct/2021                                             */
/* Fecha modificación: 12/nov/2021                                */
/* Descripción: Logica para iniciar sesión                        */
/******************************************************************/

using Data;
using Logica.helpers;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.login
{
    public class LoginAccount
    {
        protected LoginAccount()
        {
        }

        public static int Login(string username, string password)
        {
            LoginStatus status = LoginStatus.failed;

            string ps = Encrypt.GetSHA256(password);

            //empty fields
            if (username.Trim() == "" || password.Trim() == "")
                return 3;

            try {
                using (var context = new SuperChess())
                {
                    var AccountExist = from User in context.Users
                                       where User.username == username && User.password == ps
                                       select User;

                    if (AccountExist.Count() > 0)
                        status = LoginStatus.Success;
                    else
                        status = LoginStatus.notExist;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("LoginAccount.cs " + e.Message);
                return 1;
            }

            if (status == LoginStatus.Success)
                return 0;
            else
                return 2;    
        }
    }

    public enum LoginStatus
    {
        Success = 0,
        failed = 1,
        notExist = 2,
        empty = 3
    }
}
