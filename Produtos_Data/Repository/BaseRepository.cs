using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Produtos_Data.Context;
using Produtos_Domain.Entities;
using Produtos_Domain.Intefaces;

namespace Produtos_Data.Repository
{
    public class BaseRepository<E> : IRepository<E> where E : BaseEntity
    {

        protected readonly MyContext _context;

        private DbSet<E> _dataSet;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataSet = context.Set<E>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _context.Remove(result);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

        public async Task<E> InsertAsync(E entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }
                _dataSet.Add(entity);


                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public async Task<E> SelectAsync(Guid id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<E>> SelectAsync()
        {
            try
            {
                var result = await _dataSet.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<E> UpdateAsync(E entity)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(entity.Id));
                if (result == null)
                    return null;


                _context.Entry(result).CurrentValues.SetValues(entity);

                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

    }
}
