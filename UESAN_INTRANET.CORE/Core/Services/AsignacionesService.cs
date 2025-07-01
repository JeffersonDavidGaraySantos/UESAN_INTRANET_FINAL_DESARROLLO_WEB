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
    public class AsignacionesService
    {
        private readonly IAsignacionesRepository _asignacionesRepository;

        public AsignacionesService(IAsignacionesRepository asignacionesRepository)
        {
            _asignacionesRepository = asignacionesRepository;
        }

        public async Task<IEnumerable<AsignacionesDTO>> GetAllAsignacionesAsync()
        {
            var asignaciones = await _asignacionesRepository.GetAllAsync();
            return asignaciones.Select(a => new AsignacionesDTO
            {
                AsignacionId = a.AsignacionId,
                UsuarioId = a.UsuarioId,
                ListasCerradasId = a.ListasCerradasId,
                Estado = a.Estado,
                FechaAsignacion = a.FechaAsignacion
            });
        }

        public async Task<AsignacionesDTO?> GetAsignacionByIdAsync(int id)
        {
            var asignacion = await _asignacionesRepository.GetByIdAsync(id);
            if (asignacion == null)
            {
                return null;
            }

            return new AsignacionesDTO
            {
                AsignacionId = asignacion.AsignacionId,
                UsuarioId = asignacion.UsuarioId,
                ListasCerradasId = asignacion.ListasCerradasId,
                Estado = asignacion.Estado,
                FechaAsignacion = asignacion.FechaAsignacion
            };
        }

        public async Task<AsignacionesDTO> CreateAsignacionAsync(AsignacionesDTO dto)
        {
            var entity = new Asignaciones
            {
                UsuarioId = dto.UsuarioId,
                ListasCerradasId = dto.ListasCerradasId,
                Estado = dto.Estado,
                FechaAsignacion = dto.FechaAsignacion
            };

            var created = await _asignacionesRepository.CreateAsync(entity);

            return new AsignacionesDTO
            {
                AsignacionId = created.AsignacionId,
                UsuarioId = created.UsuarioId,
                ListasCerradasId = created.ListasCerradasId,
                Estado = created.Estado,
                FechaAsignacion = created.FechaAsignacion
            };
        }

        public async Task<AsignacionesDTO?> UpdateAsignacionAsync(AsignacionesDTO dto)
        {
            var entity = new Asignaciones
            {
                AsignacionId = dto.AsignacionId,
                UsuarioId = dto.UsuarioId,
                ListasCerradasId = dto.ListasCerradasId,
                Estado = dto.Estado,
                FechaAsignacion = dto.FechaAsignacion
            };

            var updated = await _asignacionesRepository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new AsignacionesDTO
            {
                AsignacionId = updated.AsignacionId,
                UsuarioId = updated.UsuarioId,
                ListasCerradasId = updated.ListasCerradasId,
                Estado = updated.Estado,
                FechaAsignacion = updated.FechaAsignacion
            };
        }

        public async Task<bool> DeleteAsignacionAsync(int id)
        {
            return await _asignacionesRepository.DeleteAsync(id);
        }
    }
}
