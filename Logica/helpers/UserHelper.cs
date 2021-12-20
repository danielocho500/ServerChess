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
                    var userExist = from Usuario in context.Usuarios
                                    where Usuario.username == user
                                    select Usuario;

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

        public static int getIdUser(string username)
        {
            int id = 0;

            using (var context = new SuperChess())
            {
                var user = from Usuario in context.Usuarios
                         where Usuario.username == username
                         select Usuario.id_usuarios;

                if (user.Count() > 0)
                    id = user.First();
                else
                    id = -1;
            }

            return id;

        }

        public static string getUsername(int id)
        {
            string username = "";

            using (var context = new SuperChess())
            {
                var name = from Usuario in context.Usuarios
                           where Usuario.id_usuarios == id
                           select Usuario;

                if (name.Count() > 0)
                    username = name.First().username;
            }

            return username;
        }

    }
}
