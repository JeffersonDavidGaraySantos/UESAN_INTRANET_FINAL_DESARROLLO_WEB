using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN_INTRANET.CORE.Core.Entities;
using UESAN_INTRANET.CORE.Core.Interfaces;
using System.Net.Mail;
using System.Net;

namespace UESAN_INTRANET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        // Simulación de almacenamiento de códigos (en producción usa BD o caché)
        private static Dictionary<string, string> recoveryCodes = new();

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
                    return BadRequest(ModelState);
                }

                var createdUsuario = await _usuariosRepository.CreateAsync(usuario);
                return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.UsuarioId }, createdUsuario);
            }
            catch (Exception ex)
            {
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

            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuario = usuarios.FirstOrDefault(u =>
                u.Correo == request.Correo && u.Contraseña == request.Contraseña);

            if (usuario == null)
                return Unauthorized(new { message = "Credenciales inválidas." });

            return Ok(new
            {
                usuario.UsuarioId,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Correo,
                usuario.RolId,
                usuario.Estado,
                usuario.FechaRegistro,
                token = "fake-token"
            });
        }

        public class LoginRequest
        {
            public string Correo { get; set; }
            public string Contraseña { get; set; }
        }
        // ==========================================================

        // ========== RECUPERACIÓN DE CONTRASEÑA ==========

        // POST: api/Usuarios/forgot-password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Correo))
                return BadRequest(new { message = "Correo requerido." });

            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuario = usuarios.FirstOrDefault(u => u.Correo == request.Correo);
            if (usuario == null)
                return NotFound(new { message = "Usuario no encontrado." });

            // Generar código aleatorio
            var code = new Random().Next(100000, 999999).ToString();
            recoveryCodes[request.Correo] = code;

            // Enviar correo (aquí puedes usar tu propio servicio SMTP)
            try
            {
                // Simulación: imprime el código en consola
                Console.WriteLine($"Código de recuperación para {request.Correo}: {code}");

                // Si tienes SMTP, descomenta y configura esto:
                /*
                var smtpClient = new SmtpClient("smtp.tuservidor.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("usuario", "contraseña"),
                    EnableSsl = true,
                };
                smtpClient.Send("no-reply@tudominio.com", request.Correo, "Recuperación de contraseña", $"Tu código es: {code}");
                */

                return Ok(new { message = "Código enviado a tu correo." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error enviando el correo: " + ex.Message });
            }
        }

        public class ForgotPasswordRequest
        {
            public string Correo { get; set; }
        }

        // POST: api/Usuarios/verify-code
        [HttpPost("verify-code")]
        public IActionResult VerifyCode([FromBody] VerifyCodeRequest request)
        {
            if (string.IsNullOrEmpty(request.Correo) || string.IsNullOrEmpty(request.Codigo))
                return BadRequest(new { message = "Correo y código requeridos." });

            if (recoveryCodes.TryGetValue(request.Correo, out var code) && code == request.Codigo)
            {
                return Ok(new { message = "Código verificado." });
            }
            else
            {
                return BadRequest(new { message = "Código incorrecto." });
            }
        }

        public class VerifyCodeRequest
        {
            public string Correo { get; set; }
            public string Codigo { get; set; }
        }

        // POST: api/Usuarios/reset-password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (string.IsNullOrEmpty(request.Correo) || string.IsNullOrEmpty(request.Codigo) || string.IsNullOrEmpty(request.NuevaContrasena))
                return BadRequest(new { message = "Datos incompletos." });

            if (!recoveryCodes.TryGetValue(request.Correo, out var code) || code != request.Codigo)
                return BadRequest(new { message = "Código inválido." });

            var usuarios = await _usuariosRepository.GetAllAsync();
            var usuario = usuarios.FirstOrDefault(u => u.Correo == request.Correo);
            if (usuario == null)
                return NotFound(new { message = "Usuario no encontrado." });

            usuario.Contraseña = request.NuevaContrasena;
            await _usuariosRepository.UpdateAsync(usuario);

            // Elimina el código usado
            recoveryCodes.Remove(request.Correo);

            return Ok(new { message = "Contraseña actualizada." });
        }

        public class ResetPasswordRequest
        {
            public string Correo { get; set; }
            public string Codigo { get; set; }
            public string NuevaContrasena { get; set; }
        }
        // ================================================
    }
}