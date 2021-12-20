using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.getStats
{
    [ServiceContract]
    interface IGetStatsClient
    {
        [OperationContract(IsOneWay = true)]
        void ShowStats(int Matches_played, int Matches_win, Decimal WinP, int eloMax, int eloActual);
    }
}
