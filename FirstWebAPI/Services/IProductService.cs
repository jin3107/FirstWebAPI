using FirstWebAPI.Models;

namespace FirstWebAPI.Services
{
    public interface IProductService
    {
        Task<SearchResponse> SearchProductsAsync(SearchRequest request);
    }
}
