using Data;
using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            try
            {
                RegisterStatus status = RegisterStatus.Failed;
                string ps = Encrypt.GetSHA256(password);

                using (var context = new SuperChess())
                {
                    Usuarios newUser = new Usuarios()
                    {
                        username = username,
                        password = ps,
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
            } catch (DbUpdateException e)
            {
                Console.WriteLine("Register.cs " + e);
                return RegisterStatus.Failed;
            }
        }
    }

    public enum RegisterStatus
    {
        Success = 0,
        Failed
    }
}
