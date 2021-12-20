using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.match
{
    public interface IMatchClient
    {
        [OperationContract(IsOneWay = true)]
        void ReciveMessage(string message,string time);
        [OperationContract(IsOneWay = true)]
        void MatchEnds(bool youWon, int oldElo,int newElo);
    }
}
