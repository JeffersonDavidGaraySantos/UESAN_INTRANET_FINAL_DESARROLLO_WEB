using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IRolRepository
    {
        Task<Rol> CreateAsync(Rol entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task<Rol?> UpdateAsync(Rol entity);
    }
}