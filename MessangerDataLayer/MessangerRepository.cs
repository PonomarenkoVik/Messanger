using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;
using Abstract;
using Abstract.Classes;

namespace MessangerDataLayer
{
    public class MessangerRepository : IMessangerRepository
    {
        public async Task<List<AMessage>> GetMessagesById(int skip, int numberMessages)
        {
            List<AMessage> result = new List<AMessage>();
            try
            {
                using (var messDbContext = new MessageDatabaseCont())
                {
                    var messages = await messDbContext.Messages
                        .OrderBy(message => message.MessageId)
                        .Skip(skip)
                        .Take(numberMessages).ToListAsync();

                    foreach (var message in messages)
                    {
                        result.Add(message.ConvertToAMessage());
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }

            return result;
        }

        public async Task<List<AUser>> GetUsersById(int skip, int numberUsers)
        {
            List<AUser> result = new List<AUser>();
            try
            {
                using (var messDbContext = new MessageDatabaseCont())
                {
                    var users = await messDbContext.Users
                        .OrderBy(user => user.UserId)
                        .Skip(skip)
                        .Take(numberUsers).ToListAsync();

                    foreach (var user in users)
                    {
                        result.Add(user.ConvertToAUser());
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }

            return result;
        }

        public async Task<List<AMessage>> GetMessagesByUser(long userId)
        {
            List<AMessage> result = new List<AMessage>();
            try
            {
                using (var messDbContext = new MessageDatabaseCont())
                {
                    var messages = await messDbContext.Messages.Where(m => m.UserId == userId).ToListAsync();

                    foreach (var message in messages)
                    {
                       result.Add(message.ConvertToAMessage());
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }

            return result;
        }

        public async Task<AUser> GetUserById(long userId)
        {
            AUser user = null;
            try
            {
                using (var messDbContext = new MessageDatabaseCont())
                {
                    user = (await messDbContext.Users.SingleAsync<User>(u => u.UserId == userId)).ConvertToAUser();
                    var messages = messDbContext.Messages.Where(m => m.UserId == userId);
                    var aMessages = new List<AMessage>();
                    foreach (var message in messages)
                    {
                        aMessages.Add(message.ConvertToAMessage());
                    }

                    user.Messages = aMessages;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            return user;
        }

        public async Task<long> GetCountMessages()
        {  
            long result = -1;
            try
            {
                using (var messDbContext = new MessageDatabaseCont())
                {
                    result = await messDbContext.Messages.CountAsync();
                }
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }
        public async Task<bool> IsUserExist(string email)
        {
            bool result;
            try
            {
                using (var messDbContext = new MessageDatabaseCont())
                {
                    var user = await messDbContext.Users.SingleAsync(u => u.Email == email);
                    result = true;

                }
            }
            catch (InvalidOperationException)
            {
                result = false;
            }
            return result;
        }

        public void AddMessage(AMessage mess)
        {
            if (mess != null)
            {
                Message ms = new Message()
                {
                    Body = mess.Body,
                    UserId = mess.UserId,
                    Date = mess.Date
                };
               
                try
                {
                    using (var messDbContext = new MessageDatabaseCont())
                    {
                        messDbContext.Messages.Add(ms);
                    }
                }
                catch (Exception e)
                {
                    throw new NotImplementedException();
                }

            }
        }

        public void AddUser(AUser user)
        {
            if (user != null)
            {
                User us = new User
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName
                };

                try
                {
                    using (var messDbContext = new MessageDatabaseCont())
                    {
                        messDbContext.Users.Add(us);
                    }
                }
                catch (Exception e)
                {
                    throw new NotImplementedException();
                }
                
            }
        }
    }
}
