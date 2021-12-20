using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RespondRequest
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class RespondService : IRespondService
    {
        public void confirmRequest(bool accept, int idUserSend, int idUserRecive)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRespondClient>();
            Console.WriteLine(idUserSend + "- " +"- " +idUserRecive + "-" + accept);

            StatusRespond status =  ContactsHelper.ConfirmRequest(accept,idUserSend,idUserRecive);

        }
        public void getRequests(int idUser)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IRespondClient>();
            Dictionary<int,string> users = ContactsHelper.getRequest(idUser);
            connection.ReciveRequest(users);
        }
    }
}
