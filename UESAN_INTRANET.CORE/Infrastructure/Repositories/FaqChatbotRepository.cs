using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Infrastructure.Data;

namespace UESAN_INTRANET.CORE.Infrastructure.Repositories
{
    public class FaqChatbotRepository
    {
        private readonly VdiIntranet2Context _context;
        public FaqChatbotRepository(VdiIntranet2Context context)
        {
            _context = context;
        }

        public IEnumerable<FaqChatbot> GetAll()
        {
            return _context.FaqChatbot.ToList();
        }

        public async Task<FaqChatbot?> GetByIdAsync(int id)
        {
            return await _context.FaqChatbot.FindAsync(id);
        }

        public async Task<FaqChatbot> CreateAsync(FaqChatbot entity)
        {
            _context.FaqChatbot.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.FaqChatbot.FindAsync(id);
            if (entity == null)
                return false;
            _context.FaqChatbot.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<FaqChatbot?> UpdateAsync(FaqChatbot entity)
        {
            var existing = await _context.FaqChatbot.FindAsync(entity.Faqid);
            if (existing == null)
                return null;
            existing.PreguntaClave = entity.PreguntaClave;
            existing.Respuesta = entity.Respuesta;
            existing.FechaCreacion = entity.FechaCreacion;
            existing.Visible = entity.Visible;
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}