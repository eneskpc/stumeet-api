using Stumeet.Core.DataAccess;
using Stumeet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stumeet.DataAccess.Abstract
{
    public interface IMessageDal:IEntityRepository<Message>
    {
    }
}
