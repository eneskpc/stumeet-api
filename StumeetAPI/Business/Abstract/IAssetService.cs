using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAll(Expression<Func<Asset, bool>> filter = null);
        Task<Asset> GetByID(int id);
        Task<Asset> GetByCondition(Expression<Func<Asset, bool>> filter = null);
        Task<Asset> Add(Asset user);
        Task<Asset> Update(Asset user);
    }
}
