/******************************************************************/
/* Archivo: ISendInvitationService.cs                             */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 06/nov/2021                                             */
/* Fecha modificación: 11/nov/2021                                */
/* Descripción: Definición de metodos en el servidor para crear   */
/*              invitaciones a partida                            */
/******************************************************************/
using Logica;
using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.sendInvitation
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class SendInvitation : ISendInvitationService
    {
        Dictionary<string, DataInvitation> invitations = new Dictionary<string, DataInvitation>();

        public void DeleteCodeInvitation(string code)
        {
            if (invitations.Keys.Contains(code))
            {
                invitations.Remove(code);
            }
        }

        public void GenerateCodeInvitation(int id)
        {
            var connection = OperationContext.Current.GetCallbackChannel<ISendInvitationClient>();

            //validate if the user is alreay in a match

            string code = GenerateCode.GetVerificationCode(4);
            while (invitations.Keys.Contains(code) && Globals.Matches.Keys.Contains(code))
            {
                code = GenerateCode.GetVerificationCode(4);
            }

            invitations[code] = new DataInvitation(id, connection);

            connection.GetCodeMatch(true, code);

        }

        public void ValidateCodeInvitation(int id, string code)
        {
            var connection = OperationContext.Current.GetCallbackChannel<ISendInvitationClient>();
            
            //validate if the user is alreay in a match
            foreach(string key in Globals.Matches.Keys)
            {
                Match match = Globals.Matches[key];
                if(match.idWhite == id || match.idBlack == id)
                {
                    connection.ValidateCodeStatus(false, "", "", false);
                    return;
                }

            }

            if (invitations.Keys.Contains(code))
            {
                int idRival = invitations[code].idUserSend;
                string usernameRival = UserHelper.GetUsername(idRival);
                string usernameActual = UserHelper.GetUsername(id);

                //validate if the rival user is still connected
                if (!Globals.UsersConnected.Keys.Contains(idRival))
                {
                    connection.ValidateCodeStatus(false, "", "",false);
                    return;
                }

                //crete the match
                Globals.Matches[code] = new Match(idRival, id);
                
                connection.ValidateCodeStatus(true,usernameRival,code,false);
                invitations[code].connection.JoinMatch(usernameActual,code,true);

                

                invitations.Remove(code);
            }
            else
            {
                connection.ValidateCodeStatus(false, "", "",false);
            }
        }
    }

     class DataInvitation
    {
        public int idUserSend { get; set; }
        public ISendInvitationClient connection { get; set; }

        public DataInvitation( int _idUserSend, ISendInvitationClient _connection)
        {
            idUserSend = _idUserSend;
            connection = _connection;
        }
    }
}
