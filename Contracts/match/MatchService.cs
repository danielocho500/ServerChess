using Logica;
using Logica.stats;
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
        public void giveUp(bool isWhite, string matchCode)
        {
            Match match = Globals.Matches[matchCode];
            
            Stats statsWhite = new Stats(match.idWhite);
            int oldEloWhite = statsWhite.GetEloActual();
            int newEloWhite = statsWhite.win(!isWhite);

            Stats statsBlack = new Stats(match.idBlack);
            int oldEloBlack = statsBlack.GetEloActual();
            int newEloBlack = statsBlack.win(isWhite);

            if (isWhite)
            {
                match.idWhiteConnection.MatchEnds(false,oldEloWhite,newEloWhite);
                match.idBlackConnection.MatchEnds(true, oldEloBlack, newEloBlack);
            }
            else
            {
                match.idWhiteConnection.MatchEnds(true, oldEloWhite, newEloWhite);
                match.idBlackConnection.MatchEnds(false, oldEloBlack, newEloBlack);
            }

            Globals.Matches.Remove(matchCode);
        }

        public void sendConnection(bool isWhite, string matchCode)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IMatchClient>();

            if (isWhite)
            {
                Globals.Matches[matchCode].idWhiteConnection = connection;
            }
            else
            {
                Globals.Matches[matchCode].idBlackConnection = connection;
            }
        }

        public void SendMessage(bool isWhite, string message, string matchCode)
        {
            if (!Globals.Matches.Keys.Contains(matchCode))
                return;

            Match match = Globals.Matches[matchCode];
            if (isWhite)
                match.idBlackConnection.ReciveMessage(message, GetHourFormat());
            else
                match.idWhiteConnection.ReciveMessage(message, GetHourFormat());
        }

        private string GetHourFormat()
        {
            var date = DateTime.Now;
            int hour = date.Hour;
            int minute = date.Minute;
            return "[" + hour + ":" + minute + "]";
        }
    }
}
