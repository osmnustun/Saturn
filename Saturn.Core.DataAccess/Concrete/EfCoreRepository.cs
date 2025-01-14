
using Microsoft.EntityFrameworkCore;
using Saturn.Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saturn.Core.DataAccess.Concrete
{
    public class EfCoreRepository<TEntity, TContext> : IEfCoreDataAccess<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        readonly TContext _context;

        public EfCoreRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
                     
            await _context.AddAsync<TEntity>(entity);

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            _context.Remove<TEntity>(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<TEntity, bool> predicate)
        {
            var resault= await _context.Set<TEntity>().ToListAsync();
            resault=resault.Where(predicate).ToList();
            return resault;
          
        }

        public async  Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await _context.Set<TEntity>().ToListAsync();
        
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Update(entity); ;
            return entity;
        }
    }
}
