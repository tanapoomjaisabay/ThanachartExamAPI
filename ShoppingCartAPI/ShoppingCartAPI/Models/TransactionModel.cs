namespace ShoppingCartAPI.Models
{
    public class RequestTransactionModel : RequestModel
    {
        public string transactionId { get; set; } = string.Empty;
        public string totalAmount { get; set; } = string.Empty;
        public List<RequestProductModel> listProduct { get; set; } = new List<RequestProductModel>();
    }

    public class ResponseTransactionModel : ResponseModel
    {

    }

    public class RequestProductModel
    {
        public string productCode { get; set; } = string.Empty;
        public int quantity { get; set; } = 0;
    }
}
