using System;
using System.Collections.Generic;
using System.Text;
using Stumeet.Core.DataAccess;
using Stumeet.DataAccess.Concrete;

namespace Stumeet.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
