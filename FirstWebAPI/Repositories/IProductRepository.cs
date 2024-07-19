using FirstWebAPI.Models;

namespace FirstWebAPI.Repositories
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> GetAllProductsAsync();
        public Task<ProductModel> GetProductAsync(Guid id);
        public Task<Guid> AddProductAsync(ProductModel model);
        public Task UpdateProductAsync(Guid id, ProductModel model);
        public Task DeleteProductAsync(Guid id);

        // Tìm kiếm và Phân trang
        Task<List<ProductModel>> GetProductsAsync(string search, int pageNumber, int pageSize);
        Task<int> GetTotalProductsCountAsync(string search);
    }
}
