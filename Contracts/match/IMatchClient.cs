/******************************************************************/
/* Archivo: IMatchClient.cs                                       */
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
    [ServiceContract]
    public interface IMatchClient
    {
        [OperationContract(IsOneWay = true)]
        void ReciveMessage(string message,string time);
        [OperationContract(IsOneWay = true)]
        void MatchEnds(bool youWon, int oldElo,int newElo);
        [OperationContract(IsOneWay = true)]
        void MovePiece(string previousPosition, string newPosition, int timeLeft);
    }
}
