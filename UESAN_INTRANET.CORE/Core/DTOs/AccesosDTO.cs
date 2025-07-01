using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.DTOs
{
    public class AccesosDTO
    {
        public int AccesoId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? FechaHoraAcceso { get; set; }
    }
}
