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
    public class MessageGroupManager : IMessageGroupService
    {
        private IMessageGroupDal _messageGroupDal;

        public MessageGroupManager(IMessageGroupDal messageGroupDal)
        {
            _messageGroupDal = messageGroupDal;
        }

        public async Task<MessageGroup> Add(MessageGroup messageGroupDal)
        {
            //ValidatorTool.Validate(new UserValidator(), messageGroupDal);
            return await _messageGroupDal.Add(messageGroupDal);
        }

        public async Task<List<MessageGroup>> GetAll(Expression<Func<MessageGroup, bool>> filter = null)
        {
            return await _messageGroupDal.GetList(filter);
        }

        public async Task<MessageGroup> GetByCondition(Expression<Func<MessageGroup, bool>> filter = null)
        {
            return await _messageGroupDal.Get(filter);
        }

        public async Task<MessageGroup> GetByID(int id)
        {
            return await _messageGroupDal.Get(u => u.Id == id);
        }

        public async Task<MessageGroup> Update(MessageGroup messageGroupDal)
        {
            //ValidatorTool.Validate(new UserValidator(), messageGroupDal);
            return await _messageGroupDal.Update(messageGroupDal);
        }
    }
}
