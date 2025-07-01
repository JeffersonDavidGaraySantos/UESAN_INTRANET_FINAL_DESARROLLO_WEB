using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities;

public partial class Categorias
{
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<ListasCerradas> ListasCerradas { get; set; } = new List<ListasCerradas>();
}
