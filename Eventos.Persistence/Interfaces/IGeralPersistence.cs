using System.Threading.Tasks;

namespace Eventos.Persistence.Interfaces
{
    public interface IGeralPersistence 
    {
        #region GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        #endregion
    }
}
