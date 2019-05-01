using StumeetAPI.Core.DataAccess.EntityFramework;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.DataAccess.Concrete.EntityFramework
{
    public class EFDeletedMessageDal : EFEntityRepository<DeletedMessage, StumeetDBContext>, IDeletedMessageDal
    {
    }
}
