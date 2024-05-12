using AspNetCoreCA.Domain.Common;

namespace AspNetCoreCA.Domain.ModelEntity
{
    public class PaymentDetail : BaseEntity
    {
        public int CustomerId { get; set; }
        
        // Correct attribute and namespace
        //[ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public decimal Amount { get; set; }
    }
}
