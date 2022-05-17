using Eventos.Domain;
using System.Threading.Tasks;

namespace Eventos.Persistence.Interfaces
{
    public interface IPalestrantesPersistence
    {
        #region PALESTRANTES
        Task<Palestrante[]> GettAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GettAllPalestrantesAsync(int palestranteId, bool includeEventos);
        Task<Palestrante> GettAllPalestranteByIdAsync(int palestranteId, bool includeEventos);
        #endregion
    }
}
