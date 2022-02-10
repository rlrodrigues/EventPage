using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interface
{
    public interface IPalestranteService
    {
        Task<Palestrante> AddPalestrante(Palestrante model);
        Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model);
        Task<bool> DeletePalestrante(int palestranteId);

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluirEventos);
    }
}