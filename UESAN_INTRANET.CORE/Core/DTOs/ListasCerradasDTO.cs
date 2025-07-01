using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN_INTRANET.CORE.Core.DTOs
{
    public class ListasCerradasDTO
    {
        public int ListasCerradasId { get; set; }
        public string? Issn { get; set; }
        public string? Issn2 { get; set; }
        public string? Issn3 { get; set; }
        public string? Nombre { get; set; }
        public int? CategoriaId { get; set; }
        public decimal? Puntaje { get; set; }
        public decimal? IncentivoUsd { get; set; }
        public string? Scopus { get; set; }
        public string? WoSQ { get; set; }
        public string? EsciQ { get; set; }
        public string? Ajg { get; set; }
        public string? Cnrs { get; set; }
        public int? Abdc { get; set; }
        public string? WoSLatam { get; set; }
    }
}
