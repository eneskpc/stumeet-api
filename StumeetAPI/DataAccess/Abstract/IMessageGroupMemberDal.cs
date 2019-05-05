using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StumeetAPI.Core.DataAccess;
using StumeetAPI.Entities.Concrete;

namespace StumeetAPI.DataAccess.Abstract
{
    public interface IMessageGroupMemberDal: IEntityRepository<MessageGroupMember>
    {
    }
}
