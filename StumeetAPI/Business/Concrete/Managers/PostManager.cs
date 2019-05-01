using StumeetAPI.Business.Abstract;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class PostManager : IPostService
    {
        private IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public async Task<Post> Add(Post post)
        {
            //ValidatorTool.Validate(new UserValidator(), post);
            return await _postDal.Add(post);
        }

        public async Task<List<Post>> GetAll(Expression<Func<Post, bool>> filter = null)
        {
            return await _postDal.GetList(filter);
        }

        public async Task<Post> GetByCondition(Expression<Func<Post, bool>> filter = null)
        {
            return await _postDal.Get(filter);
        }

        public async Task<Post> GetByID(int id)
        {
            return await _postDal.Get(u => u.Id == id);
        }

        public async Task<Post> Update(Post post)
        {
            //ValidatorTool.Validate(new UserValidator(), post);
            return await _postDal.Update(post);
        }
    }
}
