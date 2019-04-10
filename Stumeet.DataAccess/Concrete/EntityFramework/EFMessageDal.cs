using Stumeet.Core.DataAccess.EntityFramework;
using Stumeet.DataAccess.Abstract;
using Stumeet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stumeet.DataAccess.Concrete.EntityFramework
{
    public class EFMessageDal : EfEntityRepositoryBase<Message, StumeetDBContext>, IMessageDal
    {
    }
}
