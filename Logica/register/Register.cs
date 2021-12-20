﻿using Data;
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
                    User newUser = new User()
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
