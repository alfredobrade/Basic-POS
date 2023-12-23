using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DAL.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, string properties = "");
        Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null, string properties = "");
        Task<TEntity> Create(TEntity entity);
        Task<bool> Edit(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<int> Count();
    }
}
