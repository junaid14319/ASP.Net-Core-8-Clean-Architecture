using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.DTOs
{
    public class SupplierDTO:BaseEntityDTO
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
