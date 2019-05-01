﻿using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Abstract
{
    public interface IMessageGroupService
    {
        Task<List<MessageGroup>> GetAll(Expression<Func<MessageGroup, bool>> filter = null);
        Task<MessageGroup> GetByID(int id);
        Task<MessageGroup> GetByCondition(Expression<Func<MessageGroup, bool>> filter = null);
        Task<MessageGroup> Add(MessageGroup user);
        Task<MessageGroup> Update(MessageGroup user);
    }
}
