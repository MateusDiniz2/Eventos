using Eventos.Domain;
using System.Threading.Tasks;

namespace Eventos.Persistence.Interfaces
{
    public interface IEventosPersistence
    {
        #region EVENTOS
        Task<Evento[]> GettAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GettAllEventosAsync (bool includePalestrantes = false);
        Task<Evento> GettAllByIdAsync(int EventoId, bool includePalestrantes = false);

        #endregion      
    }
}
