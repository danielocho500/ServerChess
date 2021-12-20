using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ContactRequest
{
    [ServiceContract(CallbackContract = typeof(IRequestClient))]
    interface IRequestService
    {
        [OperationContract(IsOneWay = true)]
        void sendRequest(string username, int idUser);
    }
}
