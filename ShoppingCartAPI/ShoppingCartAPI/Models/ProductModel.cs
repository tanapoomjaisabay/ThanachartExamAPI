namespace ShoppingCartAPI.Models
{
    public class ProductModel
    {
        public int idKey { get; set; } = 0;
        public string productCode { get; set; } = string.Empty;
        public string productDesc { get; set; } = string.Empty;
        public int price { get; set; } = 0;
        public int quantity { get; set; } = 0;
        public string createBy { get; set; } = string.Empty;
        public DateTime createDatetime { get; set; } = DateTime.Now;
        public string updateBy { get; set; } = string.Empty;
        public DateTime updateDatetime { get; set; } = DateTime.Now;
    }

    public class RequestGetListProductModel : RequestModel
    {
        public ProductModel data { get; set; } = new ProductModel();
    }

    public class ResponseGetListProductModel : ResponseModel
    {
        public ResultGetListProductModel data { get; set; } = new ResultGetListProductModel { };
    }
    public class ResultGetListProductModel
    {
        public List<ProductModel> listProduct { get; set; } = new List<ProductModel>();
    }

}
