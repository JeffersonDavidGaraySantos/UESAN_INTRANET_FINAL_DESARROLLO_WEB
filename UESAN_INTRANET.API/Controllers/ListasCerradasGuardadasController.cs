using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasCerradasGuardadasController : ControllerBase
    {
        private readonly IListasCerradasGuardadasRepository _listasCerradasGuardadasRepository;

        public ListasCerradasGuardadasController(IListasCerradasGuardadasRepository listasCerradasGuardadasRepository)
        {
            _listasCerradasGuardadasRepository = listasCerradasGuardadasRepository;
        }

        // GET: api/ListasCerradasGuardadas
        [HttpGet]
        public async Task<IActionResult> GetListasCerradasGuardadas()
        {
            var listas = await _listasCerradasGuardadasRepository.GetAllAsync();
            return Ok(listas);
        }

        // GET: api/ListasCerradasGuardadas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListaCerradaGuardada(int id)
        {
            var lista = await _listasCerradasGuardadasRepository.GetByIdAsync(id);
            if (lista == null)
            {
                return NotFound();
            }
            return Ok(lista);
        }

        // POST: api/ListasCerradasGuardadas
        [HttpPost]
        public async Task<IActionResult> PostListaCerradaGuardada([FromBody] ListasCerradasGuardadas lista)
        {
            if (lista == null)
            {
                return BadRequest("ListaCerradaGuardada cannot be null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLista = await _listasCerradasGuardadasRepository.CreateAsync(lista);
            return CreatedAtAction(nameof(GetListaCerradaGuardada), new { id = createdLista.ListasCerradasGuardadasId }, createdLista);
        }

        // PUT: api/ListasCerradasGuardadas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListaCerradaGuardada(int id, [FromBody] ListasCerradasGuardadas lista)
        {
            if (lista == null || id != lista.ListasCerradasGuardadasId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingLista = await _listasCerradasGuardadasRepository.GetByIdAsync(id);
            if (existingLista == null)
            {
                return NotFound();
            }

            var updatedLista = await _listasCerradasGuardadasRepository.UpdateAsync(lista);
            if (updatedLista == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating saved list record");
            }

            return Ok(updatedLista);
        }

        // DELETE: api/ListasCerradasGuardadas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListaCerradaGuardada(int id)
        {
            var deleted = await _listasCerradasGuardadasRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


        // DELETE: api/ListasCerradasGuardadas/{usuarioId}/{listasCerradasId}
        [HttpDelete("{usuarioId}/{listasCerradasId}")]
        public async Task<IActionResult> DeleteByUsuarioYRevista(int usuarioId, int listasCerradasId)
        {
            var deleted = await _listasCerradasGuardadasRepository.DeleteByUsuarioYRevistaAsync(usuarioId, listasCerradasId);
            if (!deleted)
                return NotFound();
            return NoContent();
        }




    }
}
