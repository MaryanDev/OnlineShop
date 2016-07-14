using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Repositories.Abstract
{
    public interface IRepository
    {
        IEnumerable<TEntity> Get<TEntity>(Func<TEntity, bool> criteria = null)  where TEntity : class;
        TEntity GetSingle<TEntity>(Func<TEntity, bool> criteria = null) where TEntity : class;
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(Func<TEntity, bool> criteria) where TEntity : class;
        bool Exists<TEntity>(Func<TEntity, bool> criteria = null) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
