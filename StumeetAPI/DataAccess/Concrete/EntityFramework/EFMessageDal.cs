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
    public class EFMessageDal : EFEntityRepository<Message, StumeetDBContext>, IMessageDal
    {
        public async Task<List<Message>> GetListWithInclude(Expression<Func<Message, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<Message>().Include("User").Include("Group").ToListAsync() :
                    await context.Set<Message>().Include("User").Include("Group").Where(filter).ToListAsync();
            }
        }

        public async Task<Message> GetWithInclude(Expression<Func<Message, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<Message>().Include("User").Include("Group").FirstOrDefaultAsync() :
                    await context.Set<Message>().Include("User").Include("Group").Where(filter).FirstOrDefaultAsync();
            }
        }
    }
}
