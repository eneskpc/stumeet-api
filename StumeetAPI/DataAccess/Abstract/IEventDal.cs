using StumeetAPI.Core.DataAccess;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Abstract
{
    public interface IEventDal : IEntityRepository<Event>
    {
        Task<List<Event>> GetListWithInclude(Expression<Func<Event, bool>> filter = null);
        Task<Event> GetWithInclude(Expression<Func<Event, bool>> filter = null);
    }
}
