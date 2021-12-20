using Logica.register;
using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Logica.Email;

namespace Contracts.register
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class RegisterService : IRegisterService
    {
        Dictionary<IRegisterClient, UserData> codes = new Dictionary<IRegisterClient, UserData>();
        public bool generateCode(string username, string password, string email)
        {
            Email.AccountExistStatus status = Email.exist(email, username);

            if (status == Email.AccountExistStatus.emailExist || status == Email.AccountExistStatus.userExist)
                return false;

            string code = GenerateCode.GetVerificationCode(6);

            UserData ud = new UserData(username, password, email, code);
            
            bool emailStatus = SendEmail.send(email, code, username);

            if (emailStatus)
            {
                var connection = OperationContext.Current.GetCallbackChannel<IRegisterClient>();
                codes[connection] = ud;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void verificateCode(string codeUser)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRegisterClient>();
            string codeServer = codes[connection].getCode();

            if (codeServer != codeUser) 
            {
                connection.ValidateCode(false, "The code is invalid");
            }

            else
            {
                string username = codes[connection].getusername();
                string password = codes[connection].getPassword();
                string email = codes[connection].getEmail();

                Register register = new Register();
                RegisterStatus status = register.RegisterAccount(username, password, email);

                if (status == RegisterStatus.Success)
                    connection.ValidateCode(true, "Account Registered");
                else
                    connection.ValidateCode(false, "Connection lost with the database");
            }
        }
    }

    class UserData
    {
        string username;
        string password;
        string email;
        string code;
        public UserData(string username_, string password_, string email_, string code_)
        {
            username = username_;
            password = password_;
            email = email_;
            code = code_;
        }

        public string getCode()
        {
            return this.code;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getusername()
        {
            return this.username;
        }
    }
}
