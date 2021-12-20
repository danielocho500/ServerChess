/******************************************************************/
/* Archivo: ValidateAccount.cs                                    */
/* Programador: Raul Arturo Peredo Estudillo                      */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  25/Nov/2021                               */
/* Descripción: Valida cuenta                                     */
/******************************************************************/

using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.AccountExist
{
    public class AccountExist
    {
        public static int Exist(string email, string username)
        {
            if(email.Trim() == "" || username.Trim() == "")
            {
                return 1;
            }

            try
            {
                using (var context = new SuperChess())
                {
                    var emailExist = from User in context.Users
                                     where User.email == email
                                     select User;

                    var userExist = from User in context.Users
                                    where User.username == username
                                    select User;

                    if (emailExist.Count() > 0)
                    {
                        return 2;
                    }
                    else if (userExist.Count() > 0)
                    {
                        return 3;
                    }
                    else
                    {
                        return 0;
                    }
                }
            } catch (Exception e)
            {
                Console.WriteLine("ValidateAccount.cs line 41 "+e.Message);
                return 1;
            }
            
        }

        public enum AccountExistStatus
        {
            success = 0,
            fail = 1,
            emailExist = 2,
            userExist = 3
        }
    }
}
