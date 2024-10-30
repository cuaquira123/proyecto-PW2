using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_final_prowebII.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }

        [Required]
        [StringLength(200)]
        public string? NombreProducto { get; set; }

        [Required]
        public int AñoModelo { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Define la precisión y escala
        public decimal Precio { get; set; }
        public ICollection<ItemPedido>? ItemsPedido { get; set; }
    }
}
