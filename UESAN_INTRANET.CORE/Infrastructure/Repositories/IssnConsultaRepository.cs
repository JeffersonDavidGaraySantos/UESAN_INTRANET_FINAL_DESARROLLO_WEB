using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class IssnConsultaRepository : IIssnConsultaRepository
    {
        private readonly VdiIntranet2Context _context;
        public IssnConsultaRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IssnConsulta>> GetAllAsync()
        {
            return await _context.IssnConsulta
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IssnConsulta?> GetByIdAsync(int id)
        {
            return await _context.IssnConsulta
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.IssnConsultaId == id);
        }

        public async Task<IssnConsulta> CreateAsync(IssnConsulta entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.IssnConsulta.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.IssnConsulta.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.IssnConsulta.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IssnConsulta?> UpdateAsync(IssnConsulta entity)
        {
            var existing = await _context.IssnConsulta.FindAsync(entity.IssnConsultaId);
            if (existing == null)
                return null;
            existing.Issn = entity.Issn;
            existing.Nombre = entity.Nombre;
            existing.Scopus = entity.Scopus;
            existing.WoSQ = entity.WoSQ;
            existing.WoSS = entity.WoSS;
            existing.WoSEsci = entity.WoSEsci;
            existing.EsciQ = entity.EsciQ;
            existing.Ajg4 = entity.Ajg4;
            existing.Ajg = entity.Ajg;
            existing.AjgS = entity.AjgS;
            existing.Cnrs = entity.Cnrs;
            existing.CnrsS = entity.CnrsS;
            existing.Abdc = entity.Abdc;
            existing.AbdcS = entity.AbdcS;
            existing.AlMenosEnUnaLista = entity.AlMenosEnUnaLista;
            existing.SoloEnUnaLista = entity.SoloEnUnaLista;
            existing.Scielo = entity.Scielo;
            existing.WoSLatam = entity.WoSLatam;
            existing.Top50 = entity.Top50;
            existing.N = entity.N;
            existing.BeallsList = entity.BeallsList;
            existing.Mdpi = entity.Mdpi;
            existing.Insights = entity.Insights;
            existing.AjgExiste = entity.AjgExiste;
            existing.CnrsExiste = entity.CnrsExiste;
            existing.AbdcExiste = entity.AbdcExiste;
            existing.WoSTopExiste = entity.WoSTopExiste;
            existing.WoSEsciExiste = entity.WoSEsciExiste;
            existing.ScopusExiste = entity.ScopusExiste;
            existing.SoloScieloExiste = entity.SoloScieloExiste;
            existing.Especial216b = entity.Especial216b;
            existing.LatamSinEsciExiste = entity.LatamSinEsciExiste;
            existing.EsciScieloSinScopus = entity.EsciScieloSinScopus;
            existing.Multiple = entity.Multiple;
            existing.MultidisciplinaryWos = entity.MultidisciplinaryWos;
            existing.CoautoriaEsan = entity.CoautoriaEsan;
            existing.MultyYAlMenosUnaLista = entity.MultyYAlMenosUnaLista;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}