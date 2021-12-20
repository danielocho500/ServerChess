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

        public void move(bool isWhite, string matchCode, string previousPosition, string newPosition, int timeLeft)
        {
            if (isWhite)
            {
                Globals.Matches[matchCode].idBlackConnection.movePiece(previousPosition, newPosition,timeLeft);
            }
            else
            {
                Globals.Matches[matchCode].idWhiteConnection.movePiece(previousPosition, newPosition, timeLeft);
            }
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

        public void win(bool isWhite, bool won, string matchCode)
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
                    match.idBlackConnection.MatchEnds(true, oldEloBlack, newEloBlack);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    match.idWhiteConnection.MatchEnds(false, oldEloWhite, newEloWhite);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                try
                {
                    match.idWhiteConnection.MatchEnds(true, oldEloWhite, newEloWhite);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                try
                {
                    match.idBlackConnection.MatchEnds(false, oldEloBlack, newEloBlack);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
