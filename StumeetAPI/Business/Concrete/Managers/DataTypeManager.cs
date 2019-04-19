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
    public class DataTypeManager : IDataTypeService
    {
        private IDataTypeDal _dataTypeDal;

        public DataTypeManager(IDataTypeDal dataTypeDal)
        {
            _dataTypeDal = dataTypeDal;
        }

        public async Task<DataType> Add(DataType dataType)
        {
            //ValidatorTool.Validate(new UserValidator(), dataType);
            return await _dataTypeDal.Add(dataType);
        }

        public async Task<List<DataType>> GetAll()
        {
            return await _dataTypeDal.GetList();
        }

        public async Task<DataType> GetByCondition(Expression<Func<DataType, bool>> filter = null)
        {
            return await _dataTypeDal.Get(filter);
        }

        public async Task<DataType> GetByID(int id)
        {
            return await _dataTypeDal.Get(u => u.Id == id);
        }

        public async Task<DataType> Update(DataType dataType)
        {
            //ValidatorTool.Validate(new UserValidator(), dataType);
            return await _dataTypeDal.Update(dataType);
        }
    }
}
