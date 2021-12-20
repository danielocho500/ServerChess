using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logica.stats
{
    public class Stats
    {
        private int id;
        private int Matches_played;
        private int Matches_win;
        private Decimal WinP;
        private int eloMax;
        private int eloActual;
        private bool userExist;
        public Stats(int id_)
        {
            id = id_;
            userExist = false;

            try
            {
                using (var context = new SuperChess())
                {
                    var user = from User in context.Users
                               where User.id_user == id
                               select User;

                    if (user.Count() > 0)
                        userExist = true;

                    if (userExist)
                    {
                        var stats = from Stat in context.Stats_Player
                                    where Stat.id_user == id
                                    select Stat;

                        var stat = stats.First();

                        Matches_played = stat.total_played;
                        Matches_win = stat.total_win;
                        eloMax = stat.elo_max;
                        eloActual = stat.elo_actual;
                    }
                    else
                    {
                        Matches_played = -1;
                        WinP = -1;
                        eloMax = -1;
                        eloActual = -1;
                    }
                }
            }
            catch (EntitySqlException e)
            {
                Console.WriteLine("Error in Stats.cs ", e);
            }

        }
        public int getMatchesPlayed()
        {
            return Matches_played;
        }

        public int getMatchesW()
        {
            return Matches_win;
        }

        public Decimal GetWinP()
        {
            try
            {
                return ((Matches_win*100)/Matches_played);
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
            
        }
        public int GetEloMax()
        {
            return eloMax;
        
        }
        public int GetEloActual()
        {
            return eloActual;
        }

        public int win(bool youWon)
        {
            eloActual = 0;

            using(var context = new SuperChess()){
                var newStats = from stats in context.Stats_Player
                               where stats.id_user == id
                               select stats;
                newStats.First().total_played += 1;
                if (youWon)
                {
                    newStats.First().total_win += 1;
                    newStats.First().elo_actual += 15;
                }
                else
                {
                    newStats.First().elo_actual -= 10;
                }

                eloActual = newStats.First().elo_actual;

                if (eloActual > newStats.First().elo_max)
                    newStats.First().elo_max = eloActual;

                context.SaveChanges();
            }

            return eloActual;
        }
    }

}
