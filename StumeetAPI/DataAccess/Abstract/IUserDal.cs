using StumeetAPI.Core.DataAccess;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
