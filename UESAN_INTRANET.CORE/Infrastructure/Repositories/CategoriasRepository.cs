using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly VdiIntranet2Context _context;
        public CategoriasRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categorias>> GetAllAsync()
        {
            return await _context.Categorias
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Categorias?> GetByIdAsync(int id)
        {
            return await _context.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CategoriaId == id);
        }

        public async Task<Categorias> CreateAsync(Categorias entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Categorias.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Categorias.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Categorias?> UpdateAsync(Categorias entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.Categorias.FindAsync(entity.CategoriaId);
            if (existing == null)
            {
                return null;
            }

            existing.NombreCategoria = entity.NombreCategoria;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}