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

        public bool GenerateCodeRegister(string username, string password, string email)
        {
            
            return registerService.GenerateCodeRegister(username,password,email);
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

        public void sendConnection(bool white, string matchCode)
        {
            matchService.sendConnection(white, matchCode);
        }

        public void getStats(int id)
        {
            GetStatsService.getStats(id);
        }

        public void giveUp(bool isWhite, string matchCode)
        {
            matchService.giveUp(isWhite, matchCode);
        }

        public void win(bool isWhite, bool won, string matchCode)
        {
            matchService.win(isWhite, won, matchCode);
        }

        public void move(bool isWhite, string matchCode, string previousPosition, string newPosition, int timeLeft)
        {
            matchService.move(isWhite, matchCode, previousPosition, newPosition,timeLeft);
        }

        public void getRanking()
        {
            rankingService.getRanking();
        }
    }
}
