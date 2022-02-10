using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected readonly ProEventosContext _context;
        internal DbSet<T> dbSet;
        
        public BaseRepository(ProEventosContext context)
        {
            this._context = context;
            this.dbSet = this._context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(T[] entity)
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}