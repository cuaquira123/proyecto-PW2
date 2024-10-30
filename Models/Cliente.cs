using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_final_prowebII.Models
{
    
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        [StringLength(255)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es un campo obligatorio")]
        [StringLength(255)]
        public string? Apellido { get; set; }

        [StringLength(25)]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El Correo es un campo obligatorio")]
        [StringLength(255)]
        public string? Correo { get; set; }

        [StringLength(255)]
        public string? Calle { get; set; }

        [StringLength(50)]
        public string? Ciudad { get; set; }

        [StringLength(50)]
        public string? Estado { get; set; }

        [StringLength(5)]
        public string? CodigoPostal { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
