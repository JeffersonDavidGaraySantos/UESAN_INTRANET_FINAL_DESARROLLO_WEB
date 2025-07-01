using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IRolService
    {
        Task<RolDTO> CreateRolAsync(RolDTO dto);
        Task<bool> DeleteRolAsync(int id);
        Task<IEnumerable<RolDTO>> GetAllRolesAsync();
        Task<RolDTO?> GetRolByIdAsync(int id);
        Task<RolDTO?> UpdateRolAsync(RolDTO dto);
    }
}