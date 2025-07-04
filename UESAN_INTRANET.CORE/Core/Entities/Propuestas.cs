using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.Entities
{
    public partial class Propuestas
    {
        public int PropuestaId { get; set; }

        public int UsuarioId { get; set; } 
        public int CategoriaId { get; set; }

        public string? Tema { get; set; }
        public string? Descripcion { get; set; }
        public string? Incentivo { get; set; }

        public virtual Usuarios? Usuario { get; set; }
        public virtual Categorias? Categoria { get; set; }

    }
}
