using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IDataTypeExtensionService
    {
        Task<List<DataTypeExtension>> GetAll();
        Task<DataTypeExtension> GetByID(int id);
        Task<DataTypeExtension> GetByCondition(Expression<Func<DataTypeExtension, bool>> filter = null);
        Task<DataTypeExtension> Add(DataTypeExtension user);
        Task<DataTypeExtension> Update(DataTypeExtension user);
    }
}
