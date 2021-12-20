using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.helpers
{
    class UserHelper
    {
        public static bool Exist(string user)
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
    }
}
