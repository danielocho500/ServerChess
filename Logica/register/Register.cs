/******************************************************************/
/* Archivo: Register.cs                                           */
/* Programador: Raul Peredo                                       */
/* Fecha: 18/Oct/2021                                             */
/* Fecha modificación:  22/Oct/2021                               */
/* Descripción: Logica para Register                              */
/******************************************************************/

using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logica.register
{
    public class Register
    {
        public Register()
        {

        }

        public int RegisterAccount(string username, string password, string email)
        {
            try
            {
                int status = 1;
                string ps = Encrypt.GetSHA256(password);

                using (var context = new SuperChess())
                {
                    Users newUser = new Users()
                    {
                        username = username,
                        password = ps,
                        email = email,
                    };

                    context.Users.Add(newUser);

                    context.SaveChanges();

                    Stats_Player stats_Player = new Stats_Player()
                    {
                        total_win = 0,
                        total_played = 0,
                        elo_actual = 0,
                        elo_max = 0,
                        id_user = newUser.id_user
                    };

                    context.Stats_Player.Add(stats_Player);

                    int entries = context.SaveChanges();
                    



                    if (entries > 0)
                    {
                        status = 0;
                    }
                }

                return status;
            } catch (DbUpdateException e)
            {
                Console.WriteLine("Register.cs " + e);
                return 1;
            }
        }
    }

    public enum RegisterStatus
    {
        Success = 0,
        Failed = 1
    }
}
