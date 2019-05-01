using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IEventParticipantService
    {
        Task<List<EventParticipant>> GetAll(Expression<Func<EventParticipant, bool>> filter = null);
        Task<EventParticipant> GetByID(int id);
        Task<EventParticipant> GetByCondition(Expression<Func<EventParticipant, bool>> filter = null);
        Task<EventParticipant> Add(EventParticipant user);
        Task<EventParticipant> Update(EventParticipant user);
    }
}
