/******************************************************************/
/* Archivo: IFriendConnectedClient.cs                             */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 01/nov/2021                                             */
/* Fecha modificación: 04/nov/2021                                */
/* Descripción: Interfaz con los metodos callback para el cliente */
/*              con los usuarios conectados                       */
/******************************************************************/
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
        //mETODOs del cliente
        [OperationContract(IsOneWay = true)]
        void GetUsers(string[] usernamesConnected, string[] usernamesDisconnected);
        [OperationContract(IsOneWay = true)]
        void NewConecction(string username);
        [OperationContract(IsOneWay = true)]
        void NewDisconecction(string username);
    }
}
