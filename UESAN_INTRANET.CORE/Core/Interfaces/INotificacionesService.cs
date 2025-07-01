using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface INotificacionesService
    {
        Task<NotificacionesDTO> CreateNotificacionAsync(NotificacionesDTO dto);
        Task<bool> DeleteNotificacionAsync(int id);
        Task<IEnumerable<NotificacionesDTO>> GetAllNotificacionesAsync();
        Task<NotificacionesDTO?> GetNotificacionByIdAsync(int id);
        Task<NotificacionesDTO?> UpdateNotificacionAsync(NotificacionesDTO dto);
    }
}