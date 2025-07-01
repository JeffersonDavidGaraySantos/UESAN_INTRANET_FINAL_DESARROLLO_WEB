using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<Usuarios> CreateAsync(Usuarios entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios?> GetByIdAsync(int id);
        Task<Usuarios?> UpdateAsync(Usuarios entity);
    }
}