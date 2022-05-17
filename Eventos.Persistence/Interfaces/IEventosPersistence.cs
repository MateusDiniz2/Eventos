using Eventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Persistence.Interfaces
{
    public interface IEventosPersistence
    {
        #region GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        #endregion

        #region EVENTOS
        Task<Evento[]> GettAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GettAllEventosAsync (bool includePalestrantes);
        Task<Evento> GettAllEventosByIdAsync(int EventoId, bool includePalestrantes);

        #endregion

        #region PALESTRANTES
        Task<Palestrante[]> GettAllPalestrantesByIdAsync(int id, bool includeEventos);
        Task<Palestrante[]> GettAllPalestrantesAsync(int id, bool includeEventos);
        Task<Palestrante> GettAllPalestranteByIdAsync(int id, bool includeEventos);
        #endregion
    }
}
