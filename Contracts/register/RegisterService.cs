/******************************************************************/
/* Archivo: RegisterService.cs                                    */
/* Programador: Raul Peredo Estudillo                             */
/* Fecha: 18/oct/2021                                             */
/* Fecha modificación: 22/oct/2021                                */
/* Descripción: Permite a un usuario registrarse con un codigo que*/
/*              se envia a su corre                               */
/******************************************************************/
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
using static Logica.AccountExist.AccountExist;

namespace Contracts.register
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class RegisterService : IRegisterService
    {
        Dictionary<IRegisterClient, UserData> codes = new Dictionary<IRegisterClient, UserData>();
        public bool GenerateCodeRegister(string username, string password, string email)
        {
           AccountExistStatus status = exist(email, username);

            if (status == AccountExistStatus.emailExist || status == AccountExistStatus.userExist)
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

        public void VerificateCode(string codeUser)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRegisterClient>();
            string codeServer = codes[connection].GetCode();

            if (codeServer != codeUser) 
            {
                connection.ValidateCode(false, 1);
            }

            else
            {
                string username = codes[connection].Getusername();
                string password = codes[connection].GetPassword();
                string email = codes[connection].GetEmail();


                Register register = new Register();
                RegisterStatus status = register.RegisterAccount(username, password, email);



                if (status == RegisterStatus.Success)
                    connection.ValidateCode(true, 0);
                else
                    connection.ValidateCode(false, 2);
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

        public string GetCode()
        {
            return this.code;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public string Getusername()
        {
            return this.username;
        }
    }
}
