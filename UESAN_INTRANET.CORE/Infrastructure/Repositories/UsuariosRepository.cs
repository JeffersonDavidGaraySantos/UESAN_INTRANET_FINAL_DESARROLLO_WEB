using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly VdiIntranet2Context _context;
        public UsuariosRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _context.Usuarios
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Usuarios?> GetByIdAsync(int id)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<Usuarios> CreateAsync(Usuarios entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuarios?> UpdateAsync(Usuarios entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.Usuarios.FindAsync(entity.UsuarioId);
            if (existing == null)
            {
                return null;
            }

            // Opción campo por campo
            existing.Nombre = entity.Nombre;
            existing.Apellido = entity.Apellido;
            existing.Correo = entity.Correo;
            existing.Contraseña = entity.Contraseña;
            existing.RolId = entity.RolId;
            existing.Estado = entity.Estado;
            existing.FechaRegistro = entity.FechaRegistro;

            await _context.SaveChangesAsync();
            return existing;

            // O bien, opción limpia:
            // _context.Entry(existing).CurrentValues.SetValues(entity);
            // await _context.SaveChangesAsync();
            // return existing;
        }
    }
}