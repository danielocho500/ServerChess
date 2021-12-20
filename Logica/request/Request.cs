using Logica.helpers;

namespace Logica.request 
{
    public class Request
    {
        public static int Send(string userRecieve, int idSend)
        {
            bool exist = UserHelper.Exist(userRecieve);

            if (!exist)
                return 5;

            var idRecive = UserHelper.GetIdUser(userRecieve);

            if (idRecive == idSend)
                return 6;

            ContactsStatus contactsStatus = ContactsHelper.ContactsRelation(idSend, idRecive);


            switch (contactsStatus)
            {
                case ContactsStatus.friends:
                    return 2;                        
                case ContactsStatus.rejected:
                    return 4;
                case ContactsStatus.requested:
                    return 3;
                case ContactsStatus.failed:
                    return 1;
            }


            SendStatus sendStatus = ContactsHelper.SendRequest(idSend, idRecive);

            if (sendStatus == SendStatus.success)
                return 0;

            return 1;
        }
    }

    public enum RequestStatus
    {
        success = 0,
        failed = 1,
        friendsAlready = 2,
        requestedAlready = 3,
        rejected = 4,
        UserNotFound = 5,
        AutoRequest = 6
    }
}
