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
        void SendMessage(bool isWhite, string message, string matchCode);

        [OperationContract(IsOneWay = true)]
        void sendConnection(bool isWhite, string matchCode);

        [OperationContract(IsOneWay = true)]
        void giveUp(bool isWhite, string matchCode);

    }
}
