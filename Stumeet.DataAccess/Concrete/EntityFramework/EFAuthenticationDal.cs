using System;
using System.Collections.Generic;
using System.Text;
using Stumeet.Core.DataAccess.EntityFramework;
using Stumeet.DataAccess.Abstract;
using Stumeet.Entities.Concrete;

namespace Stumeet.DataAccess.Concrete.EntityFramework
{
    public class EFAuthenticationDal : EfEntityRepositoryBase<Authentication, StumeetDBContext>, IAuthenticationDal
    {
    }
}
