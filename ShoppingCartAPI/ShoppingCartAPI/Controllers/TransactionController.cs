using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Services.Interfaces;

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpPost]
        public ResponseTransactionModel CreateTransaction(RequestTransactionModel model)
        {
            model.transactionDate = DateTime.Now;
            var response = _service.CreateTransaction(model);
            return response;
        }
    }
}
