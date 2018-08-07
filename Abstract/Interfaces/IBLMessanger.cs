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

        List<AMessage> GetMessagesByPage(int page, int pageSize);
        List<AMessage> GetMessagesByUser(long userId);
        AUser GetUserById(long userId);
        List<AUser> GetUsersByPage(int page, int pageSize);
        bool TryRegister(AUser user);
        bool AddMessage(AMessage message);
        long CountMessages { get; }
    }
}
