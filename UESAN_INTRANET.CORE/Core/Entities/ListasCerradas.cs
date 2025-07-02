using System;
using System.Collections.Generic;

namespace UESAN_INTRANET.CORE.Core.Entities
{
    public partial class ListasCerradas
    {
        public int ListasCerradasId { get; set; }
        public string Issn { get; set; }
        public string Issn2 { get; set; }
        public string Issn3 { get; set; }
        public string Nombre { get; set; }
        public int? CategoriaId { get; set; }
        public decimal? Puntaje { get; set; }
        public decimal? IncentivoUsd { get; set; }
        public string Scopus { get; set; }
        public string WoSQ { get; set; }
        public string EsciQ { get; set; }
        public string Ajg { get; set; }
        public string Cnrs { get; set; }
        public string Abdc { get; set; } // <-- CAMBIO: ahora es string
        public string WoSLatam { get; set; }

        public virtual Categorias Categoria { get; set; }
        public virtual ICollection<Asignaciones> Asignaciones { get; set; }
        public virtual ICollection<ListasCerradasGuardadas> ListasCerradasGuardadas { get; set; }
    }
}