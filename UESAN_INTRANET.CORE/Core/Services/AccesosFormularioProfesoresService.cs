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
    public class AccesosFormularioProfesoresService : IAccesosFormularioProfesoresService
    {
        private readonly IAccesosFormularioProfesoresRepository _repository;

        public AccesosFormularioProfesoresService(IAccesosFormularioProfesoresRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AccesosFormularioProfesoresDTO>> GetAllAsync()
        {
            var accesos = await _repository.GetAllAsync();
            return accesos.Select(a => new AccesosFormularioProfesoresDTO
            {
                AccesoId = a.AccesoId,
                Correos = a.Correos,
                Trabajador = a.Trabajador,
                Dni = a.Dni,
                Categoria = a.Categoria
            });
        }

        public async Task<AccesosFormularioProfesoresDTO?> GetByIdAsync(int id)
        {
            var acceso = await _repository.GetByIdAsync(id);
            if (acceso == null)
            {
                return null;
            }

            return new AccesosFormularioProfesoresDTO
            {
                AccesoId = acceso.AccesoId,
                Correos = acceso.Correos,
                Trabajador = acceso.Trabajador,
                Dni = acceso.Dni,
                Categoria = acceso.Categoria
            };
        }

        public async Task<AccesosFormularioProfesoresDTO> CreateAsync(AccesosFormularioProfesoresDTO dto)
        {
            var entity = new AccesosFormularioProfesores
            {
                Correos = dto.Correos,
                Trabajador = dto.Trabajador,
                Dni = dto.Dni,
                Categoria = dto.Categoria
            };

            var created = await _repository.CreateAsync(entity);

            return new AccesosFormularioProfesoresDTO
            {
                AccesoId = created.AccesoId,
                Correos = created.Correos,
                Trabajador = created.Trabajador,
                Dni = created.Dni,
                Categoria = created.Categoria
            };
        }

        public async Task<AccesosFormularioProfesoresDTO?> UpdateAsync(AccesosFormularioProfesoresDTO dto)
        {
            var entity = new AccesosFormularioProfesores
            {
                AccesoId = dto.AccesoId,
                Correos = dto.Correos,
                Trabajador = dto.Trabajador,
                Dni = dto.Dni,
                Categoria = dto.Categoria
            };

            var updated = await _repository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new AccesosFormularioProfesoresDTO
            {
                AccesoId = updated.AccesoId,
                Correos = updated.Correos,
                Trabajador = updated.Trabajador,
                Dni = updated.Dni,
                Categoria = updated.Categoria
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
