using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_final_prowebII.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public ICollection<ItemPedido>? ItemsPedido { get; set; }
    }
}
