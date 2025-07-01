using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionesRepository _notificacionesRepository;

        public NotificacionesController(INotificacionesRepository notificacionesRepository)
        {
            _notificacionesRepository = notificacionesRepository;
        }

        // GET: api/Notificaciones
        [HttpGet]
        public async Task<IActionResult> GetNotificaciones()
        {
            var notificaciones = await _notificacionesRepository.GetAllAsync();
            return Ok(notificaciones);
        }

        // GET: api/Notificaciones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificacion(int id)
        {
            var notificacion = await _notificacionesRepository.GetByIdAsync(id);
            if (notificacion == null)
            {
                return NotFound();
            }
            return Ok(notificacion);
        }

        // POST: api/Notificaciones
        [HttpPost]
        public async Task<IActionResult> PostNotificacion([FromBody] Notificaciones notificacion)
        {
            if (notificacion == null)
            {
                return BadRequest("Notificacion cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdNotificacion = await _notificacionesRepository.CreateAsync(notificacion);
            return CreatedAtAction(nameof(GetNotificacion), new { id = createdNotificacion.NotificacionId }, createdNotificacion);
        }

        // PUT: api/Notificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotificacion(int id, [FromBody] Notificaciones notificacion)
        {
            if (notificacion == null || id != notificacion.NotificacionId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingNotificacion = await _notificacionesRepository.GetByIdAsync(id);
            if (existingNotificacion == null)
            {
                return NotFound();
            }

            var updatedNotificacion = await _notificacionesRepository.UpdateAsync(notificacion);
            if (updatedNotificacion == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating notification record");
            }

            return Ok(updatedNotificacion);
        }

        // DELETE: api/Notificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificacion(int id)
        {
            var deleted = await _notificacionesRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
