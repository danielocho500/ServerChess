/******************************************************************/
/* Archivo: ISendInvitationClient.cs                              */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 06/nov/2021                                             */
/* Fecha modificación: 11/nov/2021                                */
/* Descripción: Definición de metodos callback al cliente para    */
/*              mandar invitaciones a partida                     */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.sendInvitation
{
    [ServiceContract]
    interface ISendInvitationClient
    {
        [OperationContract(IsOneWay = true)]
        void GetCodeMatch(bool status, string code);
        [OperationContract(IsOneWay = true)]
        void ValidateCodeStatus(int status, string usernameRival, string username, string codeMatch, bool white);
        [OperationContract(IsOneWay = true)]
        void JoinMatch(string usernameRival, string username, string codeMatch, bool white);
    }
}
