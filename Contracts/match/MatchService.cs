using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.match
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class MatchService : IMatchService
    {
        public void sendConnection(bool white, string matchCode)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IMatchClient>();

            if (white)
            {
                Globals.Matches[matchCode].idWhiteConnection = connection;
            }
            else
            {
                Globals.Matches[matchCode].idBlackConnection = connection;
            }
        }

        public void SendMessage(string message, string matchCode)
        {
            if (Globals.Matches.Keys.Contains(matchCode))
            {
                Match match = Globals.Matches[matchCode];
                match.idWhiteConnection.ReciveMessage(message);
                match.idBlackConnection.ReciveMessage(message);
            }
        }
    }
}
