using UESAN_INTRANET.CORE.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IListasCerradasGuardadasRepository
    {
        Task<ListasCerradasGuardadas> CreateAsync(ListasCerradasGuardadas entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ListasCerradasGuardadas>> GetAllAsync();
        Task<ListasCerradasGuardadas?> GetByIdAsync(int id);
        Task<ListasCerradasGuardadas?> UpdateAsync(ListasCerradasGuardadas entity);

        // NUEVO: Eliminar por usuario y revista
        Task<bool> DeleteByUsuarioYRevistaAsync(int usuarioId, int listasCerradasId);
    }
}