using AutoMapper;
using FirstWebAPI.Data;
using FirstWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstWebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProductRepository(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> AddProductAsync(ProductModel model)
        {
            var newProduct = _mapper.Map<Products>(model);
            newProduct.Id = Guid.NewGuid();
            _context.Products!.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var deleteProduct= _context.Products!.SingleOrDefault(x => x.Id == id);
            if (deleteProduct != null)
            {
                _context.Products!.Remove(deleteProduct!);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProductAsync(Guid id)
        {
            var product = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task UpdateProductAsync(Guid id, ProductModel model)
        {
            if (id == model.Id)
            {
                var updateProduct = _mapper.Map<Products>(model);
                _context.Products!.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
