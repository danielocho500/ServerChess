using Contracts.checkConnection;
using Contracts.ContactRequest;
using Contracts.login;
using Contracts.register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    class ChessService : IRegisterService, ILoginService, IConnectionService, IRequestService
    {
        public RegisterService registerService = new RegisterService();
        public LoginService loginService = new LoginService();
        public ConnectionService connectionService = new ConnectionService();
        public RequestService requestService = new RequestService();

        public void check()
        {
            connectionService.check();
        }

        public bool generateCode(string username, string password, string email)
        {
            
            return registerService.generateCode(username,password,email);
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
