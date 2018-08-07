using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract.Classes;

namespace Abstract
{
    public interface IMessangerRepository
    {
        List<AMessage> GetMessagesById(long startId, long numberMessages);
        List<AMessage> GetMessagesByUser(long userId);
        AUser GetUserById(long userId);

        Task<long> GetCountMessages();
        Task<bool> IsUserExists(string email);


    }
}
