using Eventos.Domain;
using System.Threading.Tasks;

namespace Eventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GettAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GettAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GettAllEventosByIdAsync(int EventoId, bool includePalestrantes = false);
    }
}
