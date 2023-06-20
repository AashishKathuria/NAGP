using Microsoft.AspNetCore.Mvc;
using NAGP_ASP_Microservice.Repository;
using System.Transactions;

namespace NAGP_ASP_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        [HttpGet(("version"), Name="Version")]
        public IActionResult Version()
        {
           
            return new OkObjectResult("v1");
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.GetProductByID(id);
            return new OkObjectResult(product);
        }

   
    }
}