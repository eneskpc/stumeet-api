using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StumeetAPI.Core.DataAccess.EntityFramework;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;

namespace StumeetAPI.DataAccess.Concrete.EntityFramework
{
    public class EFMessageGroupMemberDal : EFEntityRepository<MessageGroupMember, StumeetDBContext>, IMessageGroupMemberDal
    {
    }
}
