using static Proyecto_final_prowebII.Models.ProductoIndexViewModel;

namespace Proyecto_final_prowebII.Models
{
    public class PedidoIndexViewModel
    {
        public IEnumerable<Pedido>? Pedidos { get; set; }
        public PagingInfo? PagingInfo { get; set; }
        public string? SortOrder { get; set; }
        public string? SearchDate { get; set; }
        public string? SearchClient { get; set; }
    }
}
