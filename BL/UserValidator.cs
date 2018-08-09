using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract.Classes;

namespace BL
{
    class UserValidator
    {
        public UserValidator(AUser user)
        {
            _user = user;
            IsValid = true;
        }

        public bool IsValid { get; private set; }
        public string Message { get; private set; }

        public void Validate()
        {
            if (_user.FirstName.Length < 2 || _user.FirstName.Length > 20)
            {
                IsValid = false;
                Message += "User first name length doesn't fit required range (2 - 20). ";
            }
            if (_user.SecondName.Length < 2 || _user.SecondName.Length > 20)
            {
                IsValid = false;
                Message += "User second name length doesn't fit required range (2 - 20). ";
            }
            if (!IsValidEmail(_user.Email))
            {
                IsValid = false;
                Message += "User email isn't valid";
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private readonly AUser _user;
    }
}
