using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Infrastructure.Repositories;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessosController : ControllerBase
    {
        private readonly IAccesosRepository _accesosRepository;

        public AcessosController(IAccesosRepository accesosRepository)
        {
            _accesosRepository = accesosRepository;
        }

        // GET: api/Accesos
        [HttpGet]
        public async Task<IActionResult> GetAllAccesos()
        {
            var accesos = await _accesosRepository.GetAllAccesosAsync();
            return Ok(accesos);
        }

        // GET: api/Accesos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccesoById(int id)
        {
            var acceso = await _accesosRepository.GetAccesoByIdAsync(id);
            if (acceso == null)
            {
                return NotFound();
            }
            return Ok(acceso);
        }

        // POST: api/Accesos
        [HttpPost]
        public async Task<IActionResult> CreateAcceso([FromBody] Accesos acceso)
        {
            if (acceso == null)
            {
                return BadRequest("Acceso cannot be null.");
            }
            var createdAcceso = await _accesosRepository.CreateAccesoAsync(acceso);
            return CreatedAtAction(nameof(GetAccesoById), new { id = createdAcceso.AccesoId }, createdAcceso);
        }

        // PUT: api/Accesos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcceso(int id, [FromBody] Accesos acceso)
        {
            if (acceso == null || id != acceso.AccesoId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAcceso = await _accesosRepository.GetAccesoByIdAsync(id);
            if (existingAcceso == null)
            {
                return NotFound();
            }

            var updatedAcceso = await _accesosRepository.UpdateAccesoAsync(acceso);
            if (updatedAcceso == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating access record");
            }

            return Ok(updatedAcceso);
        }

        // DELETE: api/Accesos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcceso(int id)
        {
            var result = await _accesosRepository.DeleteAccesoAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}
