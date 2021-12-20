using Data;
using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ranking
{
    public class RankingUser
    {
        public List<Tuple<string,int>> GetWin()
        {
            List<Tuple<string, int>> listWin = new List<Tuple<string, int>>();
            try
            {
                using(var context = new SuperChess())
                {
                    var players = (from stats in context.Stats_Player
                                   select new
                                   {
                                       id_user = stats.id_user,
                                       elo =  stats.elo_actual
                                   }
                                   ).OrderByDescending(x => x.elo).ThenBy(x => x.id_user).ToList();

                    if(players.Count > 0)
                    {
                        foreach (var player in players)
                        {
                            string name = UserHelper.GetUsername(player.id_user);
                            listWin.Add(new Tuple<string, int>(name,player.elo));
                        }
                    }

                    return listWin;
                }
            } catch(EntitySqlException e)
            {
                Console.WriteLine("Error in RankingUser.cs ",e);
                return null;
            }
        }
    }
}
