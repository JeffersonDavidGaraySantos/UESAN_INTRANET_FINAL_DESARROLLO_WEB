using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IAsignacionesService
    {
        Task<AsignacionesDTO> CreateAsignacionAsync(AsignacionesDTO dto);
        Task<bool> DeleteAsignacionAsync(int id);
        Task<IEnumerable<AsignacionesDTO>> GetAllAsignacionesAsync();
        Task<AsignacionesDTO?> GetAsignacionByIdAsync(int id);
        Task<AsignacionesDTO?> UpdateAsignacionAsync(AsignacionesDTO dto);
    }
}