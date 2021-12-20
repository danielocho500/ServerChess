using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Contracts.checkConnection
{
    [ServiceContract(CallbackContract = typeof(IConnectionClient))]
    interface IConnectionService
    {
        [OperationContract(IsOneWay = true)]
        void check();
    }
}
