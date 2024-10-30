namespace Proyecto_final_prowebII.Models
{
    public class ClienteIndexViewModel
    {
        
        
            public List<Cliente> Clientes { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalItems { get; set; }
            public string SortOrder { get; set; }
            public string SearchName { get; set; }
            public string SearchPhone { get; set; }

            public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

            public bool HasPreviousPage => PageNumber > 1;
            public bool HasNextPage => PageNumber < TotalPages;
        
    }
}
