using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.login
{
    [ServiceContract]
    interface ILoginClient
    {
        [OperationContract(IsOneWay = true)]
        void LoginStatus(bool status, string message);
    }
}
