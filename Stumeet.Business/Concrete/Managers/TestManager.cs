using Stumeet.Business.Abstract;
using Stumeet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stumeet.Business.Concrete.Managers
{
    public class TestManager : ITestService
    {
        public Task<Test> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<Test>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Test> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Test> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
