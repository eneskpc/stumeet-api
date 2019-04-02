using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Stumeet.Core.Entities;

namespace Stumeet.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
    }
}
