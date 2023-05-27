namespace ShoppingCartAPI.Models
{
    public class RequestModel
    {
        public string deviceInfo { get; set; } = string.Empty;
        public DateTime transactionDate { get; set; }
    }

    public class ResponseModel
    {
        public int status { get; set; } = 500;
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
        public object? error { get; set; }
    }

    public class ResultModel
    {
        public int status { get; set; } = 500;
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
        public object? error { get; set; }
        public object? data { get; set; }
    }
}
