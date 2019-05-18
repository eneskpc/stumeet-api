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
    public class EFPostDal : EFEntityRepository<Post, StumeetDBContext>, IPostDal
    {
        public async Task<List<Post>> GetListWithInclude(Expression<Func<Post, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<Post>().Include("User").OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.Id).ToListAsync() :
                    await context.Set<Post>().Include("User").OrderByDescending(p => p.CreationDate).ThenByDescending(p => p.Id).Where(filter).ToListAsync();
            }
        }

        public async Task<Post> GetWithInclude(Expression<Func<Post, bool>> filter = null)
        {
            using (var context = new StumeetDBContext())
            {
                return filter == null ?
                    await context.Set<Post>().Include("User").FirstOrDefaultAsync() :
                    await context.Set<Post>().Include("User").Where(filter).FirstOrDefaultAsync();
            }
        }
    }
}
