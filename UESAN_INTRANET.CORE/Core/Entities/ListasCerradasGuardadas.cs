using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities;

public partial class ListasCerradasGuardadas
{
    public int ListasCerradasGuardadasId { get; set; }

    public int? UsuarioId { get; set; }

    public int? ListasCerradasId { get; set; }

    public DateTime? FechaGuardado { get; set; }

    public virtual ListasCerradas? ListasCerradas { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
