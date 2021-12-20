using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RespondRequest
{
    [ServiceContract(CallbackContract = typeof(IRespondClient))]
    interface IRespondService
    {
        [OperationContract(IsOneWay = true)]
        void getRequests(int idUser);
        [OperationContract(IsOneWay = true)]
        void confirmRequest(bool accept, int idUserSend, int idUserRecive);
    }
}
