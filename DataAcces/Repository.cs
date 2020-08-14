using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class Repository<T> : IRepository<T>  where T : BaseEntity
    {
        public Context _context { get; }
        private DbSet<T> _entities;
        private string _errorMessage = string.Empty;
        public Repository(Context context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task Delete(T Entity)
        {
            _entities.Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task Insert(T Entity)
        {
            await _entities.AddAsync(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
