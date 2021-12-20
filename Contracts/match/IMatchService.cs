using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.match
{
    [ServiceContract(CallbackContract = typeof(IMatchClient))]
    interface IMatchService
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string matchCode);

        [OperationContract(IsOneWay = true)]
        void sendConnection(bool white, string matchCode);


    }
}
