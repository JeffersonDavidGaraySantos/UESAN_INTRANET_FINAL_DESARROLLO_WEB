using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _rolesRepository.GetAllAsync();
            return Ok(roles);
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol(int id)
        {
            var rol = await _rolesRepository.GetByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] Roles rol)
        {
            if (rol == null)
            {
                return BadRequest("Rol cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdRol = await _rolesRepository.CreateAsync(rol);
            return CreatedAtAction(nameof(GetRol), new { id = createdRol.RolId }, createdRol);
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, [FromBody] Roles rol)
        {
            if (rol == null || id != rol.RolId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRol = await _rolesRepository.GetByIdAsync(id);
            if (existingRol == null)
            {
                return NotFound();
            }

            var updatedRol = await _rolesRepository.UpdateAsync(rol);
            if (updatedRol == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating role record");
            }

            return Ok(updatedRol);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var deleted = await _rolesRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
