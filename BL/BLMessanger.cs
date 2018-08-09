using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract;
using Abstract.Classes;
using Abstract.Exception;

namespace BL
{
    public class BLMessanger : IBLMessanger

    {
        public BLMessanger(IMessangerRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<AMessage>> GetMessagesByPage(int page, int pageSize)
        {
            List<AMessage> result = null;
            int skip = (page - 1) * pageSize;
            try
            {
                if (pageSize >= 3 && pageSize <= 20)
                {
                    result = await _repository.GetMessagesById(skip, pageSize);
                }
                else
                {
                    throw new OverRangeException("pagesize doesn't fit requied range (3 - 20)");
                }
            }
            catch (NullReferenceException e)
            {
                throw;
            }
            catch (OverRangeException e)
            {
                throw;
            }
            return result;
        }

        public async Task<List<AMessage>> GetMessagesByUser(long userId)
        {
            List<AMessage> mess = await _repository.GetMessagesByUser(userId);
            return mess;
        }

        public async Task<AUser> GetUserById(long userId)
        {
            AUser user = await _repository.GetUserById(userId);
            return user;
        }

        public async Task<List<AUser>> GetUsersByPage(int page, int pageSize)
        {
            List<AUser> result = null;
            int skip = (page - 1) * pageSize;
            try
            {
                if (pageSize >= 3 && pageSize <= 20)
                {
                    result = await _repository.GetUsersById(skip, pageSize);
                }
                else
                {
                    throw new OverRangeException("pagesize doesn't fit requied range (3 - 20)");
                }
            }
            catch (NullReferenceException e)
            {
                throw;
            }
            catch (OverRangeException e)
            {
                throw;
            }
            return result;
        }

        public async Task<bool> TryRegister(AUser user)
        {
            bool result = false;
            try
            {
                if (user != null)
                {
                    string mess;

                    if (UserValidate(user, out mess))
                    {
                        bool userIsExist = await _repository.IsUserExist(user.Email);

                        if (!userIsExist)
                        {
                            _repository.AddUser(user);
                            result = true;
                        }
                        else
                        {
                            throw new UserExistException("User is exist");
                        }
                    }
                    else
                    {
                        throw new UserValidateException(mess);
                    }

                }
                else
                {
                    throw new NullReferenceException("User is null");
                }

            }
            catch (NullReferenceException e)
            {
                throw;
            }
            catch (UserValidateException e)
            {
                throw;
            }
            catch (UserExistException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            return result;
        }


        public Task<bool> AddMessage(AMessage message)
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetCountMessages()
        {
            long count = await _repository.GetCountMessages();
            return count;
        }


        private bool UserValidate(AUser user, out string mess)
        {
            bool result = true;
            UserValidator validator = new UserValidator(user);
            validator.Validate();
            if (validator.IsValid != true)
            {
                result = false;
                mess = validator.Message;
            }
            else
            {
                mess = null;
            }
            return result;
        }

        private readonly IMessangerRepository _repository;
    }
}
