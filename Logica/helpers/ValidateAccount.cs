using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logica.Email
{
    public class Email
    {
        public static AccountExistStatus exist(string email, string username)
        {
            using (var context = new ChessModel())
            {
                var emailExist = from Usuario in context.Usuarios
                                 where Usuario.email == email 
                                 select Usuario;

                var userExist = from Usuario in context.Usuarios
                                where Usuario.username == username
                                select Usuario;

                if (emailExist.Count() > 0)
                {
                    return AccountExistStatus.emailExist;
                }
                else if (userExist.Count() > 0)
                {
                    return AccountExistStatus.userExist;
                }
                else
                {
                    return AccountExistStatus.success;
                }
            }
        }

        public enum AccountExistStatus
        {
            success,
            emailExist,
            userExist
        }
    }
}
