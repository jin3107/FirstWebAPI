using FirstWebAPI.Models;
using FirstWebAPI.Repositories;
using FirstWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IProductRepository _repository;

        public ProductsController(IProductService service, IProductRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _repository.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi đọc sản phẩm.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var product = await _repository.GetProductAsync(id);
                return product == null ? NotFound(new { message = "Không tìm thấy sản phẩm với ID này." }) : Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi tìm kiếm sản phẩm.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel model)
        {
            try
            {
                var newProductId = await _repository.AddProductAsync(model);
                var product = await _repository.GetProductAsync(newProductId);
                return product == null ? NotFound(new { message = "Sản phẩm không tồn tại sau khi thêm." }) : Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi thêm sản phẩm.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductModel model)
        {
            if (id != model.Id)
            {
                return BadRequest(new { message = "ID trong URL không khớp với ID trong model." });
            }
            try
            {
                await _repository.UpdateProductAsync(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi cập nhật sản phẩm.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var product = await _repository.GetProductAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Không tìm thấy sản phẩm với ID này." });
                }
                await _repository.DeleteProductAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi xóa sản phẩm.", error = ex.Message });
            }
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchProducts([FromBody] SearchRequest request)
        {
            try
            {
                var response = await _service.SearchProductsAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Đã xảy ra lỗi khi tìm kiếm sản phẩm.", error = ex.Message });
            }
        }
    }
}
