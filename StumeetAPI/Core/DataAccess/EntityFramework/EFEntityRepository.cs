using Microsoft.EntityFrameworkCore;
using StumeetAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Core.DataAccess.EntityFramework
{
    public class EFEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                    await context.Set<TEntity>().ToListAsync() :
                    await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ?
                    await context.Set<TEntity>().FirstOrDefaultAsync() :
                    await context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
            }
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                if (await context.SaveChangesAsync() > 0)
                    return entity;
                return null;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                if (await context.SaveChangesAsync() > 0)
                    return entity;
                return null;
            }
        }

        public async void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }
}
