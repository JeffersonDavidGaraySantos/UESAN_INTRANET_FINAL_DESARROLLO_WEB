using UESAN_INTRANET.CORE.Core.Entities;

namespace UESAN_INTRANET.CORE.Core.Interfaces
{
    public interface IAccesosFormularioProfesoresRepository
    {
        Task<AccesosFormularioProfesores> CreateAsync(AccesosFormularioProfesores entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AccesosFormularioProfesores>> GetAllAsync();
        Task<AccesosFormularioProfesores?> GetByIdAsync(int id);
        Task<AccesosFormularioProfesores?> UpdateAsync(AccesosFormularioProfesores entity);
    }
}