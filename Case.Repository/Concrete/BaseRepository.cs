using Case.Data.Context;
using Case.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Repository.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly CaseContext _context;
        public BaseRepository(CaseContext context)
        {
            _context = context;
        }

        public  async Task<int> Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            var entities = _context.Set<TEntity>() .ToListAsync();

            return await entities;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
