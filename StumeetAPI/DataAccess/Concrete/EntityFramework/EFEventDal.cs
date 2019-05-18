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
    public class EFEventDal : EFEntityRepository<Event, StumeetDBContext>, IEventDal
    {
        public async Task<List<Event>> GetListWithInclude(Expression<Func<Event, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<Event>().Include("User").OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.Id).ToListAsync() :
                    await context.Set<Event>().Include("User").OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.Id).Where(filter).ToListAsync();
            }
        }

        public async Task<Event> GetWithInclude(Expression<Func<Event, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<Event>().Include("User").FirstOrDefaultAsync() :
                    await context.Set<Event>().Include("User").Where(filter).FirstOrDefaultAsync();
            }
        }
    }
}
