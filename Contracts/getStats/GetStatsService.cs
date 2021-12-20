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
        public void getStats(int id)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IGetStatsClient>();

            Stats stats = new Stats(id);
            int MatchesP = stats.getMatchesPlayed();
            int MatchesW = stats.getMatchesW();
            Decimal MatchesPer = stats.GetWinP();
            int Elo = stats.GetEloActual();
            int MaxElo = stats.GetEloMax();

            connection.ShowStats(MatchesP, MatchesW, MatchesPer, MaxElo, Elo);
        }
    }
}
