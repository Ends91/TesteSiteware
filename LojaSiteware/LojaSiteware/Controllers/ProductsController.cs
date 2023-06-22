

using LojaSiteware.Infra.Data.Interfaces.Services;
using LojaSiteware.UI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LojaSiteware.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            return Ok(_productService.CreateProduct(productDTO));
        }

        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            return Ok(_productService.UpdateProduct(id, productDTO));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            return Ok(_productService.DeleteProduct(id));
        }
    }
}
