using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IListasCerradasRepository
    {
        Task<ListasCerradas> CreateAsync(ListasCerradas entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ListasCerradas>> GetAllAsync();
        Task<ListasCerradas?> GetByIdAsync(int id);
        Task<ListasCerradas?> UpdateAsync(ListasCerradas entity);
    }
}