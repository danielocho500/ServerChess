using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.register
{
    public class Register
    {
        public Register()
        {

        }

        public RegisterStatus RegisterAccount(string username, string password, string email)
        {
            RegisterStatus status = RegisterStatus.Failed;

            using (var context = new ChessModel())
            {
                Usuario newUser = new Usuario()
                {
                    username = username,
                    password = password,
                    email = email,
                    codigo_cuenta = 99999
                };

                context.Usuarios.Add(newUser);
                int entries = context.SaveChanges();
                context.SaveChanges();



                if (entries > 0)
                {
                    status = RegisterStatus.Success;
                }
            }

            return status;
        }
    }

    public enum RegisterStatus
    {
        Success = 0,
        Failed
    }
}
