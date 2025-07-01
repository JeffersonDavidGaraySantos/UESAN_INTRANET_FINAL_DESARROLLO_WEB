using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class AsignacionesRepository : IAsignacionesRepository
    {
        private readonly VdiIntranet2Context _context;
        public AsignacionesRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asignaciones>> GetAllAsync()
        {
            return await _context.Asignaciones
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Asignaciones?> GetByIdAsync(int id)
        {
            return await _context.Asignaciones
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AsignacionId == id);
        }

        public async Task<Asignaciones> CreateAsync(Asignaciones entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Asignaciones.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Asignaciones.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Asignaciones.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Asignaciones?> UpdateAsync(Asignaciones entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.Asignaciones.FindAsync(entity.AsignacionId);
            if (existing == null)
            {
                return null;
            }

            existing.UsuarioId = entity.UsuarioId;
            existing.ListasCerradasId = entity.ListasCerradasId;
            existing.Estado = entity.Estado;
            existing.FechaAsignacion = entity.FechaAsignacion;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}