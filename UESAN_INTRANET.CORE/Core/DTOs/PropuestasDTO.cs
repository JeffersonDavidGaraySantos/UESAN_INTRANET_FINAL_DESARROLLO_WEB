using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.DTOs
{
    public class PropuestasDTO
    {
        public int PropuestaId { get; set; }
        public int UsuarioId { get; set; }
        public string? Tema { get; set; }
        public string? Descripcion { get; set; }
        public string? Incentivo { get; set; }
        public int CategoriaId { get; set; }
    }
}
