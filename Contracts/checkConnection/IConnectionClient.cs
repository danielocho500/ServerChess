using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Contracts.checkConnection
{
    [ServiceContract]
    interface IConnectionClient
    {
        [OperationContract(IsOneWay = true)]
        void isConnected(bool status);


    }
}
