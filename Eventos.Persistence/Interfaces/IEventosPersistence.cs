using Eventos.Domain;
using System.Threading.Tasks;

namespace Eventos.Persistence.Interfaces
{
    public interface IEventosPersistence
    {
        #region EVENTOS
        Task<Evento[]> GettAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GettAllEventosAsync (bool includePalestrantes);
        Task<Evento> GettAllEventosByIdAsync(int EventoId, bool includePalestrantes);

        #endregion      
    }
}
