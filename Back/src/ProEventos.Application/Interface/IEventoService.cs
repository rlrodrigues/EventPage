using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Application.Interface
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEnvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrante);
    }
}