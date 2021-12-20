using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.helpers
{
    public class ContactsHelper
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
                Amigos request = new Amigos()
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

        public static Dictionary<int, string> getRequest(int idUser)
        {
            Dictionary<int, string> requets = new Dictionary<int, string>();

            using (var context = new SuperChess())
            {
                var users = from Amigos in context.Amigos
                            where Amigos.amigo_B == idUser && Amigos.status == 1
                            select Amigos;

                foreach( var user in users)
                {
                    var username = from usuario in context.Usuarios
                                   where usuario.id_usuarios == user.amigo_A
                                   select usuario;

                    requets[user.amigo_A] = username.First().username;
                }
            }

            return requets;
        }

        public static StatusRespond ConfirmRequest(bool accept, int idUserSend, int idUserRecive)
        {
            StatusRespond status = StatusRespond.failed;

            using (var context = new SuperChess())
            {
                var request = from Amigo in context.Amigos
                              where Amigo.amigo_B == idUserSend && Amigo.amigo_A == idUserRecive
                              select Amigo;

                if (accept == true)
                {
                    request.First().status = 0;
                }
                else
                {
                    request.First().status = 2;
                }
                int var = context.SaveChanges();

                if (var > 0)
                {
                    status = StatusRespond.success;
                }
            }

            return status;
        }

        public static int[] getFriends(int id)
        {
            int[] arr = new int[100];

            using (var context = new SuperChess())
            {
                var friends = from Amigo in context.Amigos
                              where (Amigo.amigo_A == id && Amigo.status == 0) || (Amigo.amigo_B == id && Amigo.status == 0)
                              select Amigo;

                foreach (var friend in friends)
                {
                    if (id != friend.amigo_A)
                        arr.Append(friend.amigo_A);
                    else
                        arr.Append(friend.amigo_B);
                }
            }
            
            
            return arr;
        }

    }

    public enum StatusRespond
    {
        success,
        failed
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
