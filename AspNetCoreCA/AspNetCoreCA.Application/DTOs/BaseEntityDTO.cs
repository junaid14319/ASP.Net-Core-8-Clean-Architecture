using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreCA.Application.DTOs
{
    public class BaseEntityDTO
    {
       
        public int Id { get; set; }
        public string? UpdateBy { get; set; } 
        public string? CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime CreatedData { get; set; }= DateTime.Now;
    }
}
