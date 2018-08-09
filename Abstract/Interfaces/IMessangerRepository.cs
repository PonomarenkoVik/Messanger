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
        Task<List<AMessage>> GetMessagesById(int skip, int numberMessages);
        Task<List<AUser>> GetUsersById(int skip, int numberUsers);
        Task<List<AMessage>> GetMessagesByUser(long userId);
        Task<AUser> GetUserById(long userId);
        Task<long> GetCountMessages();
        Task<bool> IsUserExist(string email);
        void AddMessage(AMessage mess);
        void AddUser(AUser user);
    }
}
