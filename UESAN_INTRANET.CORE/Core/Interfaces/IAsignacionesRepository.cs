using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IAsignacionesRepository
    {
        Task<Asignaciones> CreateAsync(Asignaciones entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Asignaciones>> GetAllAsync();
        Task<Asignaciones?> GetByIdAsync(int id);
        Task<Asignaciones?> UpdateAsync(Asignaciones entity);
    }
}