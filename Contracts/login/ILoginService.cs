using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.login
{
    [ServiceContract(CallbackContract = typeof(ILoginClient))]
    interface ILoginService
    {
        [OperationContract(IsOneWay = true)]
        void Login(string username, string password);
    }
}
