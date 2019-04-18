using Microsoft.EntityFrameworkCore;
using StumeetAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.Core.DataAccess.EntityFramework
{
    public class EFQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<T> _entities;

        public EFQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this.Entities;

        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
    }
}
