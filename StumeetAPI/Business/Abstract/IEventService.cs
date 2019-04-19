using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IEventService
    {
        Task<List<Event>> GetAll();
        Task<Event> GetByID(int id);
        Task<Event> GetByCondition(Expression<Func<Event, bool>> filter = null);
        Task<Event> Add(Event user);
        Task<Event> Update(Event user);
    }
}
