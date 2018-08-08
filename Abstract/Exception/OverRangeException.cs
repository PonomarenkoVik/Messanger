using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Exception
{
    public class OverRangeException : ApplicationException
    {
        public OverRangeException(string mess) : base(mess)
        {
        }
    }
}
