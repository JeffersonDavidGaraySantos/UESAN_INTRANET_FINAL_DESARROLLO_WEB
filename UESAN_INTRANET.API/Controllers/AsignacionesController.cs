using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionesController : ControllerBase
    {
        private readonly IAsignacionesRepository _asignacionesRepository;

        public AsignacionesController(IAsignacionesRepository asignacionesRepository)
        {
            _asignacionesRepository = asignacionesRepository;
        }

        // GET: api/Asignaciones
        [HttpGet]
        public async Task<IActionResult> GetAsignaciones()
        {
            var asignaciones = await _asignacionesRepository.GetAllAsync();
            return Ok(asignaciones);
        }

        // GET: api/Asignaciones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsignacion(int id)
        {
            var asignacion = await _asignacionesRepository.GetByIdAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            return Ok(asignacion);
        }

        // POST: api/Asignaciones
        [HttpPost]
        public async Task<IActionResult> PostAsignacion([FromBody] Asignaciones asignacion)
        {
            if (asignacion == null)
            {
                return BadRequest("Asignacion cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAsignacion = await _asignacionesRepository.CreateAsync(asignacion);
            return CreatedAtAction(nameof(GetAsignacion), new { id = createdAsignacion.AsignacionId }, createdAsignacion);
        }

        // PUT: api/Asignaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacion(int id, [FromBody] Asignaciones asignacion)
        {
            if (asignacion == null || id != asignacion.AsignacionId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAsignacion = await _asignacionesRepository.GetByIdAsync(id);
            if (existingAsignacion == null)
            {
                return NotFound();
            }

            var updatedAsignacion = await _asignacionesRepository.UpdateAsync(asignacion);
            if (updatedAsignacion == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating assignment record");
            }

            return Ok(updatedAsignacion);
        }

        // DELETE: api/Asignaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacion(int id)
        {
            var deleted = await _asignacionesRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
