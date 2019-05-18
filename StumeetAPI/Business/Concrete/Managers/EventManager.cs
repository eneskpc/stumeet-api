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
    public class EventManager : IEventService
    {
        private IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public async Task<Event> Add(Event eventInfo)
        {
            //ValidatorTool.Validate(new UserValidator(), eventInfo);
            return await _eventDal.Add(eventInfo);
        }

        public async Task<List<Event>> GetAll(Expression<Func<Event, bool>> filter = null)
        {
            return await _eventDal.GetListWithInclude(filter);
        }

        public async Task<Event> GetByCondition(Expression<Func<Event, bool>> filter = null)
        {
            return await _eventDal.GetWithInclude(filter);
        }

        public async Task<Event> GetByID(int id)
        {
            return await _eventDal.GetWithInclude(u => u.Id == id);
        }

        public async Task<Event> Update(Event eventInfo)
        {
            //ValidatorTool.Validate(new UserValidator(), eventInfo);
            return await _eventDal.Update(eventInfo);
        }
    }
}
