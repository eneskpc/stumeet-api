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
    public class UniversityManager : IUniversityService
    {
        private IUniversityDal _universityDal;

        public UniversityManager(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }

        public async Task<University> Add(University university)
        {
            //ValidatorTool.Validate(new UserValidator(), university);
            return await _universityDal.Add(university);
        }

        public async Task<List<University>> GetAll(Expression<Func<University, bool>> filter = null)
        {
            return await _universityDal.GetList(filter);
        }

        public async Task<University> GetByCondition(Expression<Func<University, bool>> filter = null)
        {
            return await _universityDal.Get(filter);
        }

        public async Task<University> GetByID(int id)
        {
            return await _universityDal.Get(u => u.Id == id);
        }

        public async Task<University> Update(University university)
        {
            //ValidatorTool.Validate(new UserValidator(), university);
            return await _universityDal.Update(university);
        }
    }
}
