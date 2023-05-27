using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppingCartAPI.DataAccess;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartAPI.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly IConfiguration _configuration;
        private readonly ProductContext _context;

        public TransactionService(IConfiguration configuration, ProductContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public ResponseTransactionModel CreateTransaction(RequestTransactionModel model)
        {
            string errorMessage = "Create transaction failed. Please try again.";

            try
            {
                foreach (var item in model.listProduct)
                {
                    VerifyProductStock(item);
                }
                UpdateProductStock(model.listProduct);

                return new ResponseTransactionModel
                {
                    status = 200,
                    success = true,
                    message = "Thank you for using the service."
                };
            }
            catch (Exception ex)
            {
                return new ResponseTransactionModel
                {
                    status = 500,
                    success = false,
                    message = errorMessage,
                    error = ex.ToMessage()
                };
            }
        }

        private void VerifyProductStock(RequestProductModel transaction)
        {
            try
            {
                var ent = _context.productMasterEntity;

                var result = (from d in ent
                              where d.productCode == transaction.productCode
                              select d).FirstOrDefault();

                if (result == null) 
                {
                    throw new ValidationException("Not found product. [" + transaction.productCode + "]");
                }

                string transactionDesc = transaction.productCode + "|" + result.productDesc;
                if (result.quantity < transaction.quantity)
                {
                    throw new ValidationException("Out of stock. [" + transactionDesc + "]");
                }
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error verify product stock. " + ex.ToMessage());
            }
        }
        private void UpdateProductStock(List<RequestProductModel> listProduct)
        {
            try
            {
                foreach (var transaction in listProduct)
                {
                    var ent = _context.productMasterEntity;

                    var result = (from d in ent
                                  where d.productCode == transaction.productCode
                                  select d).FirstOrDefault();

                    if (result == null)
                    {
                        throw new ValidationException("Not found product. [" + transaction.productCode + "]");
                    }

                    result.quantity = result.quantity - transaction.quantity;
                    result.updateDatetime = DateTime.Now;
                    _context.Update(result);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error update product stock. " + ex.ToMessage());
            }
        }
    }
}
