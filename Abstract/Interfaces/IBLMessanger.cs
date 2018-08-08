using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract.Classes;

namespace Abstract
{
    public interface IBLMessanger
    {
        Task<List<AMessage>> GetMessagesByPage(int page, int pageSize);
        Task<List<AMessage>> GetMessagesByUser(long userId);
        Task<AUser> GetUserById(long userId);
        Task<List<AUser>> GetUsersByPage(int page, int pageSize);
        Task<bool> TryRegister(AUser user);
        Task<bool> AddMessage(AMessage message);
        Task<long> GetCountMessages();
    }
}
