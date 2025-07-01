using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IRolesRepository
    {
        Task<Roles> CreateAsync(Roles entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Roles>> GetAllAsync();
        Task<Roles?> GetByIdAsync(int id);
        Task<Roles?> UpdateAsync(Roles entity);
    }
}