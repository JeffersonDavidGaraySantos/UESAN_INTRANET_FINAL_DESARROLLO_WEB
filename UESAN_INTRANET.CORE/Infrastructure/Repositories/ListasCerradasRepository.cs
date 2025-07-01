using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class ListasCerradasRepository : IListasCerradasRepository
    {
        private readonly VdiIntranet2Context _context;
        public ListasCerradasRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ListasCerradas>> GetAllAsync()
        {
            return await _context.ListasCerradas
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ListasCerradas?> GetByIdAsync(int id)
        {
            return await _context.ListasCerradas
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.ListasCerradasId == id);
        }

        public async Task<ListasCerradas> CreateAsync(ListasCerradas entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.ListasCerradas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ListasCerradas.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.ListasCerradas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ListasCerradas?> UpdateAsync(ListasCerradas entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existing = await _context.ListasCerradas.FindAsync(entity.ListasCerradasId);
            if (existing == null)
            {
                return null; // No se encontró el registro para actualizar
            }

            // Opción 1: Actualizar propiedad por propiedad (control explícito)
            existing.Issn = entity.Issn;
            existing.Issn2 = entity.Issn2;
            existing.Issn3 = entity.Issn3;
            existing.Nombre = entity.Nombre;
            existing.CategoriaId = entity.CategoriaId;
            existing.Puntaje = entity.Puntaje;
            existing.IncentivoUsd = entity.IncentivoUsd;
            existing.Scopus = entity.Scopus;
            existing.WoSQ = entity.WoSQ;
            existing.EsciQ = entity.EsciQ;
            existing.Ajg = entity.Ajg;
            existing.Cnrs = entity.Cnrs;
            existing.Abdc = entity.Abdc;
            existing.WoSLatam = entity.WoSLatam;

            await _context.SaveChangesAsync();

            return existing;
        }
    }
}