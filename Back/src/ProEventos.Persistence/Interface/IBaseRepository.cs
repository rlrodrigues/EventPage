using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface 
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(T[] entity);

        Task<bool> SaveChangesAsync();
    }
}