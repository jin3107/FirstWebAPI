using FirstWebAPI.Models;
using FirstWebAPI.Repositories;

namespace FirstWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<SearchResponse>> SearchProductsAsync(SearchRequest request)
        {
            var products = await _repository.GetProductsAsync(request.Search!, request.PageNumber, request.PageSize);
            var totalProducts = await _repository.GetTotalProductsCountAsync(request.Search!);
            var totalPages = (int)Math.Ceiling(totalProducts / (double)request.PageSize);
            var searchResponse = new SearchResponse
            {
                TotalProducts = totalProducts,
                TotalPages = totalPages,
                Products = products
            };
            return new ApiResponse<SearchResponse>(searchResponse);
        }
    }
}
