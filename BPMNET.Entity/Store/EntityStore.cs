using BPMNET.Core;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity.Store
{
    public class EntityStore<TEntity>
        where TEntity : class
    {
        public DbContext Context { get; private set; }
        public DbSet<TEntity> DbEntitySet { get; private set; }
        public IQueryable<TEntity> EntitySet
        {
            get
            {
                return DbEntitySet;
            }
        }
        public EntityStore(DbContext context)
        {
            Context = context;
            DbEntitySet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            if (entity is ITimeTrail)
                (entity as ITimeTrail).UtcCreatedDate = DateTime.UtcNow;
            DbEntitySet.Add(entity);
        }
        public void Delete(TEntity entity)
        {
            DbEntitySet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity != null)
            {
                if (entity is ITimeTrail)
                    (entity as ITimeTrail).UtcModifiedDate = DateTime.UtcNow;
                Context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
