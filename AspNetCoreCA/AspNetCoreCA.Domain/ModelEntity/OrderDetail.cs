using AspNetCoreCA.Domain.Common;

namespace AspNetCoreCA.Domain.ModelEntity
{
    public class OrderDetail:BaseEntity
    {
        public int OrderId { get; set; }
        //[ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int? ProductId { get; set; }
        //[ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }
        public int Count { get; set; }
    }
}
