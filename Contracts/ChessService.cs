using Contracts.checkConnection;
using Contracts.ContactRequest;
using Contracts.friendsConnected;
using Contracts.login;
using Contracts.register;
using Contracts.RespondRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    class ChessService : IRegisterService, ILoginService, IConnectionService, IRequestService, IRespondService, IFriendService
    {
        public RegisterService registerService = new RegisterService();
        public LoginService loginService = new LoginService();
        public ConnectionService connectionService = new ConnectionService();
        public RequestService requestService = new RequestService();
        public RespondService respondService = new RespondService();
        public FriendService friendService = new FriendService();

        public void check()
        {
            connectionService.check();
        }

        public void confirmRequest(bool accept, int idUserSend, int idUserRecive)
        {
            respondService.confirmRequest(accept, idUserSend, idUserRecive);
        }

        public void Connected(int id)
        {
            Console.WriteLine("connected");
            friendService.Connected(id);
        }

        public void Disconnected(int id)
        {
            Console.WriteLine("disconnected");
            //friendService.Disconnected(id);
        }

        public bool generateCode(string username, string password, string email)
        {
            
            return registerService.generateCode(username,password,email);
        }

        public void getRequests(int idUser)
        {
            respondService.getRequests(idUser);
        }

        public void Login(string username, string password)
        {
            loginService.Login(username, password);
        }

        public void sendRequest(string username, int idUser)
        {
            requestService.sendRequest(username, idUser);
        }

        public void verificateCode(string codeuser)
        {
            registerService.verificateCode(codeuser);
        }
    }
}
