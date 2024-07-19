namespace FirstWebAPI.Models
{
    public class SearchResponse
    {
        public int TotalProducts { get; set; }
        public int TotalPages { get; set; }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
