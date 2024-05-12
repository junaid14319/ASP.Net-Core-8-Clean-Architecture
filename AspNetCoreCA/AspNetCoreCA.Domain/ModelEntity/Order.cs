using AspNetCoreCA.Domain.Common;

namespace AspNetCoreCA.Domain.ModelEntity
{
    public class Order:BaseEntity
    {
       
      
        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string HomeAddress { get; set; }
        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumbre { get; set; }
        public string? Carrier { get; set; }
        public string? SessionId { get; set; }
        public string? PaymentIntenId { get; set; }
       
        
    }
}
