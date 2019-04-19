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
    public class DataTypeExtensionManager : IDataTypeExtensionService
    {
        private IDataTypeExtensionDal _dataTypeExtensionDal;

        public DataTypeExtensionManager(IDataTypeExtensionDal dataTypeExtensionDal)
        {
            _dataTypeExtensionDal = dataTypeExtensionDal;
        }

        public async Task<DataTypeExtension> Add(DataTypeExtension dataTypeExtension)
        {
            //ValidatorTool.Validate(new UserValidator(), dataTypeExtension);
            return await _dataTypeExtensionDal.Add(dataTypeExtension);
        }

        public async Task<List<DataTypeExtension>> GetAll()
        {
            return await _dataTypeExtensionDal.GetList();
        }

        public async Task<DataTypeExtension> GetByCondition(Expression<Func<DataTypeExtension, bool>> filter = null)
        {
            return await _dataTypeExtensionDal.Get(filter);
        }

        public async Task<DataTypeExtension> GetByID(int id)
        {
            return await _dataTypeExtensionDal.Get(u => u.Id == id);
        }

        public async Task<DataTypeExtension> Update(DataTypeExtension dataTypeExtension)
        {
            //ValidatorTool.Validate(new UserValidator(), dataTypeExtension);
            return await _dataTypeExtensionDal.Update(dataTypeExtension);
        }
    }
}
