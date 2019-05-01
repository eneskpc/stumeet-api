using StumeetAPI.Business.Abstract;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using StumeetAPI.Business.ValidationRules.FluentValidation;
using StumeetAPI.Core.CrossCuttingConcerns.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class AssetManager : IAssetService
    {
        private IAssetDal _assetDal;

        public AssetManager(IAssetDal assetDal)
        {
            _assetDal = assetDal;
        }

        public async Task<Asset> Add(Asset asset)
        {
            //ValidatorTool.Validate(new UserValidator(), asset);
            return await _assetDal.Add(asset);
        }

        public async Task<List<Asset>> GetAll(Expression<Func<Asset, bool>> filter = null)
        {
            return await _assetDal.GetList(filter);
        }

        public async Task<Asset> GetByCondition(Expression<Func<Asset, bool>> filter = null)
        {
            return await _assetDal.Get(filter);
        }

        public async Task<Asset> GetByID(int id)
        {
            return await _assetDal.Get(u => u.Id == id);
        }

        public async Task<Asset> Update(Asset asset)
        {
            //ValidatorTool.Validate(new UserValidator(), asset);
            return await _assetDal.Update(asset);
        }
    }
}
