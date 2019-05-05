using StumeetAPI.Core.DataAccess;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Abstract
{
    public interface IEventParticipantDal : IEntityRepository<EventParticipant>
    {
        Task<EventParticipant> GetWithInclude(Expression<Func<EventParticipant,bool>> filter = null);
        Task<List<EventParticipant>> GetListWithInclude(Expression<Func<EventParticipant, bool>> filter = null);

    }
}
