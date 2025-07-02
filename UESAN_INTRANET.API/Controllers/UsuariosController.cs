using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuariosRepository.GetAllAsync();
            return Ok(usuarios);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuariosRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Usuario cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    // Devuelve los errores de validación
                    return BadRequest(ModelState);
                }

                var createdUsuario = await _usuariosRepository.CreateAsync(usuario);
                return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.UsuarioId }, createdUsuario);
            }
            catch (Exception ex)
            {
                // Loguea el error en consola
                Console.WriteLine("Error al registrar usuario: " + ex.Message);
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] Usuarios usuario)
        {
            if (usuario == null || id != usuario.UsuarioId)
            {
                return BadRequest("Invalid request data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUsuario = await _usuariosRepository.GetByIdAsync(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            var updatedUsuario = await _usuariosRepository.UpdateAsync(usuario);
            if (updatedUsuario == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user record");
            }

            return Ok(updatedUsuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var deleted = await _usuariosRepository.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        // ===================== LOGIN (SIGNIN) =====================
        // POST: api/Usuarios/signin
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Correo) || string.IsNullOrEmpty(request.Contraseña))
                return BadRequest(new { message = "Correo y contraseña requeridos." });

            // Busca el usuario por correo y contraseña (ajusta según tu lógica real)
            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuario = usuarios.FirstOrDefault(u =>
                u.Correo == request.Correo && u.Contraseña == request.Contraseña);

            if (usuario == null)
                return Unauthorized(new { message = "Credenciales inválidas." });

            // Puedes devolver solo los datos necesarios (no la contraseña)
            return Ok(new
            {
                usuario.UsuarioId,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Correo,
                usuario.RolId,
                usuario.Estado,
                usuario.FechaRegistro,
                token = "fake-token" // Aquí deberías generar un JWT real si lo necesitas
            });
        }

        // Clase auxiliar para el login
        public class LoginRequest
        {
            public string Correo { get; set; }
            public string Contraseña { get; set; }
        }
        // ==========================================================
    }
}