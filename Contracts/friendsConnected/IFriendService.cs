using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.friendsConnected
{
    [ServiceContract(CallbackContract = typeof(IFriendConnectedClient))]
    interface IFriendService
    {
        [OperationContract(IsOneWay =true)]
        void Connected(int id);
        [OperationContract(IsOneWay = true)]
        void Disconnected(int id);
    }
}
