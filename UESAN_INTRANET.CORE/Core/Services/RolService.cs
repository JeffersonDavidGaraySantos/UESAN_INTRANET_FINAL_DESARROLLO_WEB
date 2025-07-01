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
    public class RolService
    {
        private readonly IRolRepository _rolesRepository;

        public RolService(IRolRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<IEnumerable<RolDTO>> GetAllRolesAsync()
        {
            var roles = await _rolesRepository.GetAllAsync();
            return roles.Select(r => new RolDTO
            {
                RolId = r.RolId,
                NombreRol = r.NombreRol
            });
        }

        public async Task<RolDTO?> GetRolByIdAsync(int id)
        {
            var rol = await _rolesRepository.GetByIdAsync(id);
            if (rol == null)
            {
                return null;
            }

            return new RolDTO
            {
                RolId = rol.RolId,
                NombreRol = rol.NombreRol
            };
        }

        public async Task<RolDTO> CreateRolAsync(RolDTO dto)
        {
            var entity = new Rol
            {
                NombreRol = dto.NombreRol
            };

            var created = await _rolesRepository.CreateAsync(entity);

            return new RolDTO
            {
                RolId = created.RolId,
                NombreRol = created.NombreRol
            };
        }

        public async Task<RolDTO?> UpdateRolAsync(RolDTO dto)
        {
            var entity = new Rol
            {
                RolId = dto.RolId,
                NombreRol = dto.NombreRol
            };

            var updated = await _rolesRepository.UpdateAsync(entity);
            if (updated == null)
            {
                return null;
            }

            return new RolDTO
            {
                RolId = updated.RolId,
                NombreRol = updated.NombreRol
            };
        }

        public async Task<bool> DeleteRolAsync(int id)
        {
            return await _rolesRepository.DeleteAsync(id);
        }
    }
}
