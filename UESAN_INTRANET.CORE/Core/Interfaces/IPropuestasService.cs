using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IPropuestasService
    {
        Task<PropuestasDTO> CreateAsync(PropuestasDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<PropuestasDTO>> GetAllAsync();
        Task<PropuestasDTO?> GetByIdAsync(int id);
        Task<PropuestasDTO?> UpdateAsync(PropuestasDTO dto);
    }
}