using AspNetCoreCA.Domain.Common;
using AspNetCoreCA.Domain.ModelEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.DTOs
{
    public class OrderDTO :BaseEntityDTO 
    {
         public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }



    }
}
