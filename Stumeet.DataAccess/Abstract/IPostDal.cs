﻿using System;
using System.Collections.Generic;
using System.Text;
using Stumeet.Core.DataAccess;
using Stumeet.Entities.Concrete;

namespace Stumeet.DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
    }
}
