using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using UESAN_INTRANET.CORE.Core.DTOs;
using UESAN_INTRANET.CORE.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasCerradasController : ControllerBase
    {
        private readonly IListasCerradasRepository _listasCerradasRepository;
        private readonly VdiIntranet2Context _context;

        public ListasCerradasController(
            IListasCerradasRepository listasCerradasRepository,
            VdiIntranet2Context context)
        {
            _listasCerradasRepository = listasCerradasRepository;
            _context = context;
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

        // POST: api/ListasCerradas/importar
        [HttpPost("importar")]
        public async Task<IActionResult> ImportarListasCerradas([FromBody] List<Dictionary<string, object>> registros)
        {
            if (registros == null || !registros.Any())
                return BadRequest("No se recibieron registros para importar.");

            var resultados = new List<ListasCerradasDTO>();

            foreach (var registro in registros)
            {
                // 1. Obtener el nombre de la categoría desde el Excel
                var nombreCategoria = registro.ContainsKey("Categoría 2") ? registro["Categoría 2"]?.ToString() : null;
                int? categoriaId = null;

                if (!string.IsNullOrWhiteSpace(nombreCategoria))
                {
                    // 2. Buscar si ya existe la categoría
                    var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.NombreCategoria == nombreCategoria);
                    if (categoria == null)
                    {
                        // 3. Si no existe, la creas
                        categoria = new Categorias { NombreCategoria = nombreCategoria };
                        _context.Categorias.Add(categoria);
                        await _context.SaveChangesAsync();
                    }
                    categoriaId = categoria.CategoriaId;
                }

                // 4. Insertar en ListasCerradas usando el categoriaId
                var creado = await _listasCerradasRepository.CreateAsync(new ListasCerradas
                {
                    Issn = registro.ContainsKey("ISSN") ? registro["ISSN"]?.ToString() : null,
                    Issn2 = registro.ContainsKey("ISSN2") ? registro["ISSN2"]?.ToString() : null,
                    Issn3 = registro.ContainsKey("ISSN3") ? registro["ISSN3"]?.ToString() : null,
                    Nombre = registro.ContainsKey("Nombre") ? registro["Nombre"]?.ToString() : null,
                    CategoriaId = categoriaId,
                    Puntaje = registro.ContainsKey("Puntaje") && decimal.TryParse(registro["Puntaje"]?.ToString(), out var puntaje) ? puntaje : (decimal?)null,
                    IncentivoUsd = registro.ContainsKey("Incentivo (USD)") && decimal.TryParse(registro["Incentivo (USD)"]?.ToString(), out var incentivo) ? incentivo : (decimal?)null,
                    Scopus = registro.ContainsKey("SCOPUS") ? registro["SCOPUS"]?.ToString() : null,
                    WoSQ = registro.ContainsKey("WoS (Q)") ? registro["WoS (Q)"]?.ToString() : null,
                    EsciQ = registro.ContainsKey("ESCI Q") ? registro["ESCI Q"]?.ToString() : null,
                    Ajg = registro.ContainsKey("AJG") ? registro["AJG"]?.ToString() : null,
                    Cnrs = registro.ContainsKey("CNRS") ? registro["CNRS"]?.ToString() : null,
                    Abdc = registro.ContainsKey("ABDC") ? registro["ABDC"]?.ToString() : null, // <-- CAMBIO AQUÍ
                    WoSLatam = registro.ContainsKey("WoS LATAM") ? registro["WoS LATAM"]?.ToString() : null
                });

                resultados.Add(new ListasCerradasDTO
                {
                    ListasCerradasId = creado.ListasCerradasId,
                    Issn = creado.Issn,
                    Issn2 = creado.Issn2,
                    Issn3 = creado.Issn3,
                    Nombre = creado.Nombre,
                    CategoriaId = creado.CategoriaId,
                    Puntaje = creado.Puntaje,
                    IncentivoUsd = creado.IncentivoUsd,
                    Scopus = creado.Scopus,
                    WoSQ = creado.WoSQ,
                    EsciQ = creado.EsciQ,
                    Ajg = creado.Ajg,
                    Cnrs = creado.Cnrs,
                    Abdc = creado.Abdc,
                    WoSLatam = creado.WoSLatam
                });
            }

            return Ok(resultados);
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