using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IListasCerradasGuardadasService
    {
        Task<ListasCerradasGuardadasDTO> CreateAsync(ListasCerradasGuardadasDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ListasCerradasGuardadasDTO>> GetAllAsync();
        Task<ListasCerradasGuardadasDTO?> GetByIdAsync(int id);
        Task<ListasCerradasGuardadasDTO?> UpdateAsync(ListasCerradasGuardadasDTO dto);
    }
}