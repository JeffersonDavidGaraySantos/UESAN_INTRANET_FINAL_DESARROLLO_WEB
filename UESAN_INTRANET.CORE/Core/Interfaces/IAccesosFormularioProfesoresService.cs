using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IAccesosFormularioProfesoresService
    {
        Task<AccesosFormularioProfesoresDTO> CreateAsync(AccesosFormularioProfesoresDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AccesosFormularioProfesoresDTO>> GetAllAsync();
        Task<AccesosFormularioProfesoresDTO?> GetByIdAsync(int id);
        Task<AccesosFormularioProfesoresDTO?> UpdateAsync(AccesosFormularioProfesoresDTO dto);
    }
}