using Microsoft.EntityFrameworkCore;
using PointOfSale.DAL.Context;
using PointOfSale.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly POSContext _context;


        public GenericRepository(POSContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, string properties = "")
        {
            try
            {
                //TEntity entity = await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
                var entity = _context.Set<TEntity>().AsQueryable();
                if (!string.IsNullOrWhiteSpace(properties)) 
                {
                    foreach (var item in properties.Split(','))
                    {
                        entity = entity.Include(item);
                    }
                }

                return await entity.FirstOrDefaultAsync(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null, string properties = "")
        {
            try
            {
                //IQueryable<TEntity> entityList = filter == null ?
                //    _context.Set<TEntity>() :
                //    _context.Set<TEntity>().Where(filter);
                //await _context.SaveChangesAsync(); //TODO: esto esta mal

                var entityList = _context.Set<TEntity>().AsQueryable();
                if (!string.IsNullOrWhiteSpace(properties))
                {
                    foreach (var item in properties.Split(","))
                    {
                        entityList = entityList.Include(item);
                    }
                }

                if (filter != null)
                {
                    return await entityList.Where(filter).ToListAsync();
                }
                return await entityList.ToListAsync();


                //return entityList.ToList(); //.AsQueryable()
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity); //TODO: tambien le hace _context.Update(entity); para que es el Set<TEntity> ????
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> Count()
        {
            try
            {
                return await _context.Set<TEntity>().CountAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
