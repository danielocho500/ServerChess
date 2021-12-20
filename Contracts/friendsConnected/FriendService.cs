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
        Dictionary<int,IFriendConnectedClient> users = new Dictionary<int, IFriendConnectedClient>();
        public void Connected(int id)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IFriendConnectedClient>();
            users[id] = connection;
            Dictionary<int,string> friends = ContactsHelper.getFriends(id);

            List<string> connectedFriends = new List<string>();
            List<string> disconnecteddFriends = new List<string>();

            string actualUsername = UserHelper.getUsername(id);

            foreach (int friendId in friends.Keys)
            {
                
                if (users.Keys.Contains(friendId))
                {
                    users[friendId].newConecction(actualUsername);

                    connectedFriends.Add(friends[friendId]);
                }
                else
                {
                    disconnecteddFriends.Add(friends[friendId]);
                }
            }

            connection.getUsers(connectedFriends.ToArray(), disconnecteddFriends.ToArray());
        }

        public void Disconnected(int id)
        {
            users.Remove(id);

            Dictionary<int,string> friends = ContactsHelper.getFriends(id);
            string actualUsername = UserHelper.getUsername(id);
            foreach (int friendId in friends.Keys)
            {
                if (users.Keys.Contains(friendId))
                {        
                    users[friendId].newDisconecction(actualUsername);
                }
            }
        }

        public void printDictionary(Dictionary<int, string> dictionary)
        {
            foreach(int key in dictionary.Keys)
            {
                Console.WriteLine(dictionary[key]);
            }
        }
    }
}
