using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.DTOs;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class PropuestasRepository : IPropuestasRepository
    {
        private readonly VdiIntranet2Context _context;

        public PropuestasRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Propuestas>> GetAllAsync()
        {
            return await _context.Propuestas.ToListAsync();
        }

        public async Task<Propuestas?> GetByIdAsync(int id)
        {
            return await _context.Propuestas.FindAsync(id);
        }

        public async Task<Propuestas> CreateAsync(Propuestas entity)
        {
            _context.Propuestas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Propuestas?> UpdateAsync(Propuestas entity)
        {
            var existing = await _context.Propuestas.FindAsync(entity.PropuestaId);
            if (existing == null)
                return null;

            existing.UsuarioId = entity.UsuarioId;
            existing.CategoriaId = entity.CategoriaId;
            existing.Tema = entity.Tema;
            existing.Descripcion = entity.Descripcion;
            existing.Incentivo = entity.Incentivo;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Propuestas.FindAsync(id);
            if (existing == null)
                return false;

            _context.Propuestas.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
