using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RespondRequest
{
    [ServiceContract]
    interface IRespondClient
    {
        [OperationContract(IsOneWay = true)]
        void ReciveRequest(Dictionary<int,string> users);
    }
}
