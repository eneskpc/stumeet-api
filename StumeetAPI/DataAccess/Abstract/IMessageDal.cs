using StumeetAPI.Core.DataAccess;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        Task<List<Message>> GetListWithInclude(Expression<Func<Message, bool>> filter = null);
        Task<Message> GetWithInclude(Expression<Func<Message, bool>> filter = null);
    }
}
