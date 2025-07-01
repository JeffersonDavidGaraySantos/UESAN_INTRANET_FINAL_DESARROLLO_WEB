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
    public class NotificacionesService
    {
        private readonly INotificacionesRepository _notificacionesRepository;

        public NotificacionesService(INotificacionesRepository notificacionesRepository)
        {
            _notificacionesRepository = notificacionesRepository;
        }

        public async Task<IEnumerable<NotificacionesDTO>> GetAllNotificacionesAsync()
        {
            var notificaciones = await _notificacionesRepository.GetAllAsync();
            return notificaciones.Select(n => new NotificacionesDTO
            {
                NotificacionId = n.NotificacionId,
                UsuarioId = n.UsuarioId,
                Mensaje = n.Mensaje,
                FechaEnvio = n.FechaEnvio,
                Leido = n.Leido
            });
        }

        public async Task<NotificacionesDTO?> GetNotificacionByIdAsync(int id)
        {
            var notificacion = await _notificacionesRepository.GetByIdAsync(id);
            if (notificacion == null)
            {
                return null;
            }

            return new NotificacionesDTO
            {
                NotificacionId = notificacion.NotificacionId,
                UsuarioId = notificacion.UsuarioId,
                Mensaje = notificacion.Mensaje,
                FechaEnvio = notificacion.FechaEnvio,
                Leido = notificacion.Leido
            };
        }

        public async Task<NotificacionesDTO> CreateNotificacionAsync(NotificacionesDTO dto)
        {
            var entity = new Notificaciones
            {
                UsuarioId = dto.UsuarioId,
                Mensaje = dto.Mensaje,
                FechaEnvio = dto.FechaEnvio,
                Leido = dto.Leido
            };

            var created = await _notificacionesRepository.CreateAsync(entity);

            return new NotificacionesDTO
            {
                NotificacionId = created.NotificacionId,
                UsuarioId = created.UsuarioId,
                Mensaje = created.Mensaje,
                FechaEnvio = created.FechaEnvio,
                Leido = created.Leido
            };
        }

        public async Task<NotificacionesDTO?> UpdateNotificacionAsync(NotificacionesDTO dto)
        {
            var entity = new Notificaciones
            {
                NotificacionId = dto.NotificacionId,
                UsuarioId = dto.UsuarioId,
                Mensaje = dto.Mensaje,
                FechaEnvio = dto.FechaEnvio,
                Leido = dto.Leido
            };

            var updated = await _notificacionesRepository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new NotificacionesDTO
            {
                NotificacionId = updated.NotificacionId,
                UsuarioId = updated.UsuarioId,
                Mensaje = updated.Mensaje,
                FechaEnvio = updated.FechaEnvio,
                Leido = updated.Leido
            };
        }

        public async Task<bool> DeleteNotificacionAsync(int id)
        {
            return await _notificacionesRepository.DeleteAsync(id);
        }
    }
}
