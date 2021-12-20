/******************************************************************/
/* Archivo: GetStatsService.cs                                    */
/* Programador: Daniel Diaz Rossell                               */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  15/Nov/2021                               */
/* Descripción: Contratos para generacion consusltas de stats     */
/******************************************************************/

using Contracts.friendsConnected;
using Logica.helpers;
using Logica.stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.getStats
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class GetStatsService : IGetStatsService
    {
        public void GetStats(int id)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IGetStatsClient>();

            Stats stats = new Stats(id);
            int MatchesP = stats.getMatchesPlayed();
            int MatchesW = stats.getMatchesW();
            Decimal MatchesPer = stats.GetWinP();
            int Elo = stats.GetEloActual();
            int MaxElo = stats.GetEloMax();

            try
            {
                connection.ShowStats(MatchesP, MatchesW, MatchesPer, MaxElo, Elo);
            }
            catch (CommunicationObjectAbortedException)
            {
                if (Globals.UsersConnected.Keys.Contains(id))
                {
                    FriendService friendService = new FriendService();
                    friendService.Disconnected(id);
                }
            }
   
        }
    }
}
