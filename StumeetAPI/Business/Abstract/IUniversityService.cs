using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IUniversityService
    {
        Task<List<University>> GetAll(Expression<Func<University, bool>> filter = null);
        Task<University> GetByID(int id);
        Task<University> GetByCondition(Expression<Func<University, bool>> filter = null);
        Task<University> Add(University user);
        Task<University> Update(University user);
    }
}
