using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities;

public partial class Asignaciones
{
    public int AsignacionId { get; set; }

    public int? UsuarioId { get; set; }

    public int? ListasCerradasId { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual ListasCerradas? ListasCerradas { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
