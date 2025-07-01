using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities;

public partial class Notificaciones
{
    public int NotificacionId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaEnvio { get; set; }

    public bool? Leido { get; set; }

    public virtual Usuarios? Usuario { get; set; }
}
