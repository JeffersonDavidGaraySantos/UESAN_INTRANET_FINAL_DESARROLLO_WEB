using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly VdiIntranet2Context _context;
        public RolesRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _context.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Roles?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RolId == id);
        }

        public async Task<Roles> CreateAsync(Roles entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Roles.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Roles.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Roles.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Roles?> UpdateAsync(Roles entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.Roles.FindAsync(entity.RolId);
            if (existing == null)
            {
                return null;
            }

            // Actualiza de manera limpia (solo NombreRol, porque es el único campo editable)
            existing.NombreRol = entity.NombreRol;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}