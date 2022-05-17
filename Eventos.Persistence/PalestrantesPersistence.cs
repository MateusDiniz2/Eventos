using Eventos.Domain;
using Eventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantesPersistence
    {
        private readonly EventosContext _context;
        public PalestrantesPersistence(EventosContext context)
        {
            _context = context;
        }
        public async Task<Palestrante[]> GettAllPalestrantesAsync(int id, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                                .Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query
                      .Include(p => p.PalestrantesEventos)
                      .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GettAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                     .Include(p => p.RedesSociais);
            if (includeEventos)
            {
                query = query
                      .Include(p => p.PalestrantesEventos)
                      .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GettAllPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                          .Include(p => p.RedesSociais);

            if (includeEventos)
            {
                query = query
                      .Include(p => p.PalestrantesEventos)
                      .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
