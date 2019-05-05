using Microsoft.EntityFrameworkCore;
using StumeetAPI.Core.DataAccess.EntityFramework;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Concrete.EntityFramework
{
    public class EFEventParticipantDal : EFEntityRepository<EventParticipant, StumeetDBContext>, IEventParticipantDal
    {
        public async Task<List<EventParticipant>> GetListWithInclude(Expression<Func<EventParticipant, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<EventParticipant>().Include("User").ToListAsync() :
                    await context.Set<EventParticipant>().Include("User").Where(filter).ToListAsync();
            }
        }

        public async Task<EventParticipant> GetWithInclude(Expression<Func<EventParticipant, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<EventParticipant>().Include("User").FirstOrDefaultAsync() :
                    await context.Set<EventParticipant>().Include("User").Where(filter).FirstOrDefaultAsync();
            }
        }
    }
}
