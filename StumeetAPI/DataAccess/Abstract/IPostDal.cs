using StumeetAPI.Core.DataAccess;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
        Task<List<Post>> GetListWithInclude(Expression<Func<Post, bool>> filter = null);
        Task<Post> GetWithInclude(Expression<Func<Post, bool>> filter = null);
    }
}
