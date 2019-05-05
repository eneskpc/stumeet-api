using StumeetAPI.Core.DataAccess.EntityFramework;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StumeetAPI.DataAccess.Concrete.EntityFramework
{
    public class EFMessageGroupDal : EFEntityRepository<MessageGroup, StumeetDBContext>, IMessageGroupDal
    {
        public async Task<List<MessageGroup>> GetListWithInclude(Expression<Func<MessageGroup, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<MessageGroup>().ToListAsync() :
                    await context.Set<MessageGroup>().Where(filter).ToListAsync();
            }
        }

        public async Task<MessageGroup> GetWithInclude(Expression<Func<MessageGroup, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<MessageGroup>().FirstOrDefaultAsync() :
                    await context.Set<MessageGroup>().Where(filter).FirstOrDefaultAsync();
            }
        }
    }
}
