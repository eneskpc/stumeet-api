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
    public class WorkInformationManager : IWorkInformationService
    {
        private IWorkInformationDal _workInformationDal;

        public WorkInformationManager(IWorkInformationDal workInformationDal)
        {
            _workInformationDal = workInformationDal;
        }

        public async Task<WorkInformation> Add(WorkInformation workInformation)
        {
            //ValidatorTool.Validate(new UserValidator(), workInformation);
            return await _workInformationDal.Add(workInformation);
        }

        public async Task<List<WorkInformation>> GetAll()
        {
            return await _workInformationDal.GetList();
        }

        public async Task<WorkInformation> GetByCondition(Expression<Func<WorkInformation, bool>> filter = null)
        {
            return await _workInformationDal.Get(filter);
        }

        public async Task<WorkInformation> GetByID(int id)
        {
            return await _workInformationDal.Get(u => u.Id == id);
        }

        public async Task<WorkInformation> Update(WorkInformation workInformation)
        {
            //ValidatorTool.Validate(new UserValidator(), workInformation);
            return await _workInformationDal.Update(workInformation);
        }
    }
}
