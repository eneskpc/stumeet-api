using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IEducationInformationService
    {
        Task<List<EducationInformation>> GetAll();
        Task<EducationInformation> GetByID(int id);
        Task<EducationInformation> GetByCondition(Expression<Func<EducationInformation, bool>> filter = null);
        Task<EducationInformation> Add(EducationInformation user);
        Task<EducationInformation> Update(EducationInformation user);
    }
}
