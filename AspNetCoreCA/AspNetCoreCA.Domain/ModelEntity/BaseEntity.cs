using System;



namespace AspNetCoreCA.Domain.ModelEntity
{
    public class BaseEntity
    {
        
        public int Id { get; set; }
        public string? UpdateBy { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime CreatedData { get; set; } = DateTime.Now;
    }
}
