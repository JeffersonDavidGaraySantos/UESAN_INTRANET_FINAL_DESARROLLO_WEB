using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssnConsultaController : ControllerBase
    {
        private readonly IIssnConsultaRepository _issnConsultaRepository;

        public IssnConsultaController(IIssnConsultaRepository issnConsultaRepository)
        {
            _issnConsultaRepository = issnConsultaRepository;
        }

        // GET: api/IssnConsulta
        [HttpGet]
        public async Task<IActionResult> GetIssnConsultas()
        {
            var consultas = await _issnConsultaRepository.GetAllAsync();
            return Ok(consultas);
        }

        // GET: api/IssnConsulta/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIssnConsulta(int id)
        {
            var consulta = await _issnConsultaRepository.GetByIdAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return Ok(consulta);
        }

        // POST: api/IssnConsulta
        [HttpPost]
        public async Task<IActionResult> PostIssnConsulta([FromBody] IssnConsulta consulta)
        {
            if (consulta == null)
            {
                return BadRequest("Consulta cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdConsulta = await _issnConsultaRepository.CreateAsync(consulta);
            return CreatedAtAction(nameof(GetIssnConsulta), new { id = createdConsulta.IssnConsultaId }, createdConsulta);
        }

        // PUT: api/IssnConsulta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIssnConsulta(int id, [FromBody] IssnConsulta consulta)
        {
            if (consulta == null || id != consulta.IssnConsultaId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingConsulta = await _issnConsultaRepository.GetByIdAsync(id);
            if (existingConsulta == null)
            {
                return NotFound();
            }

            var updatedConsulta = await _issnConsultaRepository.UpdateAsync(consulta);
            if (updatedConsulta == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating ISSN consultation record");
            }

            return Ok(updatedConsulta);
        }

        // DELETE: api/IssnConsulta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIssnConsulta(int id)
        {
            var deleted = await _issnConsultaRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
