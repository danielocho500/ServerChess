using Contracts.friendsConnected;
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
        public void GetRanking(int idUser)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRankingClient>();
            
            RankingUser rankingUser = new RankingUser();

            List<Tuple<string, int>> listWin = rankingUser.GetWin();

            try
            {
                connection.ShowRanking(listWin);
            }
            catch (CommunicationObjectAbortedException)
            {
                if (Globals.UsersConnected.Keys.Contains(idUser))
                {
                    FriendService friendService = new FriendService();
                    friendService.Disconnected(idUser);
                }
            }
        }
    }
}
