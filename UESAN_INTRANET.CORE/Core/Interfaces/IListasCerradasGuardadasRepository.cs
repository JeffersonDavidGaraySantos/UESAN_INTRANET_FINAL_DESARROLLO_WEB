using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IListasCerradasGuardadasRepository
    {
        Task<ListasCerradasGuardadas> CreateAsync(ListasCerradasGuardadas entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ListasCerradasGuardadas>> GetAllAsync();
        Task<ListasCerradasGuardadas?> GetByIdAsync(int id);
        Task<ListasCerradasGuardadas?> UpdateAsync(ListasCerradasGuardadas entity);
    }
}