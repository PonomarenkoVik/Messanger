using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Exception
{
    public class UserExistException : ApplicationException
    {
        public UserExistException(string mess) : base(mess)
        { 
        }
    }
}
