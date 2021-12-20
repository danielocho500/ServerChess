using Contracts.getStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ranking
{
    [ServiceContract(CallbackContract = typeof(IRankingClient))]
    interface IRankingService
    {
        [OperationContract(IsOneWay = true)]
        void getRanking();
    }
}
