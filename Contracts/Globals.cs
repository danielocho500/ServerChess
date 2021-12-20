/******************************************************************/
/* Archivo: Globals.cs                                            */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 6/nov/2021                                              */
/* Fecha modificación: 6/nov/2021                                 */
/* Descripción: Almacenar variables globales en el sistema como   */
/*              la de los usuarios conectados                     */
/******************************************************************/
using Contracts.friendsConnected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace Contracts
{
    static class Globals
    {
        private static Dictionary<int, IFriendConnectedClient> _getsetUsers = new Dictionary<int, IFriendConnectedClient>();
        public static Dictionary<int, IFriendConnectedClient> UsersConnected
        {
            set { _getsetUsers = value; }
            get { return _getsetUsers; }
        }

       
        private static Dictionary<string,Match> _getsetMatches = new Dictionary<string, Match>();
        public static Dictionary<string, Match> Matches
        {
            set { _getsetMatches = value; }
            get { return _getsetMatches; }
        }

    }
}
