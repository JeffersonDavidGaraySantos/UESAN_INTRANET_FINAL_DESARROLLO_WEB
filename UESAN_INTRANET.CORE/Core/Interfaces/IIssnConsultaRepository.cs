using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IIssnConsultaRepository
    {
        Task<IssnConsulta> CreateAsync(IssnConsulta entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<IssnConsulta>> GetAllAsync();
        Task<IssnConsulta?> GetByIdAsync(int id);
        Task<IssnConsulta?> UpdateAsync(IssnConsulta entity);
    }
}