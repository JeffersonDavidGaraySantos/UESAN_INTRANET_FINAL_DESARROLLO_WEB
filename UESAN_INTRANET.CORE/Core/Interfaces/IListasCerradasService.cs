using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IListasCerradasService
    {
        Task<ListasCerradasDTO> CreateAsync(ListasCerradasDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ListasCerradasDTO>> GetAllAsync();
        Task<ListasCerradasDTO?> GetByIdAsync(int id);
        Task<ListasCerradasDTO?> UpdateAsync(ListasCerradasDTO dto);
    }
}