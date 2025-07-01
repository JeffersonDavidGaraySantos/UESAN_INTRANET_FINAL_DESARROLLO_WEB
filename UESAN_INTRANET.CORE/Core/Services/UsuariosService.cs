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
    public class UsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosService(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task<IEnumerable<UsuariosDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuariosRepository.GetAllAsync();
            return usuarios.Select(u => new UsuariosDTO
            {
                UsuarioId = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Correo = u.Correo,
                RolId = u.RolId,
                Estado = u.Estado,
                FechaRegistro = u.FechaRegistro
            });
        }

        public async Task<UsuariosDTO?> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuariosRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return null;
            }

            return new UsuariosDTO
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                RolId = usuario.RolId,
                Estado = usuario.Estado,
                FechaRegistro = usuario.FechaRegistro
            };
        }

        public async Task<UsuariosDTO> CreateUsuarioAsync(UsuariosDTO dto)
        {
            var entity = new Usuarios
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Contraseña = "", // Puedes ajustar esto: ¿quieres recibir la contraseña en un DTO separado?
                RolId = dto.RolId,
                Estado = dto.Estado,
                FechaRegistro = dto.FechaRegistro
            };

            var created = await _usuariosRepository.CreateAsync(entity);

            return new UsuariosDTO
            {
                UsuarioId = created.UsuarioId,
                Nombre = created.Nombre,
                Apellido = created.Apellido,
                Correo = created.Correo,
                RolId = created.RolId,
                Estado = created.Estado,
                FechaRegistro = created.FechaRegistro
            };
        }

        public async Task<UsuariosDTO?> UpdateUsuarioAsync(UsuariosDTO dto)
        {
            var entity = new Usuarios
            {
                UsuarioId = dto.UsuarioId,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Correo = dto.Correo,
                Contraseña = "", // Igual que arriba, depende cómo lo manejes
                RolId = dto.RolId,
                Estado = dto.Estado,
                FechaRegistro = dto.FechaRegistro
            };

            var updated = await _usuariosRepository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new UsuariosDTO
            {
                UsuarioId = updated.UsuarioId,
                Nombre = updated.Nombre,
                Apellido = updated.Apellido,
                Correo = updated.Correo,
                RolId = updated.RolId,
                Estado = updated.Estado,
                FechaRegistro = updated.FechaRegistro
            };
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            return await _usuariosRepository.DeleteAsync(id);
        }
    }
}
