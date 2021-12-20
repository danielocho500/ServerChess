using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ContactRequest
{
    [ServiceContract]
    interface IRequestClient
    {
        [OperationContract(IsOneWay = true)]
        void sendRequestStatus(bool status,string msg);
    }
}
