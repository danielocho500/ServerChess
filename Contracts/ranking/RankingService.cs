using Logica.ranking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ranking
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class RankingService : IRankingService
    {
        public void getRanking()
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRankingClient>();
            
            List<Tuple<string, int>> listWin = new List<Tuple<string, int>>();
            RankingUser rankingUser = new RankingUser();
            listWin = rankingUser.GetWin();
            
            connection.ShowRanking(listWin.First());
        }
    }
}
