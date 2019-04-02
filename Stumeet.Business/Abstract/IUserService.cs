using Stumeet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Stumeet.Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetByID(int id);
        Task<User> Add(User user);
        Task<User> Update(User user);
    }
}
