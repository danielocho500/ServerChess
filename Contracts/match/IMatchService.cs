/******************************************************************/
/* Archivo: IMatchService.cs                                       */
/* Programador: Daniel Diaz Rossell                               */
/* Fecha: 30/oct/2021                                             */
/* Fecha modificación: 10/Nov/2021                                */
/* Descripción: Interfaz donde se definen metodos del servidor    */
/*               pora el servicio Match                           */
/******************************************************************/

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
        void SendConnection(bool isWhite, string matchCode);

        [OperationContract(IsOneWay = true)]
        void GiveUp(bool isWhite, string matchCode);

        [OperationContract(IsOneWay = true)]
        void Win(bool isWhite,bool won, string matchCode);

        [OperationContract(IsOneWay = true)]
        void Move(bool isWhite, string matchCode, string previousPosition, string newPosition, int timeleft);

    }
}
