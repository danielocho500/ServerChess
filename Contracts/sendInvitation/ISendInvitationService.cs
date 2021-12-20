/******************************************************************/
/* Archivo: ISendInvitationService.cs                             */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 06/nov/2021                                             */
/* Fecha modificación: 11/nov/2021                                */
/* Descripción: Definición de metodos en el servidor para mandar  */
/*              invitaciones a partida                            */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.sendInvitation
{
    [ServiceContract(CallbackContract = typeof(ISendInvitationClient))]
    interface ISendInvitationService
    {
        [OperationContract(IsOneWay = true)]
        void GenerateCodeInvitation(int id);
        [OperationContract(IsOneWay = true)]
        void ValidateCodeInvitation(int id, string code);
        [OperationContract(IsOneWay = true)]
        void DeleteCodeInvitation(string code);
    }
}
