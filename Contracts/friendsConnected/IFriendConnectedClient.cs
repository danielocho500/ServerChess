using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;



namespace Contracts.friendsConnected
{
    [ServiceContract]

    interface IFriendConnectedClient
    {
        [OperationContract(IsOneWay = true)]
        void getUsers(string[] usernamesConnected, string[] usernamesDisconnected);
        [OperationContract(IsOneWay = true)]
        void newConecction(string username);
        [OperationContract(IsOneWay = true)]
        void newDisconecction(string username);
    }
}
