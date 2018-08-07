using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract;
using Abstract.Classes;

namespace BL
{
    public class BLMessanger : IBLMessanger
    {

        public List<AMessage> GetMessagesByPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public List<AMessage> GetMessagesByUser(long userId)
        {
            throw new NotImplementedException();
        }

        public AUser GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        public List<AUser> GetUsersByPage(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool TryRegister(AUser user)
        {
            throw new NotImplementedException();
        }

        public bool AddMessage(AMessage message)
        {
            throw new NotImplementedException();
        }

        public long CountMessages { get; }
    }
}
