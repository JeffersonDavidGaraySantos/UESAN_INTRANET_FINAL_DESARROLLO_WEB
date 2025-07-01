using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.DTOs
{
    public class AsignacionesDTO
    {
        public int AsignacionId { get; set; }
        public int? UsuarioId { get; set; }
        public int? ListasCerradasId { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaAsignacion { get; set; }
    }
}
