using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface ICategoriasService
    {
        Task<CategoriasDTO> CreateCategoriaAsync(CategoriasDTO dto);
        Task<bool> DeleteCategoriaAsync(int id);
        Task<IEnumerable<CategoriasDTO>> GetAllCategoriasAsync();
        Task<CategoriasDTO?> GetCategoriaByIdAsync(int id);
        Task<CategoriasDTO?> UpdateCategoriaAsync(CategoriasDTO dto);
    }
}