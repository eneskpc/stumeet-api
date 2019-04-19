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
    public class PostCommentManager : IPostCommentService
    {
        private IPostCommentDal _postCommentDal;

        public PostCommentManager(IPostCommentDal postCommentDal)
        {
            _postCommentDal = postCommentDal;
        }

        public async Task<PostComment> Add(PostComment postComment)
        {
            //ValidatorTool.Validate(new UserValidator(), postComment);
            return await _postCommentDal.Add(postComment);
        }

        public async Task<List<PostComment>> GetAll()
        {
            return await _postCommentDal.GetList();
        }

        public async Task<PostComment> GetByCondition(Expression<Func<PostComment, bool>> filter = null)
        {
            return await _postCommentDal.Get(filter);
        }

        public async Task<PostComment> GetByID(int id)
        {
            return await _postCommentDal.Get(u => u.Id == id);
        }

        public async Task<PostComment> Update(PostComment postComment)
        {
            //ValidatorTool.Validate(new UserValidator(), postComment);
            return await _postCommentDal.Update(postComment);
        }
    }
}
