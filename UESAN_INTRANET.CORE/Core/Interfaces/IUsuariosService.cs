using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IUsuariosService
    {
        Task<UsuariosDTO> CreateUsuarioAsync(UsuariosDTO dto);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<IEnumerable<UsuariosDTO>> GetAllUsuariosAsync();
        Task<UsuariosDTO?> GetUsuarioByIdAsync(int id);
        Task<UsuariosDTO?> UpdateUsuarioAsync(UsuariosDTO dto);
    }
}