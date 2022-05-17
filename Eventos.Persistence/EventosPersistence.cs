using Eventos.Domain;
using Eventos.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Persistence
{
    public class EventosPersistence : IEventosPersistence
    {
        private readonly EventosContext _context;
        public EventosPersistence(EventosContext context)
        {
             _context = context;   
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GettAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                                                       .Include(e => e.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                             .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GettAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes)
                                                       .Include(e => e.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                             .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }
    
        public async Task<Evento> GettAllEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                               .Include(e => e.Lotes)
                                               .Include(e => e.RedesSociais);
            if (includePalestrantes)
            {
                query = query.Include(e => e.PalestrantesEventos)
                             .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == EventoId);
            
            return await query.FirstOrDefaultAsync();
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
