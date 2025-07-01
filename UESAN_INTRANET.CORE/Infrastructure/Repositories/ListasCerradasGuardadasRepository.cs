using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class ListasCerradasGuardadasRepository : IListasCerradasGuardadasRepository
    {
        private readonly VdiIntranet2Context _context;
        public ListasCerradasGuardadasRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ListasCerradasGuardadas>> GetAllAsync()
        {
            return await _context.ListasCerradasGuardadas
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ListasCerradasGuardadas?> GetByIdAsync(int id)
        {
            return await _context.ListasCerradasGuardadas
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.ListasCerradasGuardadasId == id);
        }

        public async Task<ListasCerradasGuardadas> CreateAsync(ListasCerradasGuardadas entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.ListasCerradasGuardadas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ListasCerradasGuardadas.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.ListasCerradasGuardadas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ListasCerradasGuardadas?> UpdateAsync(ListasCerradasGuardadas entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.ListasCerradasGuardadas.FindAsync(entity.ListasCerradasGuardadasId);
            if (existing == null)
            {
                return null;
            }

            existing.UsuarioId = entity.UsuarioId;
            existing.ListasCerradasId = entity.ListasCerradasId;
            existing.FechaGuardado = entity.FechaGuardado;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}