using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.DTOs
{
    public class ProductDTO :BaseEntityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        // Navigation property
        [ForeignKey("CategoryId")]
        public CategoryDTO CategoryDTO { get; set; }

        // Add other relevant properties and relationships
    }

}
