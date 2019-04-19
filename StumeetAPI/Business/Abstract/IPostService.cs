using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IPostService
    {
        Task<List<Post>> GetAll();
        Task<Post> GetByID(int id);
        Task<Post> GetByCondition(Expression<Func<Post, bool>> filter = null);
        Task<Post> Add(Post user);
        Task<Post> Update(Post user);
    }
}
