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
    public class EducationInformationManager : IEducationInformationService
    {
        private IEducationInformationDal _educationInformationDal;

        public EducationInformationManager(IEducationInformationDal educationInformationDal)
        {
            _educationInformationDal = educationInformationDal;
        }

        public async Task<EducationInformation> Add(EducationInformation educationInformationDal)
        {
            //ValidatorTool.Validate(new UserValidator(), educationInformationDal);
            return await _educationInformationDal.Add(educationInformationDal);
        }

        public async Task<List<EducationInformation>> GetAll(Expression<Func<EducationInformation, bool>> filter = null)
        {
            return await _educationInformationDal.GetList(filter);
        }

        public async Task<EducationInformation> GetByCondition(Expression<Func<EducationInformation, bool>> filter = null)
        {
            return await _educationInformationDal.Get(filter);
        }

        public async Task<EducationInformation> GetByID(int id)
        {
            return await _educationInformationDal.Get(u => u.Id == id);
        }

        public async Task<EducationInformation> Update(EducationInformation educationInformationDal)
        {
            //ValidatorTool.Validate(new UserValidator(), educationInformationDal);
            return await _educationInformationDal.Update(educationInformationDal);
        }
    }
}
