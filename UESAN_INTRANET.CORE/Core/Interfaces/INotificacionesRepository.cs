using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface INotificacionesRepository
    {
        Task<Notificaciones> CreateAsync(Notificaciones entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Notificaciones>> GetAllAsync();
        Task<Notificaciones?> GetByIdAsync(int id);
        Task<Notificaciones?> UpdateAsync(Notificaciones entity);
    }
}