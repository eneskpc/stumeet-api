using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IPostCommentService
    {
        Task<List<PostComment>> GetAll(Expression<Func<PostComment, bool>> filter = null);
        Task<PostComment> GetByID(int id);
        Task<PostComment> GetByCondition(Expression<Func<PostComment, bool>> filter = null);
        Task<PostComment> Add(PostComment user);
        Task<PostComment> Update(PostComment user);
    }
}
