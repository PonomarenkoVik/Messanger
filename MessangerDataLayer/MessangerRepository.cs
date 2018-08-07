using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abstract;
using Abstract.Classes;

namespace MessangerDataLayer
{
    public class MessangerRepository : IMessangerRepository
    {
        public List<AMessage> GetMessagesById(long startId, long numberMessages)
        {
            throw new NotImplementedException();
        }

        public List<AMessage> GetMessagesByUser(long userId)
        {
            throw new NotImplementedException();
        }

        public AUser GetUserById(long userId)
        {
            AUser user = null;
            try
            {
                using (var messDbContext = new MessageDatabaseContext())
                {
                    user = messDbContext.Users.Single<User>(u => u.UserId == userId).ConvertToAUser();
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
            long result;
            try
            {
                using (var messDbContext = new MessageDatabaseContext())
                {
                    result = await messDbContext.Messages.CountAsync();
                }
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            return result;
        }
        public async Task<bool> IsUserExists(string email)
        {
            bool result;
            try
            {
                using (var messDbContext = new MessageDatabaseContext())
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


        public ViewResult ListMessage(int page = 1)
        {
            MessageListViewModel model = new MessageListViewModel()
            {
                Messages = _blMessanger.Messages
                    .OrderBy(message => message.MessageId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _blMessanger.Messages.Count()
                }

            };
            return View(model);
        }
    }
}
