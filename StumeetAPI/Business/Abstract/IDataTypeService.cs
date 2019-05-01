using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StumeetAPI.Entities.Concrete;

namespace StumeetAPI.Business.Abstract
{
    public interface IDataTypeService
    {
        Task<List<DataType>> GetAll(Expression<Func<DataType, bool>> filter = null);
        Task<DataType> GetByID(int id);
        Task<DataType> GetByCondition(Expression<Func<DataType, bool>> filter = null);
        Task<DataType> Add(DataType user);
        Task<DataType> Update(DataType user);
    }
}
