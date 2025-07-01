using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasCerradasController : ControllerBase
    {
        private readonly IListasCerradasRepository _listasCerradasRepository;

        public ListasCerradasController(IListasCerradasRepository listasCerradasRepository)
        {
            _listasCerradasRepository = listasCerradasRepository;
        }

        // GET: api/ListasCerradas
        [HttpGet]
        public async Task<IActionResult> GetListasCerradas()
        {
            var listas = await _listasCerradasRepository.GetAllAsync();
            return Ok(listas);
        }

        // GET: api/ListasCerradas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListaCerrada(int id)
        {
            var lista = await _listasCerradasRepository.GetByIdAsync(id);
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }

        // POST: api/ListasCerradas
        [HttpPost]
        public async Task<IActionResult> PostListaCerrada([FromBody] ListasCerradas lista)
        {
            if (lista == null)
            {
                return BadRequest("ListaCerrada cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLista = await _listasCerradasRepository.CreateAsync(lista);
            return CreatedAtAction(nameof(GetListaCerrada), new { id = createdLista.ListasCerradasId }, createdLista);
        }

        // PUT: api/ListasCerradas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaCerrada(int id, [FromBody] ListasCerradas lista)
        {
            if (lista == null || id != lista.ListasCerradasId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingLista = await _listasCerradasRepository.GetByIdAsync(id);
            if (existingLista == null)
            {
                return NotFound();
            }

            var updatedLista = await _listasCerradasRepository.UpdateAsync(lista);
            if (updatedLista == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating closed list record");
            }

            return Ok(updatedLista);
        }

        // DELETE: api/ListasCerradas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaCerrada(int id)
        {
            var deleted = await _listasCerradasRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
