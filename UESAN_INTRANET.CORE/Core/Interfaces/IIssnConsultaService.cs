using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IIssnConsultaService
    {
        Task<IssnConsultaDTO> CreateAsync(IssnConsultaDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<IssnConsultaDTO>> GetAllAsync();
        Task<IssnConsultaDTO?> GetByIdAsync(int id);
        Task<IssnConsultaDTO?> UpdateAsync(IssnConsultaDTO dto);
    }
}