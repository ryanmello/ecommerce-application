using EcommerceProject.Server.Repositories.Interfaces;
using EcommerceProject.Shared.DataTransferModels;
using EcommerceProject.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpPost("add-product")]
        public async Task<ActionResult<ServiceModel>> AddProduct(Product newProduct)
        {
            return Ok(await productRepository.AddProduct(newProduct));
        }

        // get all products
        [HttpGet("get-products")]
        public async Task<ActionResult<ServiceModel>> GetProducts()
        {
            return Ok(await productRepository.GetProducts());
        }

        // get product by id
        [HttpGet("get-product/{productId:int}")]
        public async Task<ActionResult<ServiceModel>> GetProduct(int productId)
        {
            return Ok(await productRepository.GetProduct(productId));
        }
    }
}
