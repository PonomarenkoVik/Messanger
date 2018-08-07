using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Classes
{
    public class AUser
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<AMessage> Messages { get; set; }
    }
}
