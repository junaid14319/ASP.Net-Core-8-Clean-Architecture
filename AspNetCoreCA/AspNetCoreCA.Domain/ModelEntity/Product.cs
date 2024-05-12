namespace AspNetCoreCA.Domain.ModelEntity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        
        public int? CategoryId { get; set; }
       // [ForeignKey("Id")]
        public Category Category { get; set; }
    }

    
}


