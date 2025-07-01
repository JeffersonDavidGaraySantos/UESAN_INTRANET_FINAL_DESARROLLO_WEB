using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.DTOs
{
    public class AccesosFormularioProfesoresDTO
    {
        public int AccesoId { get; set; }
        public string? Correos { get; set; }
        public string? Trabajador { get; set; }
        public string? Dni { get; set; }
        public string? Categoria { get; set; }
    }
}
