using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities;

public partial class IssnConsulta
{
    public int IssnConsultaId { get; set; }

    public string? Issn { get; set; }

    public string? Nombre { get; set; }

    public string? Scopus { get; set; }

    public string? WoSQ { get; set; }

    public int? WoSS { get; set; }

    public bool? WoSEsci { get; set; }

    public string? EsciQ { get; set; }

    public string? Ajg4 { get; set; }

    public string? Ajg { get; set; }

    public int? AjgS { get; set; }

    public string? Cnrs { get; set; }

    public int? CnrsS { get; set; }

    public string? Abdc { get; set; }

    public int? AbdcS { get; set; }

    public string? AlMenosEnUnaLista { get; set; }

    public string? SoloEnUnaLista { get; set; }

    public string? Scielo { get; set; }

    public string? WoSLatam { get; set; }

    public string? Top50 { get; set; }

    public int? N { get; set; }

    public string? BeallsList { get; set; }

    public string? Mdpi { get; set; }

    public string? Insights { get; set; }

    public bool? AjgExiste { get; set; }

    public bool? CnrsExiste { get; set; }

    public bool? AbdcExiste { get; set; }

    public bool? WoSTopExiste { get; set; }

    public bool? WoSEsciExiste { get; set; }

    public bool? ScopusExiste { get; set; }

    public bool? SoloScieloExiste { get; set; }

    public bool? Especial216b { get; set; }

    public bool? LatamSinEsciExiste { get; set; }

    public bool? EsciScieloSinScopus { get; set; }

    public bool? Multiple { get; set; }

    public bool? MultidisciplinaryWos { get; set; }

    public string? CoautoriaEsan { get; set; }

    public string? PosicionDelAutor { get; set; }

    public decimal? Jif { get; set; }

    public string? Country { get; set; }

    public bool? MultyYAlMenosUnaLista { get; set; }

    public bool? MultidisciplinaryScopus { get; set; }

    public bool? MultidisciplinaryWosOScopus { get; set; }
}
