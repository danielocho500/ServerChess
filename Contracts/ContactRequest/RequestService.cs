using Logica.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ContactRequest
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class RequestService : IRequestService
    {
        public void sendRequest(string username, int idUser)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRequestClient>();

            RequestStatus request = Request.send(username, idUser);

            if (request == RequestStatus.success)
                connection.sendRequestStatus(true, "request send");
            else if (request == RequestStatus.UserNotFound)
                connection.sendRequestStatus(false, "user missing");
            else if (request == RequestStatus.friendsAlready)
                connection.sendRequestStatus(false, "You are friends already");
            else if (request == RequestStatus.rejected)
                connection.sendRequestStatus(false, "You were Rejected before");
            else if (request == RequestStatus.AutoRequest)
                connection.sendRequestStatus(false, "You cannot send a friend request to yourself");
            else if (request == RequestStatus.Failed)
                connection.sendRequestStatus(false, "An error ocurred trying to send the request");


                
        }
    }
}
