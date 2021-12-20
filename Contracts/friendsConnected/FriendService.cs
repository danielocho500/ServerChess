/******************************************************************/
/* Archivo: FriendtSrvice.cs                                      */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 01/nov/2021                                             */
/* Fecha modificación: 04/nov/2021                                */
/* Descripción: Tener un control de los usuarios que estan        */
/*              conectados                                        */
/******************************************************************/
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
        public void Connected(int id)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IFriendConnectedClient>();

            Globals.UsersConnected[id] = connection;
            Dictionary<int,string> friends = ContactsHelper.GetFriends(id);

            List<string> connectedFriends = new List<string>();
            List<string> disconnecteddFriends = new List<string>();

            string actualUsername = UserHelper.GetUsername(id);

            foreach (int friendId in friends.Keys)
            {
                
                if (Globals.UsersConnected.Keys.Contains(friendId))
                {
                    try
                    {
                        Globals.UsersConnected[friendId].NewConecction(actualUsername);
                        connectedFriends.Add(friends[friendId]);
                    }
                    catch(CommunicationObjectAbortedException)
                    {
                        disconnecteddFriends.Add(friends[friendId]);
                        Globals.UsersConnected.Remove(friendId);
                    }
                }
                else
                {
                    disconnecteddFriends.Add(friends[friendId]);
                }
            }

            connection.GetUsers(connectedFriends.ToArray(), disconnecteddFriends.ToArray());
        }

        public void Disconnected(int id)
        {
            Globals.UsersConnected.Remove(id);

            Dictionary<int,string> friends = ContactsHelper.GetFriends(id);
            string actualUsername = UserHelper.GetUsername(id);

            foreach (int friendId in friends.Keys)
            {
                if (Globals.UsersConnected.Keys.Contains(friendId))
                {
                    try
                    {
                        Globals.UsersConnected[friendId].NewDisconecction(actualUsername);
                    }
                    catch (CommunicationObjectAbortedException)
                    {
                        Globals.UsersConnected.Remove(friendId);
                    }
                }
            }
        }

        public static bool StillConnected(int id)
        {
            if (Globals.UsersConnected.Keys.Contains(id))
            {
                try
                {
                    Globals.UsersConnected[id].SeeConecction();
                    return true;
                }
                catch (CommunicationObjectAbortedException)
                {
                    Globals.UsersConnected.Remove(id);
                    return false;
                }    
            }
            else
                return false;
        }

        public static void NewFriend(int idUserSend, int idUserRecieve)
        {
            bool userSend = Globals.UsersConnected.Keys.Contains(idUserSend);
            bool userRecieve = Globals.UsersConnected.Keys.Contains(idUserRecieve);
            

            if(userSend)
                Globals.UsersConnected[idUserSend].newFriend(UserHelper.GetUsername(idUserRecieve), userRecieve);

            if (userRecieve)
                Globals.UsersConnected[idUserRecieve].newFriend(UserHelper.GetUsername(idUserSend), userSend);
        }
    }
}
