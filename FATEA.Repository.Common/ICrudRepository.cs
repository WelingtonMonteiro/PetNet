using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATEA.Repository.Common
{
    public interface ICrudRepository<TEntity, TKey> where TEntity : class
    {
        /// <summary>
        /// Retonar lista de uma entidade onde o comando where é opicional
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<TEntity> Select(Func<TEntity, bool> where = null);
        TEntity ById(TKey id);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteById(TKey id);
    }
}
