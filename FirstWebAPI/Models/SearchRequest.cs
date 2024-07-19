namespace FirstWebAPI.Models
{
    public class SearchRequest
    {
        public string? Search {  get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
