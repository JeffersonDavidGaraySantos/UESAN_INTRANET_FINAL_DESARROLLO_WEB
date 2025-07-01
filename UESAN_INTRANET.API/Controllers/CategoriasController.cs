using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {

        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriasController(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _categoriasRepository.GetAllAsync();
            return Ok(categorias);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var categoria = await _categoriasRepository.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, [FromBody] Categorias categoria)
        {
            if (categoria == null || id != categoria.CategoriaId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategoria = await _categoriasRepository.GetByIdAsync(id);
            if (existingCategoria == null)
            {
                return NotFound();
            }

            var updatedCategoria = await _categoriasRepository.UpdateAsync(categoria);
            if (updatedCategoria == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating category record");
            }

            return Ok(updatedCategoria);
        }

        // POST: api/Categorias
        public async Task<IActionResult> PostCategoria([FromBody] Categorias categoria)
        {
            if (categoria == null)
            {
                return BadRequest("Categoria cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCategoria = await _categoriasRepository.CreateAsync(categoria);
            return CreatedAtAction(nameof(GetCategoria), new { id = createdCategoria.CategoriaId }, createdCategoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var deleted = await _categoriasRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

