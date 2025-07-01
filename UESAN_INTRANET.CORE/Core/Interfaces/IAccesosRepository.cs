using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IAccesosRepository
    {
        Task<Accesos> CreateAccesoAsync(Accesos acceso);
        Task<bool> DeleteAccesoAsync(int id);
        Task<Accesos?> GetAccesoByIdAsync(int id);
        Task<IEnumerable<Accesos>> GetAllAccesosAsync();
        Task<Accesos?> UpdateAccesoAsync(Accesos acceso);
    }
}