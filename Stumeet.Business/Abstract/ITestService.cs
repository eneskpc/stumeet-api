using Stumeet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stumeet.Business.Abstract
{
    public interface ITestService
    {
        Task<List<Test>> GetAll();
        Task<Test> GetByID(int id);
        Task<Test> Add(User user);
        Task<Test> Update(User user);
    }
}
