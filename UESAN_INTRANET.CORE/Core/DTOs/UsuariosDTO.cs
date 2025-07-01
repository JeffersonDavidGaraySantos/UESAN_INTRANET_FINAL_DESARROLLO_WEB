using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.DTOs
{
    public class UsuariosDTO
    {
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public int RolId { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
    public class UsuariosResumenDTO
    {
        public string? Nombre { get; set; }
        public string? NombreRol { get; set; }

    }
}
