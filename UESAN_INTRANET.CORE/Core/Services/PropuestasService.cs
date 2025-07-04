using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.DTOs;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.CORE.Core.Services
{
    public class PropuestasService : IPropuestasService
    {
        private readonly IPropuestasRepository _repository;

        public PropuestasService(IPropuestasRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropuestasDTO>> GetAllAsync()
        {
            var propuestas = await _repository.GetAllAsync();
            return propuestas.Select(p => new PropuestasDTO
            {
                PropuestaId = p.PropuestaId,
                UsuarioId = p.UsuarioId,
                CategoriaId = p.CategoriaId,
                Tema = p.Tema,
                Descripcion = p.Descripcion,
                Incentivo = p.Incentivo
            });
        }

        public async Task<PropuestasDTO?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null)
                return null;

            return new PropuestasDTO
            {
                PropuestaId = p.PropuestaId,
                UsuarioId = p.UsuarioId,
                CategoriaId = p.CategoriaId,
                Tema = p.Tema,
                Descripcion = p.Descripcion,
                Incentivo = p.Incentivo
            };
        }

        public async Task<PropuestasDTO> CreateAsync(PropuestasDTO dto)
        {
            var entity = new Propuestas
            {
                UsuarioId = dto.UsuarioId,
                CategoriaId = dto.CategoriaId,
                Tema = dto.Tema,
                Descripcion = dto.Descripcion,
                Incentivo = dto.Incentivo
            };

            var created = await _repository.CreateAsync(entity);

            return new PropuestasDTO
            {
                PropuestaId = created.PropuestaId,
                UsuarioId = created.UsuarioId,
                CategoriaId = created.CategoriaId,
                Tema = created.Tema,
                Descripcion = created.Descripcion,
                Incentivo = created.Incentivo
            };
        }

        public async Task<PropuestasDTO?> UpdateAsync(PropuestasDTO dto)
        {
            var entity = new Propuestas
            {
                PropuestaId = dto.PropuestaId,
                UsuarioId = dto.UsuarioId,
                CategoriaId = dto.CategoriaId,
                Tema = dto.Tema,
                Descripcion = dto.Descripcion,
                Incentivo = dto.Incentivo
            };

            var updated = await _repository.UpdateAsync(entity);
            if (updated == null)
                return null;

            return new PropuestasDTO
            {
                PropuestaId = updated.PropuestaId,
                UsuarioId = updated.UsuarioId,
                CategoriaId = updated.CategoriaId,
                Tema = updated.Tema,
                Descripcion = updated.Descripcion,
                Incentivo = updated.Incentivo
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
