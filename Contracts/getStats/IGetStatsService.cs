using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.getStats
{
    [ServiceContract(CallbackContract = typeof(IGetStatsClient))]

    interface IGetStatsService
    {
        [OperationContract(IsOneWay = true)]
        void getStats(int id);
    }
}
