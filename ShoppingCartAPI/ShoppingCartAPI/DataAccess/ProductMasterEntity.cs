using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartAPI.DataAccess
{
    public class ProductMasterEntity
    {
        [Column("idKey")]
        public int idKey { get; set; } = 0;
        [Column("productCode")]
        public string productCode { get; set; } = string.Empty;
        [Column("productDesc")]
        public string productDesc { get; set; } = string.Empty;
        [Column("price")]
        public int price { get; set; } = 0;
        [Column("quantity")]
        public int quantity { get; set; } = 0;
        [Column("createBy")]
        public string createBy { get; set; } = string.Empty;
        [Column("createDatetime")]
        public DateTime createDatetime { get; set; } = DateTime.Now;
        [Column("updateBy")]
        public string updateBy { get; set; } = string.Empty;
        [Column("updateDatetime")]
        public DateTime updateDatetime { get; set; } = DateTime.Now;
    }
}
