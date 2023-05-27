using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Services.Interfaces;

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public ResponseGetListProductModel GetListProduct(RequestGetListProductModel model)
        {
            model.transactionDate = DateTime.Now;
            var response = _service.GetListProduct(model);
            return response;
        }
    }
}
