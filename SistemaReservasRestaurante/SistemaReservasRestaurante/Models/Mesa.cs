using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SistemaReservasRestaurante.Models
{

    public class Mesa
    {
        public int Id { get; set; }

        [Display(Name = "Número de mesa")]
        public string Numero { get; set; }

        [Display(Name = "Capacidad")]
        public int Capacidad { get; set; }

        [Display(Name = "¿Disponible?")]
        public bool Disponible { get; set; }

        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public CategoriaMesa CategoriaMesa { get; set; }

    }
}
