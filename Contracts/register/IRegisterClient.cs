using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.register
{
    [ServiceContract]
    interface IRegisterClient
    {
        [OperationContract(IsOneWay = true)]
        void ValidateCode(bool codeStatus, string message);
    }
}
