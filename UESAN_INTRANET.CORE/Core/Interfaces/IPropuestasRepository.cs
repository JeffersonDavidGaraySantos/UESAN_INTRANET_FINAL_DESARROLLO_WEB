using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IPropuestasRepository
    {
        Task<Propuestas> CreateAsync(Propuestas entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Propuestas>> GetAllAsync();
        Task<Propuestas?> GetByIdAsync(int id);
        Task<Propuestas?> UpdateAsync(Propuestas entity);
    }
}