using StumeetAPI.Business.Abstract;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public async Task<Message> Add(Message message)
        {
            //ValidatorTool.Validate(new UserValidator(), message);
            return await _messageDal.Add(message);
        }

        public async Task<List<Message>> GetAll(Expression<Func<Message, bool>> filter = null)
        {
            return await _messageDal.GetListWithInclude(filter);
        }

        public async Task<Message> GetByCondition(Expression<Func<Message, bool>> filter = null)
        {
            return await _messageDal.GetWithInclude(filter);
        }

        public async Task<Message> GetByID(int id)
        {
            return await _messageDal.GetWithInclude(u => u.Id == id);
        }

        public async Task<Message> Update(Message message)
        {
            //ValidatorTool.Validate(new UserValidator(), message);
            return await _messageDal.Update(message);
        }
    }
}
