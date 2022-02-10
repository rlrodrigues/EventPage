using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence.Repositories;

namespace ProEventos.Persistence.Interface 
{
    public interface IEventoRepository : IBaseRepository<Evento>
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrante);
    }
}