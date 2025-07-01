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
    public class CategoriasService
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriasService(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        public async Task<IEnumerable<CategoriasDTO>> GetAllCategoriasAsync()
        {
            var categorias = await _categoriasRepository.GetAllAsync();
            return categorias.Select(c => new CategoriasDTO
            {
                CategoriaId = c.CategoriaId,
                NombreCategoria = c.NombreCategoria
            });
        }

        public async Task<CategoriasDTO?> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriasRepository.GetByIdAsync(id);
            if (categoria == null)
            {
                return null;
            }

            return new CategoriasDTO
            {
                CategoriaId = categoria.CategoriaId,
                NombreCategoria = categoria.NombreCategoria
            };
        }

        public async Task<CategoriasDTO> CreateCategoriaAsync(CategoriasDTO dto)
        {
            var entity = new Categorias
            {
                NombreCategoria = dto.NombreCategoria
            };

            var created = await _categoriasRepository.CreateAsync(entity);

            return new CategoriasDTO
            {
                CategoriaId = created.CategoriaId,
                NombreCategoria = created.NombreCategoria
            };
        }

        public async Task<CategoriasDTO?> UpdateCategoriaAsync(CategoriasDTO dto)
        {
            var entity = new Categorias
            {
                CategoriaId = dto.CategoriaId,
                NombreCategoria = dto.NombreCategoria
            };

            var updated = await _categoriasRepository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new CategoriasDTO
            {
                CategoriaId = updated.CategoriaId,
                NombreCategoria = updated.NombreCategoria
            };
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            return await _categoriasRepository.DeleteAsync(id);
        }
    }
}
