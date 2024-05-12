using AspNetCoreCA.Domain.ModelEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.DTOs
{
    public class PaymentDetailDTO:BaseEntityDTO
    {
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerDTO Customer { get; set; }
        public decimal Amount { get; set; }

    }
}
