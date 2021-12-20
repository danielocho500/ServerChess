/******************************************************************/
/* Archivo: IFriendConnectedClient.cs                             */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 01/nov/2021                                             */
/* Fecha modificación: 04/nov/2021                                */
/* Descripción: Interfaz con los metodos implementados por el     */
/*              cliente para los usuarios conectados              */
/******************************************************************/
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
