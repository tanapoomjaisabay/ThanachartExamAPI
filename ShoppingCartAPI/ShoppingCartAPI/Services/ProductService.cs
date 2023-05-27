using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppingCartAPI.DataAccess;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ShoppingCartAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly ProductContext _context;

        public ProductService(IConfiguration configuration, ProductContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public ResponseGetListProductModel GetListProduct(RequestGetListProductModel model)
        {
            string errorMessage = "Get list product failed. Please try again.";

            try
            {
                var listProduct = Select_Product_Master(model.data.productCode.ToText());

                return new ResponseGetListProductModel
                {
                    status = 200,
                    success = true,
                    data = new ResultGetListProductModel 
                    {
                        listProduct = listProduct
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseGetListProductModel
                {
                    status = 500,
                    success = false,
                    message = errorMessage,
                    error = ex.ToMessage()
                };
            }
        }

        private List<ProductModel> Select_Product_Master(string productCode)
        {
            try
            {
                var ent = _context.productMasterEntity;

                var result = (from d in ent
                              where (string.IsNullOrEmpty(productCode) == false ? d.productCode == productCode : true)
                              select d).ToList();

                var data = JsonConvert.DeserializeObject<List<ProductModel>>(JsonConvert.SerializeObject(result));
                return data;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error select ProductMaster. " + ex.ToMessage());
            }
        }
    }
}
