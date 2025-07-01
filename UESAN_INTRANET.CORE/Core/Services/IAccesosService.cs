using UESAN_INTRANET.CORE.Core.DTOs;

namespace UESAN_INTRANET.CORE.Core.Services
{
    public interface IAccesosService
    {
        Task<AccesosDTO> CreateAccesoAsync(AccesosDTO accesoDto);
        Task<bool> DeleteAccesoAsync(int id);
        Task<AccesosDTO?> GetAccesoByIdAsync(int id);
        Task<IEnumerable<AccesosDTO>> GetAllAccesosAsync();
        Task<AccesosDTO?> UpdateAccesoAsync(AccesosDTO accesoDto);
    }
}