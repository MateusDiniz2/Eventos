using Eventos.Domain;
using System.Threading.Tasks;

namespace Eventos.Persistence.Interfaces
{
    public interface IEventosPersistence
    {
        #region EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync (bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false);

        #endregion      
    }
}
