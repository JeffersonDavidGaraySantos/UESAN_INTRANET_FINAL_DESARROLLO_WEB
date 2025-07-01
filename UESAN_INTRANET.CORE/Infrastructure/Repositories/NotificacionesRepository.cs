using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class NotificacionesRepository : INotificacionesRepository
    {
        private readonly VdiIntranet2Context _context;
        public NotificacionesRepository(VdiIntranet2Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Notificaciones>> GetAllAsync()
        {
            return await _context.Notificaciones
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Notificaciones?> GetByIdAsync(int id)
        {
            return await _context.Notificaciones
                .AsNoTracking()
                .FirstOrDefaultAsync(n => n.NotificacionId == id);
        }

        public async Task<Notificaciones> CreateAsync(Notificaciones entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Notificaciones.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Notificaciones.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Notificaciones.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Notificaciones?> UpdateAsync(Notificaciones entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.Notificaciones.FindAsync(entity.NotificacionId);
            if (existing == null)
            {
                return null; // No se encontró el registro
            }

            existing.UsuarioId = entity.UsuarioId;
            existing.Mensaje = entity.Mensaje;
            existing.FechaEnvio = entity.FechaEnvio;
            existing.Leido = entity.Leido;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}