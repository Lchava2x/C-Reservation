using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaReservasRestaurante.Models
{
    public class CategoriaMesa
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        public string Nombre { get; set; }

        // Relación uno a muchos
        public virtual ICollection<Mesa> Mesas { get; set; }
    }
}
