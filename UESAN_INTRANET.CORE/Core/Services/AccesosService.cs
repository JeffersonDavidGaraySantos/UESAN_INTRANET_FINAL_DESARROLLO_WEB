using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN_INTRANET.CORE.Core.DTOs;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.CORE.Core.Services
{
    public class AccesosService : IAccesosService
    {
        private readonly IAccesosRepository _accesosRepository;

        public AccesosService(IAccesosRepository accesosRepository)
        {
            _accesosRepository = accesosRepository;
        }

        public async Task<IEnumerable<AccesosDTO>> GetAllAccesosAsync()
        {
            var accesos = await _accesosRepository.GetAllAccesosAsync();
            return accesos.Select(a => new AccesosDTO
            {
                AccesoId = a.AccesoId,
                UsuarioId = a.UsuarioId,
                FechaHoraAcceso = a.FechaHoraAcceso
            });
        }

        public async Task<AccesosDTO?> GetAccesoByIdAsync(int id)
        {
            var acceso = await _accesosRepository.GetAccesoByIdAsync(id);
            if (acceso == null)
            {
                return null;
            }
            return new AccesosDTO
            {
                AccesoId = acceso.AccesoId,
                UsuarioId = acceso.UsuarioId,
                FechaHoraAcceso = acceso.FechaHoraAcceso
            };
        }

        public async Task<AccesosDTO> CreateAccesoAsync(AccesosDTO accesoDto)
        {
            var acceso = new Accesos
            {
                UsuarioId = accesoDto.UsuarioId,
                FechaHoraAcceso = accesoDto.FechaHoraAcceso
            };
            var createdAcceso = await _accesosRepository.CreateAccesoAsync(acceso);
            return new AccesosDTO
            {
                AccesoId = createdAcceso.AccesoId,
                UsuarioId = createdAcceso.UsuarioId,
                FechaHoraAcceso = createdAcceso.FechaHoraAcceso
            };
        }

        public async Task<AccesosDTO?> UpdateAccesoAsync(AccesosDTO accesoDto)
        {
            var acceso = new Accesos
            {
                AccesoId = accesoDto.AccesoId, // Ensure AccesoId is not null for update
                UsuarioId = accesoDto.UsuarioId,
                FechaHoraAcceso = accesoDto.FechaHoraAcceso
            };
            var updatedAcceso = await _accesosRepository.UpdateAccesoAsync(acceso);
            if (updatedAcceso == null)
            {
                return null;
            }
            return new AccesosDTO
            {
                AccesoId = updatedAcceso.AccesoId,
                UsuarioId = updatedAcceso.UsuarioId,
                FechaHoraAcceso = updatedAcceso.FechaHoraAcceso
            };

        }


        public async Task<bool> DeleteAccesoAsync(int id)
        {
            return await _accesosRepository.DeleteAccesoAsync(id);
        }

    }

}
