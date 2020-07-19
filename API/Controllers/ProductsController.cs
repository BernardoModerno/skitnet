using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts() 
        {
            return "Esta vai ser uma lista de produtos";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id) 
        {
            return "Único produto";
        }
    }
}