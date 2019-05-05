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
    public class EventParticipantManager : IEventParticipantService
    {
        private IEventParticipantDal _eventParticipantDal;

        public EventParticipantManager(IEventParticipantDal eventParticipantDal)
        {
            _eventParticipantDal = eventParticipantDal;
        }

        public async Task<EventParticipant> Add(EventParticipant eventParticipant)
        {
            //ValidatorTool.Validate(new UserValidator(), eventParticipant);
            return await _eventParticipantDal.Add(eventParticipant);
        }

        public async Task<List<EventParticipant>> GetAll(Expression<Func<EventParticipant, bool>> filter = null)
        {
            return await _eventParticipantDal.GetListWithInclude(filter);
        }

        public async Task<EventParticipant> GetByCondition(Expression<Func<EventParticipant, bool>> filter = null)
        {
            return await _eventParticipantDal.GetWithInclude(filter);
        }

        public async Task<EventParticipant> GetByID(int id)
        {
            return await _eventParticipantDal.Get(u => u.Id == id);
        }

        public async Task<EventParticipant> Update(EventParticipant eventParticipant)
        {
            //ValidatorTool.Validate(new UserValidator(), eventParticipant);
            return await _eventParticipantDal.Update(eventParticipant);
        }
    }
}
