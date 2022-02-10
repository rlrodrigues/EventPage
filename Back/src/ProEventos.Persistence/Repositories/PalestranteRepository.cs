using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;
using ProEventos.Persistence.Repositories;

namespace ProEventos.Persistence
{
    public class PalestranteRepository : BaseRepository<Palestrante>, IPalestranteRepository
    {
        public PalestranteRepository(ProEventosContext context) : base(context) {}
        
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(incluirEventos)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Eventos);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(incluirEventos)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Eventos);

            query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(incluirEventos)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Eventos);

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}