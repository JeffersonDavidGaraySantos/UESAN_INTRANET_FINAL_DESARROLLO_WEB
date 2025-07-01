using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class AccesosFormularioProfesoresRepository : IAccesosFormularioProfesoresRepository
    {
        private readonly VdiIntranet2Context _context;
        public AccesosFormularioProfesoresRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccesosFormularioProfesores>> GetAllAsync()
        {
            return await _context.AccesosFormularioProfesores
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AccesosFormularioProfesores?> GetByIdAsync(int id)
        {
            return await _context.AccesosFormularioProfesores
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccesoId == id);
        }

        public async Task<AccesosFormularioProfesores> CreateAsync(AccesosFormularioProfesores entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.AccesosFormularioProfesores.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.AccesosFormularioProfesores.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.AccesosFormularioProfesores.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<AccesosFormularioProfesores?> UpdateAsync(AccesosFormularioProfesores entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.AccesosFormularioProfesores.FindAsync(entity.AccesoId);
            if (existing == null)
            {
                return null;
            }

            existing.Correos = entity.Correos;
            existing.Trabajador = entity.Trabajador;
            existing.Dni = entity.Dni;
            existing.Categoria = entity.Categoria;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}