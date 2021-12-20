using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.friendsConnected
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class FriendService : IFriendService
    {
        public Dictionary<int,IFriendConnectedClient> users = new Dictionary<int, IFriendConnectedClient>();
        public void Connected(int id)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IFriendConnectedClient>();
            users[id] = connection;
            int[] friends = ContactsHelper.getFriends(id);


            Console.WriteLine("Friends: ");
            foreach(int friendid in friends){
                Console.WriteLine("uwu: " + friendid);
            }

            string[] connectedFriends = new string[] { };

            foreach (int friendId in friends)
            {
                if (users.Keys.Contains(friendId))
                {
                    string actualUsername = UserHelper.getUsername(id);
                    users[friendId].newConecction(actualUsername);

                    string friendUsername = UserHelper.getUsername(friendId);
                    connectedFriends.Append(friendUsername);
                }
            }

            connection.getUsers(connectedFriends);
        }

        public void Disconnected(int id)
        {
            users.Remove(id);

            int[] friends = ContactsHelper.getFriends(id);
            foreach(int friendId in friends)
            {
                if (users.Keys.Contains(friendId))
                {
                    string actualUsername = UserHelper.getUsername(id);
                    users[friendId].newDisconecction(actualUsername);
                }
            }
        }
    }
}
