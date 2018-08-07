using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Abstract.Classes;

namespace MessangerDataLayer
{
    public static class MessagerExtention
    {
        public static AMessage ConvertToAMessage(this Message mess)
        {
            AMessage aMess = new AMessage
            {
                Body = mess.Body,
                Date = mess.Date,
                MessageId = mess.MessageId,
                UserId = mess.UserId,
                User = mess.User.ConvertToAUser()
            };
            return aMess;
        }

        public static AUser ConvertToAUser(this User user)
        {
            AUser aUser = new AUser()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Email = user.Email,
                Messages = null
            };
            return aUser;
        }
    }
}
