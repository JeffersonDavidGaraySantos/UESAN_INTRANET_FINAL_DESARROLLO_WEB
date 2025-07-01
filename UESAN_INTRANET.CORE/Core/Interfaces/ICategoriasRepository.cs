using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface ICategoriasRepository
    {
        Task<Categorias> CreateAsync(Categorias entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Categorias>> GetAllAsync();
        Task<Categorias?> GetByIdAsync(int id);
        Task<Categorias?> UpdateAsync(Categorias entity);
    }
}