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
        public static AccountExistStatus exist(string email, string username)
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
