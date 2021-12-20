using Contracts.friendsConnected;
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
        public void GiveUp(bool isWhite, string matchCode)
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
                try
                {
                    match.idWhiteConnection.MatchEnds(false, oldEloWhite, newEloWhite);
                }
                catch (CommunicationObjectAbortedException)
                {
                }
                try
                {
                    match.idBlackConnection.MatchEnds(true, oldEloBlack, newEloBlack);
                }
                catch (CommunicationObjectAbortedException)
                {
                }                
            }
            else
            {
                try
                {
                    match.idWhiteConnection.MatchEnds(true, oldEloWhite, newEloWhite);
                }
                catch (CommunicationObjectAbortedException)
                {
                }
                try
                {
                    match.idBlackConnection.MatchEnds(false, oldEloBlack, newEloBlack);
                }
                catch (CommunicationObjectAbortedException)
                {
                }                
            }

            Globals.Matches.Remove(matchCode);
        }

        public void Move(bool isWhite, string matchCode, string previousPosition, string newPosition, int timeLeft)
        {
            try
            {
                if (isWhite)
                {
                    Globals.Matches[matchCode].idBlackConnection.MovePiece(previousPosition, newPosition, timeLeft);
                }
                else
                {
                    Globals.Matches[matchCode].idWhiteConnection.MovePiece(previousPosition, newPosition, timeLeft);
                }
            }
            catch (CommunicationObjectAbortedException)
            {
                int idLoseConection = (isWhite) ? Globals.Matches[matchCode].idBlack : Globals.Matches[matchCode].idWhite;
                if (Globals.UsersConnected.Keys.Contains(idLoseConection))
                {
                    FriendService friendService = new FriendService();
                    friendService.Disconnected(idLoseConection);
                }

                GiveUp(!isWhite, matchCode);
            }
        }

        public void SendConnection(bool isWhite, string matchCode)
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
            try
            {
                if (isWhite)
                    match.idBlackConnection.ReciveMessage(message, GetHourFormat());
                else
                    match.idWhiteConnection.ReciveMessage(message, GetHourFormat());
            }
            catch (CommunicationObjectAbortedException)
            {
                int idLoseConection = (isWhite) ? match.idBlack : match.idWhite;
                
                if (Globals.UsersConnected.Keys.Contains(idLoseConection))
                {
                    FriendService friendService = new FriendService();
                    friendService.Disconnected(idLoseConection);
                }

                GiveUp(!isWhite, matchCode);
            }
        }

        public void Win(bool isWhite, bool won, string matchCode)
        {
            Match match;
            try
            {
                match = Globals.Matches[matchCode];
            }
            catch (KeyNotFoundException)
            {
                return;
            }

            Stats statsWhite = new Stats(match.idWhite);
            int oldEloWhite = statsWhite.GetEloActual();
            int newEloWhite = statsWhite.win(!isWhite);

            Stats statsBlack = new Stats(match.idBlack);
            int oldEloBlack = statsBlack.GetEloActual();
            int newEloBlack = statsBlack.win(isWhite);
            if (isWhite)
            {
                try
                {
                    match.idBlackConnection.MatchEnds(true, oldEloBlack, newEloBlack);

                }
                catch (CommunicationObjectAbortedException)
                {
                }
                try
                {
                    match.idWhiteConnection.MatchEnds(false, oldEloWhite, newEloWhite);
                }
                catch (CommunicationObjectAbortedException)
                {
                }
            }
            else
            {
                try
                {
                    match.idWhiteConnection.MatchEnds(true, oldEloWhite, newEloWhite);
                }
                catch (CommunicationObjectAbortedException)
                {
                }
                try
                {
                    match.idBlackConnection.MatchEnds(false, oldEloBlack, newEloBlack);
                }
                catch (CommunicationObjectAbortedException)
                {
                }
            }

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
