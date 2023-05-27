using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Services.Interfaces
{
    public interface ITransactionService
    {
        ResponseTransactionModel CreateTransaction(RequestTransactionModel model);
    }
}
