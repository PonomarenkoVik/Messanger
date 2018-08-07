using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Classes
{
    public class AMessage
    {
        public long MessageId { get; set; }
        public long UserId { get; set; }
        public string Body { get; set; }
        public System.DateTime Date { get; set; }

        public AUser User { get; set; }
    }
}
