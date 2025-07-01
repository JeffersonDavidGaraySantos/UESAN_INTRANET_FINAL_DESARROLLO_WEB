using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities;

public partial class FaqChatbot
{
    public int Faqid { get; set; }

    public string? PreguntaClave { get; set; }

    public string? Respuesta { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Visible { get; set; }
}
