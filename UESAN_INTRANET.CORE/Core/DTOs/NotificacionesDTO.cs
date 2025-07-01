using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.DTOs
{
    public class NotificacionesDTO
    {
        public int NotificacionId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Mensaje { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public bool? Leido { get; set; }
    }
}
