/******************************************************************/
/* Archivo: RankingService.cs                                    */
/* Programador: Raul Arturo Peredo Estudillo                      */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  15/Nov/2021                               */
/* Descripción: Interfaz donde se definen metodos del servidor    */
/*               pora el servicio ranking                         */
/******************************************************************/

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
