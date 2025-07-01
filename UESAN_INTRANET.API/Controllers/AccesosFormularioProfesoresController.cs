using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosFormularioProfesoresController : ControllerBase
    {
        private readonly IAccesosFormularioProfesoresRepository _repository;

        public AccesosFormularioProfesoresController(IAccesosFormularioProfesoresRepository repository)
        {
            _repository = repository;
        }

        // GET: api/AccesosFormularioProfesores
        [HttpGet]
        public async Task<IActionResult> GetAccesosFormularioProfesores()
        {
            var accesos = await _repository.GetAllAsync();
            return Ok(accesos);
        }

        // GET: api/AccesosFormularioProfesores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccesoFormularioProfesor(int id)
        {
            var acceso = await _repository.GetByIdAsync(id);
            if (acceso == null)
            {
                return NotFound();
            }
            return Ok(acceso);
        }

        // POST: api/AccesosFormularioProfesores
        [HttpPost]
        public async Task<IActionResult> PostAccesoFormularioProfesor([FromBody] AccesosFormularioProfesores acceso)
        {
            if (acceso == null)
            {
                return BadRequest("AccesoFormularioProfesor cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAcceso = await _repository.CreateAsync(acceso);
            return CreatedAtAction(nameof(GetAccesoFormularioProfesor), new { id = createdAcceso.AccesoId }, createdAcceso);
        }

        // PUT: api/AccesosFormularioProfesores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccesoFormularioProfesor(int id, [FromBody] AccesosFormularioProfesores acceso)
        {
            if (acceso == null || id != acceso.AccesoId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAcceso = await _repository.GetByIdAsync(id);
            if (existingAcceso == null)
            {
                return NotFound();
            }

            var updatedAcceso = await _repository.UpdateAsync(acceso);
            if (updatedAcceso == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating access form record");
            }

            return Ok(updatedAcceso);
        }

        // DELETE: api/AccesosFormularioProfesores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccesoFormularioProfesor(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
