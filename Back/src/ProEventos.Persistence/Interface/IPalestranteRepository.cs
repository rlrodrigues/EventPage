using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface 
{
    public interface IPalestranteRepository : IBaseRepository<Palestrante>
    {  
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool incluirEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluirEventos);
    }
}