/******************************************************************/
/* Archivo: UserHelper.cs                                         */
/* Programador: Raul Arturo Peredo Estudillo                      */
/* Fecha: 20/Oct/2021                                             */
/* Fecha modificación:  10/Dic/2021                               */
/* Descripción: Metodos para codigo de usuarios                   */
/******************************************************************/

using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.helpers
{
    public class UserHelper
    {
        public static bool Exist(string user)
        {
            try
            {
                bool status = false;

                using (var context = new SuperChess())
                {
                    var userExist = from User in context.Users
                                    where User.username == user
                                    select User;

                    if (userExist.Count() > 0)
                        status = true;
                }

                return status;
            }catch(EntitySqlException e)
            {
                Console.WriteLine("UserHelper.cs " + e);
                return false;
            }
        }

        public static int GetIdUser(string username)
        {
            int id = 0;
            try
            {
                using (var context = new SuperChess())
                {
                    var user = from User in context.Users
                               where User.username == username
                               select User.id_user;

                    if (user.Count() > 0)
                        id = user.First();
                    else
                        id = -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ContactsHelper.cs " + e.Message);
            }
            return id;
        }

        public static string GetUsername(int id)
        {
            string username = "";

            using (var context = new SuperChess())
            {
                var name = from User in context.Users
                           where User.id_user == id
                           select User;

                if (name.Count() > 0)
                    username = name.First().username;
            }

            return username;
        }

    }
}
