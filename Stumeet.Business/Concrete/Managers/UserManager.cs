using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Stumeet.Business.Abstract;
using Stumeet.Business.ValidationRules.FluentValidation;
using Stumeet.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Stumeet.DataAccess.Abstract;
using Stumeet.Entities.Concrete;

namespace Stumeet.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<User> Add(User user)
        {
            ValidatorTool.Validate(new UserValidator(), user); 
            return await _userDal.Add(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userDal.GetList();
        }

        public async Task<User> GetByID(int id)
        {
            return await _userDal.Get(u => u.Id == id);
        }

        public async Task<User> Update(User user)
        {
            ValidatorTool.Validate(new UserValidator(), user);
            return await _userDal.Update(user);
        }
    }
}
