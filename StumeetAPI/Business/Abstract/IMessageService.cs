using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IMessageService
    {
        Task<List<Message>> GetAll();
        Task<Message> GetByID(int id);
        Task<Message> GetByCondition(Expression<Func<Message, bool>> filter = null);
        Task<Message> Add(Message user);
        Task<Message> Update(Message user);
    }
}
