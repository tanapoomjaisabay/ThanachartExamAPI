using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Services.Interfaces
{
    public interface IProductService
    {
        ResponseGetListProductModel GetListProduct(RequestGetListProductModel model);
    }
}
