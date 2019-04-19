using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IDeletedMessageService
    {
        Task<List<DeletedMessage>> GetAll();
        Task<DeletedMessage> GetByID(int id);
        Task<DeletedMessage> GetByCondition(Expression<Func<DeletedMessage, bool>> filter = null);
        Task<DeletedMessage> Add(DeletedMessage user);
        Task<DeletedMessage> Update(DeletedMessage user);
    }
}
