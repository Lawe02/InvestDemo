using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestDemoLibrary.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        private readonly TContext _context;
        public RepositoryBase(TContext context)
        {

            _context = context;

        }

        public async Task CreateAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await _context.Set<TEntity>().AddRangeAsync(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entity;
            try
            {
                var res = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);


                if (res != null)
                {
                    entity = res;
                    return entity;
                }
                entity = null!;
                return entity;
            }
            catch
            {
                entity = null!;
                return entity;
            }
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> entity;

            try
            {
                var res = _context.Set<TEntity>().Where(expression);

                if (res != null)
                {
                    entity = res;
                    return entity;
                }
                entity = null!;
                return entity;
            }
            catch
            {
                entity = null!;
                return entity;
            }
        }

        public async Task<TEntity?> UpdateAsync(TEntity entityToUpdate)
        {
            TEntity entity;

            try
            {
                var res = _context.Set<TEntity>().Update(entityToUpdate);
                await _context.SaveChangesAsync();


                if (res != null)
                {
                    entity = entityToUpdate;
                    return entity;
                }
                entity = null!;
                return entity;
            }
            catch
            {
                entity = null!;
                return entity;
            };
        }

        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());   
            }
        }

        public async Task DeleteRangeAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entitiesToDelete = _context.Set<TEntity>().Where(expression);
                _context.Set<TEntity>().RemoveRange(entitiesToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
