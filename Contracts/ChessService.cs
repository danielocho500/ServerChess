/******************************************************************/
/* Archivo: ChessService.cs                                       */
/* Programador: Daniel Díaz Rossell                               */
/* Fecha: 17/oct/2021                                             */
/* Fecha modificación: 4/nov/2021                                 */
/* Descripción: Se encuentran todas las interfaces y servicios    */
/*              del sistema                                       */
/******************************************************************/
using Contracts.match;
using Contracts.checkConnection;
using Contracts.ContactRequest;
using Contracts.friendsConnected;
using Contracts.login;
using Contracts.register;
using Contracts.RespondRequest;
using Contracts.sendInvitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts.getStats;
using Contracts.ranking;

namespace Contracts
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class ChessService : IRegisterService, ILoginService, IConnectionService, IRequestService, IRespondService, IFriendService, ISendInvitationService, IMatchService, IGetStatsService, IRankingService
    {
        public RegisterService registerService = new RegisterService();
        public LoginService loginService = new LoginService();
        public ConnectionService connectionService = new ConnectionService();
        public RequestService requestService = new RequestService();
        public RespondService respondService = new RespondService();
        public FriendService friendService = new FriendService();
        public SendInvitation sendInvitation = new SendInvitation();
        public MatchService matchService = new MatchService();
        public GetStatsService GetStatsService = new GetStatsService();
        public RankingService rankingService = new RankingService();

        public void Check()
        {
            connectionService.Check();
        }

        public void ConfirmRequest(bool accept, int idUserSend, int idUserRecive)
        {
            respondService.ConfirmRequest(accept, idUserSend, idUserRecive);
        }

        public void Connected(int id)
        {
            friendService.Connected(id);
        }

        public void DeleteCodeInvitation(string code)
        {
            sendInvitation.DeleteCodeInvitation(code);
        }

        public void Disconnected(int id)
        {
            friendService.Disconnected(id);
        }

        public void GenerateCodeRegister(string username, string password, string email)
        {
            
            registerService.GenerateCodeRegister(username,password,email);
        }

        public void GenerateCodeInvitation(int id)
        {
            sendInvitation.GenerateCodeInvitation(id);
        }

        public void GetRequests(int idUser)
        {
            respondService.GetRequests(idUser);
        }

        public void Login(string username, string password)
        {
            loginService.Login(username, password);
        }



        public void SendRequest(string username, int idUser)
        {
            requestService.SendRequest(username, idUser);
        }

        public void ValidateCodeInvitation(int id, string code)
        {
            sendInvitation.ValidateCodeInvitation(id, code);
        }

        public void VerificateCode(string codeuser)
        {
            registerService.VerificateCode(codeuser);
        }

        public void SendMessage(bool isWhite,string message, string matchCode)
        {
            matchService.SendMessage(isWhite,message, matchCode);
        }

        public void SendConnection(bool isWhite, string matchCode)
        {
            matchService.SendConnection(isWhite, matchCode);
        }

        public void GetStats(int id)
        {
            GetStatsService.GetStats(id);
        }

        public void GiveUp(bool isWhite, string matchCode)
        {
            matchService.GiveUp(isWhite, matchCode);
        }

        public void Win(bool isWhite, bool won, string matchCode)
        {
            matchService.Win(isWhite, won, matchCode);
        }

        public void Move(bool isWhite, string matchCode, string previousPosition, string newPosition, int timeleft)
        {
            matchService.Move(isWhite, matchCode, previousPosition, newPosition,timeleft);
        }

        public void GetRanking(int idUser)
        {
            rankingService.GetRanking(idUser);
        }
    }
}
