using StumeetAPI.DTOs;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetByID(int id);
        Task<User> GetByCondition(Expression<Func<User, bool>> filter = null);
        Task<User> Add(User user);
        Task<User> Update(User user);
        string CreateToken(User user);
        Task<User> Login(UserForLogin userForLogin);
        Task<User> Register(UserForRegister userForRegister);
    }
}
