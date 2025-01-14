using Saturn.Core.Entity.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Abstract
{
    public interface IEfCoreDataAccess<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity,bool> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
