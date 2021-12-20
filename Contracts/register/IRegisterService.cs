using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.register
{
    [ServiceContract(CallbackContract = typeof(IRegisterClient))]
    interface IRegisterService
    {
        [OperationContract]
        bool generateCode(string username, string password, string email);
        [OperationContract(IsOneWay = true)]
        void verificateCode(string codeuser);
    }
}
