using Contracts.login;
using Contracts.register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    class ChessService : IRegisterService, ILoginService
    {
        public RegisterService registerService = new RegisterService();
        public LoginService loginService = new LoginService();

        public bool generateCode(string username, string password, string email)
        {
            
            return registerService.generateCode(username,password,email);
        }

        public void Login(string username, string password)
        {
            loginService.Login(username, password);
        }

        public void verificateCode(string codeuser)
        {
            registerService.verificateCode(codeuser);
        }
    }
}
