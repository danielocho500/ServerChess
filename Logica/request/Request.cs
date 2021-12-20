

using Logica.helpers;

namespace Logica.request 
{
    public class Request
    {
        public static RequestStatus send(string user, int idSend)
        {
            bool exist = UserHelper.Exist(user);

            if (!exist)
                return RequestStatus.UserNotFound;

            var idRecive = UserHelper.getIdUser(user);

            ContactsStatus contactsStatus = ContactsHelper.contactsStatus(idSend, idRecive);


            switch (contactsStatus)
            {
                case ContactsStatus.friends:
                    return RequestStatus.friendsAlready;                        
                case ContactsStatus.rejected:
                    return RequestStatus.rejected;
                case ContactsStatus.requested:
                    return RequestStatus.requestedAlready;
                case ContactsStatus.failed:
                    return RequestStatus.Failed;
            }


            SendStatus sendStatus = ContactsHelper.sendRequest(idSend, idRecive);

            if (sendStatus == SendStatus.success)
                return RequestStatus.success;

            return RequestStatus.Failed;
        }
    }

    public enum RequestStatus
    {
        success,
        friendsAlready,
        requestedAlready,
        rejected,
        UserNotFound,
        Failed
    }
}
