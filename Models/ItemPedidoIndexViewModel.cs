using static Proyecto_final_prowebII.Models.ProductoIndexViewModel;

namespace Proyecto_final_prowebII.Models
{
    public class PaginationInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }

    public class ItemPedidoIndexViewModel
    {
        public IEnumerable<ItemPedido> ItemsPedidos { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public string SortOrder { get; set; }
        public string SearchCantidad { get; set; }
        public string SearchDescuento { get; set; }
    }
}
