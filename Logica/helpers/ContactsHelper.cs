/******************************************************************/
/* Archivo: ContactsHelper.cs                                     */
/* Programador: Daniel Diaz Rossell                       */
/* Fecha: 15/Oct/2021                                             */
/* Fecha modificación:  30/Nov/2021                               */
/* Descripción: Metodos de para uso de contacts                   */
/******************************************************************/

using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logica.helpers
{
    public static class ContactsHelper
    {
        public static ContactsStatus ContactsRelation(int idSend, int idRecive)
        {
            ContactsStatus status = ContactsStatus.failed;
            try
            {
                using (var context = new SuperChess())
                {
                    var FriendExist = from Friend in context.Friends
                                      where (Friend.friend_A == idSend && Friend.friend_B == idRecive)
                                         || (Friend.friend_A == idRecive && Friend.friend_B == idSend)
                                      select Friend;
                    if (FriendExist.Count() > 0)
                    {
                        switch (FriendExist.First().status)
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
            }
            catch(Exception e)
            {
                Console.WriteLine("ContactsHelper.cs" + e.Message);
            }
            

            return status;
        }

        public static SendStatus SendRequest(int idSend, int idRecive)
        {
            SendStatus requestStatus = SendStatus.failed;
            try
            {
                using (var context = new SuperChess())
                {
                    Friends request = new Friends()
                    {
                        friend_A = idSend,
                        friend_B = idRecive,
                        status = 1
                    };

                    context.Friends.Add(request);
                    int entries = context.SaveChanges();
                    context.SaveChanges();



                    if (entries > 0)
                    {
                        requestStatus = SendStatus.success;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ContactsHelper.cs " + e.Message);
            }

            return requestStatus;
        }

        public static Dictionary<int, string> GetRequest(int idUser)
        {
            Dictionary<int, string> requets = new Dictionary<int, string>();

            try
            {
                using (var context = new SuperChess())
                {
                    var users = from Friend in context.Friends
                                where Friend.friend_B == idUser && Friend.status == 1
                                select Friend;

                    foreach (var user in users)
                    {
                        var username = from User in context.Users
                                       where User.id_user == user.friend_A
                                       select User;

                        requets[user.friend_A] = username.First().username;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ContactsHelper.cs " + e.Message);
            }

            return requets;
        }

        public static StatusRespond ConfirmRequest(bool accept, int idUserSend, int idUserRecive)
        {
            StatusRespond status = StatusRespond.failed;

            try
            {
                using (var context = new SuperChess())
                {
                    var request = from Friend in context.Friends
                                  where Friend.friend_B == idUserSend && Friend.friend_A == idUserRecive
                                  select Friend;

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
            }
            catch(Exception e)
            {
                Console.WriteLine("ContactsHelper.cs " + e.Message);
            }

            return status;
        }

        public static Dictionary<int,string> GetFriends(int id)
        {
            Dictionary<int, string> friends = new Dictionary<int, string>();
            try
            {
                using (var context = new SuperChess())
                {
                    var friendsDb = from Friend in context.Friends
                                    where (Friend.friend_A == id && Friend.status == 0) || (Friend.friend_B == id && Friend.status == 0)
                                    select Friend;

                    foreach (var friendDb in friendsDb)
                    {
                        if (id != friendDb.friend_A)
                        {
                            string name = UserHelper.GetUsername(friendDb.friend_A);
                            friends[friendDb.friend_A] = name;
                        }
                        else
                        {
                            string name = UserHelper.GetUsername(friendDb.friend_B);
                            friends[friendDb.friend_B] = name;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ContactsHelper.cs " + e.Message);
            }


            return friends;
        }

        public static void DeleteTest()
        {
            using (var context = new SuperChess())
            {
                var testFriendsRemove = from friend in context.Friends
                        where friend.friend_A == 25 || friend.friend_A == 29 || friend.friend_A == 26
                        select friend;
                
                foreach(var friend in testFriendsRemove)
                {
                    context.Friends.Remove(friend);
                }

                context.SaveChanges();
            }
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
