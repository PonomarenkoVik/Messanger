using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract.Classes;

namespace BL
{
    class MessageValidator
    {
    

        public MessageValidator(AMessage mess)
        {
            _mess = mess;
        }


        public bool IsValid { get; private set; }
        public string Message { get; private set; }

        public void Validate()
        {
            if (_mess.Body.Length < 2 || _mess.Body.Length > 500)
            {
                IsValid = false;
                Message += "Message length doesn't fit required range (2 - 500). ";
            }
            DateTime minDateTime = new DateTime(2015,1,1);
            
            if (_mess.Date < minDateTime || _mess.Date > DateTime.Now)
            {
                IsValid = false;
                Message += "Date doesn't fit required range (1.1.2015 - DateTime.Now). ";
            }

            if (_mess.User == null)
            {
                IsValid = false;
                Message += "Message creator is null";
            }
        }

        private readonly AMessage _mess;
    }
}
