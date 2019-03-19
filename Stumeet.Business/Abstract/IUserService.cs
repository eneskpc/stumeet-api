using Stumeet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Stumeet.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetByID(int id);
        User Add(User user);
        User Update(User user);
    }
}
