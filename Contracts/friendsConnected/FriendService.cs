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
            //Aqui se agrega al diccionario
            Globals.UsersConnected[id] = connection;
            Dictionary<int,string> friends = ContactsHelper.getFriends(id);

            List<string> connectedFriends = new List<string>();
            List<string> disconnecteddFriends = new List<string>();

            string actualUsername = UserHelper.GetUsername(id);

            foreach (int friendId in friends.Keys)
            {
                
                if (Globals.UsersConnected.Keys.Contains(friendId))
                {
                    Globals.UsersConnected[friendId].NewConecction(actualUsername);

                    connectedFriends.Add(friends[friendId]);
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
            //Aqui los borra :c
            Globals.UsersConnected.Remove(id);

            Dictionary<int,string> friends = ContactsHelper.getFriends(id);
            string actualUsername = UserHelper.GetUsername(id);
            //Aqui avisa que se desconecto, y asi le hice pero es con duplex
            //Y ya tadam
            foreach (int friendId in friends.Keys)
            {
                if (Globals.UsersConnected.Keys.Contains(friendId))
                {
                    Globals.UsersConnected[friendId].NewDisconecction(actualUsername);
                }
            }
        }

        public void PrintDictionary(Dictionary<int, string> dictionary)
        {
            foreach(int key in dictionary.Keys)
            {
                Console.WriteLine(dictionary[key]);
            }
        }
    }
}
