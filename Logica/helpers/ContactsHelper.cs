using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.helpers
{
    class ContactsHelper
    {
        public static ContactsStatus contactsStatus(int idSend, int idRecive)
        {
            ContactsStatus status = ContactsStatus.failed;

            using (var context = new SuperChess())
            {
                var AmigoExist = from Amigo in context.Amigos
                                 where (Amigo.amigo_A == idSend && Amigo.amigo_B == idRecive)
                                    || (Amigo.amigo_A == idRecive && Amigo.amigo_B == idSend)
                                 select Amigo;
                if (AmigoExist.Count() > 0)
                {
                    switch (AmigoExist.First().status)
                    {
                        case 0:
                            status = ContactsStatus.friends;
                            break;
                        case 1:
                            status = ContactsStatus.requested;
                            break;
                        case 2:
                            status = ContactsStatus.rejected;
                            break;
                        default:
                            status = ContactsStatus.failed;
                            break;
                    }
                }
                else
                {
                    status = ContactsStatus.noRelation;
                }
            }

            return status;
        }

        public static SendStatus sendRequest(int idSend, int idRecive)
        {
            SendStatus requestStatus = SendStatus.failed;

            using( var context = new SuperChess())
            {
                Amigo request = new Amigo()
                {
                    amigo_A = idSend,
                    amigo_B = idRecive,
                    status = 1
                };

                context.Amigos.Add(request);
                int entries = context.SaveChanges();
                context.SaveChanges();



                if (entries > 0)
                {
                    requestStatus = SendStatus.success;
                }
            }

            return requestStatus;
        }
    }

    public enum ContactsStatus
    {
        noRelation,
        friends,
        rejected,
        requested,
        failed
    }

    public enum SendStatus
    {
        success,
        failed
    }
}
