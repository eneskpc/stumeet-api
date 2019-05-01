using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IWorkInformationService
    {
        Task<List<WorkInformation>> GetAll(Expression<Func<WorkInformation, bool>> filter = null);
        Task<WorkInformation> GetByID(int id);
        Task<WorkInformation> GetByCondition(Expression<Func<WorkInformation, bool>> filter = null);
        Task<WorkInformation> Add(WorkInformation user);
        Task<WorkInformation> Update(WorkInformation user);
    }
}
