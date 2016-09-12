using FATEA.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.Repository.Common.Entity
{
    public abstract class EntityCrudRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey> where TEntity : class
    {
        private DbContext _context;

        public EntityCrudRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna uma entidade pelo id passado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity ById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual void DeleteById(TKey id)
        {
            TEntity entity = ById(id);
            Delete(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retorna uma lista de qualquer entidade
        /// para paginacao usar Skip(numer).Take(numero)
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual List<TEntity> Select(Func<TEntity, bool> where = null)
        {
            IEnumerable<TEntity> result = _context.Set<TEntity>();

            if(where != null)
            {
                result = result.Where(where);
            }

            return result.ToList();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
