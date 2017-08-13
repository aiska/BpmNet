using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BPMNET.Entity
{
    internal class EntityStore<TEntity> 
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
        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return DbEntitySet.FindAsync(new object[]
			{
				id
			});
        }

        public virtual TEntity GetById(object id)
        {
            return DbEntitySet.Find(new object[]
			{
				id
			});
        }

        public void Create(TEntity entity)
        {
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
                Context.Entry<TEntity>(entity).State = EntityState.Modified;
            }
        }
    }
}
