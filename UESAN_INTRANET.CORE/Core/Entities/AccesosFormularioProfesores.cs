using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities;

public partial class AccesosFormularioProfesores
{
    public int AccesoId { get; set; }

    public string? Correos { get; set; }

    public string? Trabajador { get; set; }

    public string? Dni { get; set; }

    public string? Categoria { get; set; }
}
