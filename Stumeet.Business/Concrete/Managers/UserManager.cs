using System;
using System.Collections.Generic;
using System.Text;
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

        public User Add(User user)
        {
            ValidatorTool.Validate(new UserValidator(), user);
            return _userDal.Add(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetByID(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        public User Update(User user)
        {
            ValidatorTool.Validate(new UserValidator(), user);
            return _userDal.Update(user);
        }
    }
}
