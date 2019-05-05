using StumeetAPI.Core.DataAccess;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Abstract
{
    public interface IMessageGroupDal : IEntityRepository<MessageGroup>
    {
        Task<List<MessageGroup>> GetListWithInclude(Expression<Func<MessageGroup, bool>> filter = null);
        Task<MessageGroup> GetWithInclude(Expression<Func<MessageGroup, bool>> filter = null);
    }
}
