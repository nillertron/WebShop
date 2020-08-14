using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public interface IRepository<T> where T:BaseEntity
    {
        Context _context { get; }
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Update(T entity);
        Task Insert(T Entity);
        Task Delete(T Entity);
        Task Save();
    }
}
