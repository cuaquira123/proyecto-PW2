using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_final_prowebII.Models
{
    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemPedidoId { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Define la precisión y escala
        public decimal Precio { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Define la precisión y escala
        public decimal Descuento { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido? Pedido { get; set; }

        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }
    }
}
