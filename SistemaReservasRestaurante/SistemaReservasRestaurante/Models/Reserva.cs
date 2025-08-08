using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaReservasRestaurante.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del Cliente")]
        public string NombreCliente { get; set; }

        [Required]
        [Display(Name = "Mesa")]
        public int MesaId { get; set; }

        [ForeignKey("MesaId")]
        public virtual Mesa Mesa { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Hora")]
        public string Hora { get; set; }
    }
}
