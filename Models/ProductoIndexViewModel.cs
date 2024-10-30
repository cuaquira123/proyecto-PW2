namespace Proyecto_final_prowebII.Models
{
    public class ProductoIndexViewModel
    {
        public IEnumerable<Producto>? Productos { get; set; }
        public PagingInfo? PagingInfo { get; set; }
        public string? SortOrder { get; set; }
        public string? SearchName { get; set; }
        public string? SearchYear { get; set; }
    }

    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
